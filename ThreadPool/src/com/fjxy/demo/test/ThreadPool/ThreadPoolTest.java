/*
 *  $URL: https://athena.redprairie.com/svn/prod/devtools/trunk/bootstrap/eclipse/codetemplates.xml $
 *  $Author: mlange $
 *  $Date: 2009-06-19 11:49:22 +0800 (Fri, 19 Jun 2009) $
 *  
 *  $Copyright-Start$
 *
 *  Copyright (c) 2013
 *  RedPrairie Corporation
 *  All Rights Reserved
 *
 *  This software is furnished under a corporate license for use on a
 *  single computer system and can be copied (with inclusion of the
 *  above copyright) only for use on such a system.
 *
 *  The information in this document is subject to change without notice
 *  and should not be construed as a commitment by RedPrairie Corporation.
 *
 *  RedPrairie Corporation assumes no responsibility for the use of the
 *  software described in this document on equipment which has not been
 *  supplied or approved by RedPrairie Corporation.
 *
 *  $Copyright-End$
 */

package com.fjxy.demo.test.ThreadPool;

import com.fjxy.demo.ThreadPool.ThreadPool;

public class ThreadPoolTest {

    public static void main(String[] args) throws InterruptedException {
        // 创建一个有3个工作线程的线程池
        ThreadPool threadPool = new ThreadPool(3);
        // 休眠500毫秒，以便让线程池中的工作线程全部运行
        Thread.sleep(500);
        // 运行任务
        for (int i = 1; i <= 6; i++) {
            // 创建6个任务
            threadPool.execute(createTask(i));
        }

        threadPool.waitFinish();  // 等待任务执行完毕
        threadPool.closePool();  // 关闭线程池
    }

    private static Runnable createTask(final int taskId) {
        return new Runnable() {
            @Override
            public void run() {
                System.out.println("Task" + taskId + "开始");
                System.out.println("Hello world");
                System.out.println("Task" + taskId + "结束");
            }
        };
    }
}
