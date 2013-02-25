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

import java.util.Date;

/**
 * 所有任务接口
 * 
 * Copyright (c) 2013 Eason Wu
 * All Rights Reserved
 * 
 * @author eason.wu
 */
public abstract class Task implements Runnable {

    /**
     * 产生时间
     */
    private Date generateTime = null;

    /**
     * 提交时间
     */
    private Date submitTime = null;
    
    /**
     * 开始执行时间
     */
    private Date beginExecuteTime = null;
    
    /**
     * 执行完成时间
     */
    private Date finishTime = null;
    
    private long taskId;
    
    public Task() {
        this.generateTime = new Date();
    }

    /**
     * 任务执行入口
     */
    @Override
    public void run() {
        /**
         * 相关执行代码
         *
         * beginTransaction();
         *
         * 执行过程中可能产生新的任务 subtask = taskCore();
         *
         * commitTransaction();
         *
         * 增加新产生的任务 ThreadPool.getInstance().batchAddTask(taskCore());
         */
     }

     /**
     * 所有任务的核心 所以特别的业务逻辑执行之处
     *
     * @throws Exception
     */
     public abstract Task[] taskCore() throws Exception;

     /**
     * 是否用到数据库
     *
     * @return
     */
     protected abstract boolean useDb();

     /**
     * 是否需要立即执行
     *
     * @return
     */
     protected abstract boolean needExecuteImmediate();

     /**
     * 任务信息
     *
     * @return String
     */
     public abstract String info();

     public Date getGenerateTime() {
         return generateTime;
     }

     public Date getBeginExecuteTime() {
         return beginExecuteTime;
     }

     public void setBeginExecuteTime(Date beginExecuteTime) {
         this.beginExecuteTime = beginExecuteTime;
     }

     public Date getFinishTime() {
         return finishTime;
     }

     public void setFinishTime(Date finishTime) {
         this.finishTime = finishTime;
     }

     public Date getSubmitTime() {
         return submitTime;
     }

     public void setSubmitTime(Date submitTime) {
         this.submitTime = submitTime;
     }

     public long getTaskId() {
         return taskId;
     }

     public void setTaskId(long taskId) {
         this.taskId = taskId;
     }

}
