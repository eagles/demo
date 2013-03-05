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
 *  and should not be construed as a commitment by Eason Wu.
 *
 *  $Copyright-End$
 */

package com.fjxy.demo.ThreadPool;

import java.util.LinkedList;

/**
 * 一个简单的线程池
 * 出处： http://sunnylocus.iteye.com/blog/223327
 * 
 * 线程池的作用:
 * 线程池作用就是限制系统中执行线程的数量。
 * 根据系统的环境情况，可以自动或手动设置线程数量，达到运行的最佳效果；
 * 少了浪费了系统资源，多了造成系统拥挤效率不高。用线程池控制线程数量，
 * 其他线程排队等候。一个任务执行完毕，再从队列的中取最前面的任务开始执行。
 * 若队列中没有等待进程，线程池的这一资源处于等待。当一个新任务需要运行时，
 * 如果线程池中有等待的工作线程，就可以开始运行了；否则进入等待队列。
 * 
 * 为什么要用线程池:
 * 减少了创建和销毁线程的次数，每个工作线程都可以被重复利用，可执行多个任务
 * 可以根据系统的承受能力，调整线程池中工作线线程的数目，防止因为因为消耗过
 * 多的内存，而把服务器累趴下(每个线程需要大约1MB内存，线程开的越多，消耗的
 * 内存也就越大，最后死机)
 * 
 * Copyright (c) 2013 Eason Wu
 * All Rights Reserved
 * 
 * @author eason.wu
 */
public class ThreadPool extends ThreadGroup {

    private boolean isClosed = false;   // 线程池是否关闭
    private LinkedList<Runnable> workQueue;     // 工作队列
    private static int threadPoolID = 1;  // 线程池ID

    /**
     * Constructor
     * @param poolSize  表示线程池中的工作线程的数量
     */
    public ThreadPool(int poolSize) {
        super(threadPoolID + "");   // 指定ThreadGroup的名称
        setDaemon(true);            // 继承到的方法，设置是否守护线程池
        workQueue = new LinkedList<Runnable>();  //创建工作队列

        for (int i = 1; i < poolSize + 1; i++) {
            new WorkThread(i).start();   //创建并启动工作线程,线程池数量是多少就创建多少个工作
        }
    }

    /**
     * 向工作队列中加入一个亲任务，由工作线程去执行该任务
     * @param task   可执行任务
     */
    public synchronized void execute(Runnable task) {
        if (isClosed) {
            throw new IllegalStateException();
        }
        if (task != null) {
            workQueue.add(task);
            notify();
        }
    }

    /**
     * 从工作队列中取出一个任务，工作线程会调用此方法
     * @param threadId   Thread ID
     * @return 返回这个可执行任务
     * @throws InterruptedException 
     */
    private synchronized Runnable getTask(int threadId) throws InterruptedException {
        while (workQueue.size() == 0) {
            if (isClosed) return null;
            System.out.println("工作线程" +  threadId);
            wait();       // 如果工作队列中没有任务， 就继续等待
        }

        System.out.println("工作线程" + threadId + "开始执行任务...");
        return (Runnable) workQueue.removeFirst();  // 返回队列中的第一个元素，并从队列中删除
    }
    
    /**
     * 关闭线程池
     */
    public synchronized void closePool() {
        if (!isClosed) {
            waitFinish();   // 等待线程执行完毕
            isClosed = true;
            workQueue.clear();  // 清空任务队列
            interrupt();   // 中断线程池中的所有的工作线程,此方法继承自ThreadGroup类
        }
    }

    public void waitFinish() {
        synchronized (this) {
            isClosed = true;
            notifyAll();  // 唤醒所有还在getTask()方法中等待任务的工作线程
        }

        Thread[] threads = new Thread[activeCount()]; // activeCount() 返回该线程组中活动线程的丈夫值
        int count = enumerate(threads);  //enumerate()方法继承自ThreadGroup类，根据活动线程的估计值获得线程组中当前所有活动的工作线程  

        for (int i = 0; i < count; i++) {
            try {
                threads[i].join();   //等待工作线程结束
            }
            catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }

    /**
     * 内部类，工作线程，负责从工作队列中取出任务，并执行
     * 
     * Copyright (c) 2013 Eason Wu
     * All Rights Reserved
     * 
     * @author eason.wu
     */
    private class WorkThread extends Thread {
        private int id;

        public WorkThread(int id) {
            // 父类构造方法，将线程加入到当前ThreadPool线程组中去
            super(ThreadPool.this, id + "");
            this.id = id;
        }

        public void run() {
            // isInterrupted()方法继承自Thread类，判断线程是否被中断
            while (!isInterrupted()) {
                Runnable task = null;
                try {
                    task = getTask(id);   // 取出任务
                }
                catch (InterruptedException e) {
                    e.printStackTrace();
                }

                // 如果getTask返回null或者线程执行getTask()时被中断，则结束此线程
                if (task == null) return;
                try {
                    task.run();   //运行任务
                }
                catch (Throwable t) {
                    t.printStackTrace();
                }
            }
        }
    }
}
