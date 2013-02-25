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

public class Account {

    String name;
    float amount;

    public Account(String name, float amount) {
        this.name = name;
        this.amount = amount;
    }

    public synchronized void deposit(float money) {
        float tmp = amount;
        tmp += money;
        
        try {
            Thread.sleep(10); // 模拟其他处理所需要的时间
        }
        catch (InterruptedException e) {
            // Ignore
        }

        amount = tmp;
    }

    public synchronized void withdraw(float money) {
        float tmp = amount;
        tmp -= money;

        try {
            Thread.sleep(10); // 模拟其他处理所需要的时间，比如刷新数据库
        }
        catch (InterruptedException e) {
            // Ignore
        }

        amount = tmp;
    }
    
    public float getBalance() {
        return amount;
    }
}
