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

package com.fjxy.demo.test.ThreadPool;

import org.apache.log4j.BasicConfigurator;
import org.apache.log4j.PropertyConfigurator;

import com.fjxy.demo.ThreadPool.MyThreadPool;
import com.fjxy.demo.ThreadPool.Task;

public class MyThreadPoolTest {

    /**
     * @param args
     * @throws InterruptedException 
     */
    public static void main(String[] args) throws InterruptedException {
        BasicConfigurator.configure();
        PropertyConfigurator.configure(MyThreadPoolTest.class.getResource("Log4j.properties"));
       
        MyThreadPool pool = MyThreadPool.getInstance();
        // 休眠500毫秒，以便让线程池中的工作线程全部运行
        Thread.sleep(5000);
        pool.batchAddTask(createTask());

        pool.destroy();
    }
    
    private static Task[] createTask() {
        Task[] tasks = new Task[5];
        for (int i = 0; i < 5; i++) {
            tasks[i] = new TestTask(i);
        }

        return tasks;
    }
    
    private static class TestTask extends Task {

        public TestTask(long taskId) {
            setTaskId(taskId);
        }

        @Override
        public void run() {
            System.out.println("Task" + this.getTaskId() + "开始");
            System.out.println("Hello world");
            System.out.println("Task" + this.getTaskId() + "结束");
        }

        @Override
        public Task[] taskCore() throws Exception {
            return null;
        }

        @Override
        protected boolean useDb() {
            return false;
        }

        @Override
        protected boolean needExecuteImmediate() {
            return true;
        }

        @Override
        public String info() {
            return "Test Tasks" + getTaskId();
        }
    }

}
