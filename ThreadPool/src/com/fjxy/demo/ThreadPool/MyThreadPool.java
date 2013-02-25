/*
 *  $URL: https://raw.github.com/eagles/devtools/master/bootstrap/eclipse/codetemplates.xml $
 *  $Author: Eason Wu $
 *  $Date: 2013-02-18 11:49:22 +0800 (Mon, 18 Feb 2013) $
 *  
 *  $Copyright-Start$
 *
 *  Copyright (c) 2013
 *  Eason Wu
 *  All Rights Reserved
 *
 *  This software is furnished under a corporate license for use on a
 *  single computer system and can be copied (with inclusion of the
 *  above copyright) only for use on such a system.
 *
 *  The information in this document is subject to change without notice
 *  and should not be construed as a commitment by  Eason Wu.
 *
 *  $Copyright-End$
 */

package com.fjxy.demo.ThreadPool;

import java.util.Collections;
import java.util.Date;
import java.util.LinkedList;
import java.util.List;

import org.apache.log4j.Logger;

public class MyThreadPool {
    private static Logger logger = Logger.getLogger(MyThreadPool.class);
    private static Logger taskLogger = Logger.getLogger("TaskLogger");
    
    private static boolean debug = taskLogger.isDebugEnabled();
    
    private static MyThreadPool instance = MyThreadPool.getInstance();
    
    public static final int SYS_BUSY_TASK_COUNT = 150;
    
    // 默认池中线程数
    public static int worker_num = 5;
    // 已经处理的任务数
    private static int taskCounter = 0;
    
    public static boolean sysIsBusy = false;
    
    private static List<Task> taskQueue = Collections.synchronizedList(new LinkedList<Task>());
    
    // 池中的所有线程
    public PoolWorker[] workers;

    private MyThreadPool() {
        workers = new PoolWorker[5];
        for (int i = 0; i < workers.length; i++) {
            workers[i] = new PoolWorker(i);
        }
    }

    public static synchronized MyThreadPool getInstance() {
        if (instance == null) {
            return new MyThreadPool();
        }
        return instance;
    }

    /**
     * 增加新的任务
     * 每增加一个新任务，都要唤醒任务队列
     * @param newTask
     */
     public void addTask(Task newTask) {
         synchronized (taskQueue) {
             newTask.setTaskId(++taskCounter);
             newTask.setSubmitTime(new Date());
             taskQueue.add(newTask);
             /* 唤醒队列, 开始执行 */
             taskQueue.notifyAll();
         }
         logger.info("Submit Task<" + newTask.getTaskId() + ">: "
                 + newTask.info());
     }

     /**
     * 批量增加新任务
     * @param tasks
     */
     public void batchAddTask(Task[] tasks) {
         if (tasks == null || tasks.length == 0) {
             return;
         }
         synchronized (taskQueue) {
             for (int i = 0; i < tasks.length; i++) {
                 if (tasks[i] == null) {
                     continue;
                 }
                 tasks[i].setTaskId(++taskCounter);
                 tasks[i].setSubmitTime(new Date());
                 taskQueue.add(tasks[i]);
             }
             /* 唤醒队列, 开始执行 */
             taskQueue.notifyAll();
         }
         for (int i = 0; i < tasks.length; i++) {
             if (tasks[i] == null) {
                 continue;
             }
             logger.info("Submit Task<" + tasks[i].getTaskId() + ">: "
                     + tasks[i].info());
         }
     }

     /**
     * 线程池信息
     * @return
     */
     public String getInfo() {
         StringBuffer sb = new StringBuffer();
         sb.append("\nTask Queue Size:" + taskQueue.size());
         for (int i = 0; i < workers.length; i++) {
             sb.append("\nWorker " + i + " is "
                     + ((workers[i].isWaiting()) ? "Waiting." : "Running."));
         }
         return sb.toString();
     }

     /**
     * 销毁线程池
     */
     public synchronized void destroy() {
         for (int i = 0; i < worker_num; i++) {
             workers[i].stopWorker();
             workers[i] = null;
         }
         taskQueue.clear();
     }

    private class PoolWorker extends Thread {
        private int index = -1;

        // 该工作线程是否
        private boolean isRunning = true;

        // 该工作线程是否可以执行新任务
        private boolean isWaiting = true;

        public PoolWorker(int idx) {
            this.index = idx;
            start();
        }

        public void stopWorker() {
            this.isRunning = false;
        }

        public boolean isWaiting() {
            return this.isWaiting;
        }

        public void run() {
            while (isRunning) {
                Task r = null;
                synchronized (taskQueue) {
                    while (taskQueue.isEmpty()) {
                        try {
                            // 任务队列为空，则等待有新任务加入从而被唤醒
                            taskQueue.wait(20);
                        } catch (InterruptedException ex) {
                            logger.error(ex);
                        }
                    }
                    // 取出任务执行
                    r = (Task) taskQueue.remove(0);
                }

                if (r != null) {
                    isWaiting = false;
                    try {
                        if (debug) {
                            r.setBeginExecuteTime(new Date());
                            taskLogger.debug("Worker<" + index
                                + "> start execute Task<" + r.getTaskId() + ">");
                            if (r.getBeginExecuteTime().getTime()
                                - r.getSubmitTime().getTime() > 1000)
                            taskLogger.debug("longer waiting time. "
                                    + r.info() + ",<" + index + ">,time:"
                                    + (r.getFinishTime().getTime() - r
                                            .getBeginExecuteTime().getTime()));
                        }
                        
                        // 该任务是否需要立即执行
                        if (r.needExecuteImmediate()) {
                            new Thread(r).start();
                        } else {
                            r.run();
                        }
                        
                        if (debug) {
                            r.setFinishTime(new Date());
                            taskLogger.debug("Worker<" + index
                                + "> finish task<" + r.getTaskId() + ">");
                            if (r.getFinishTime().getTime()
                                - r.getBeginExecuteTime().getTime() > 1000)
                            taskLogger.debug("longer execution time. "
                                    + r.info() + ",<" + index + ">,time:"
                                    + (r.getFinishTime().getTime() - r
                                            .getBeginExecuteTime().getTime()));
                        }
                    } catch (Exception e) {
                        e.printStackTrace();
                        logger.error(e);
                    }
                    
                    isWaiting = true;
                    r = null;
                }
            }
        }
    }
}
