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

package com.fjxy.sample.thread.sync;

public class AccountTest {

    private static int NUM_OF_THREAD = 1000;
    private static Thread[] threads = new Thread[NUM_OF_THREAD];

    public static void main(String[] args) {
        final Account acc = new Account("John", 1000.0f);

        for (int i = 0; i < NUM_OF_THREAD; i++) {
            threads[i] = new Thread(new Runnable() {
                public void run() {
                    acc.deposit(100.0f);
                    acc.withdraw(100.0f);
                }
            });
            threads[i].start();
        }

        for (int i = 0; i < NUM_OF_THREAD; i++) {
            try {
                threads[i].join();  // 等待所有线程运行结束
            }
            catch (InterruptedException e) {
                // Ignore
            }
        }

        System.out.println("Finally, John's balance is: " + acc.getBalance());
    }
}
