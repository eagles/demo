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
import org.apache.log4j.LogManager;
import org.apache.log4j.Logger;
import org.apache.log4j.PropertyConfigurator;

public class Log4JExample {

    // Define a static logger variable so that it references the
    // Logger instance named "MyApp".
    static Logger logger = LogManager.getLogger(Log4JExample.class.getName());

    public static void main(String[] args) {
        BasicConfigurator.configure();
        PropertyConfigurator.configure(Log4JExample.class.getResource("Log4j.properties"));
        // Set up a simple configuration that logs on the console.
        logger.info("Entering application.");
        Bar bar = new Bar();
        bar.doIt();
        logger.info("Exiting application."); 
    }

    public static class Bar {
        Logger logger = LogManager.getLogger(Bar.class.getName());

        public void doIt() {
            logger.debug("Did it again!");
        }
    }
}
