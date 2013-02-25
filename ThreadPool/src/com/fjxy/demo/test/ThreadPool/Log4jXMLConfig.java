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

import org.apache.log4j.xml.DOMConfigurator;

public class Log4jXMLConfig {

    private static Log4jXMLConfig instance;
    
    private Log4jXMLConfig() {
        DOMConfigurator.configure(Log4jXMLConfig.class.getResource("log4j.xml"));
    }
    
    public static synchronized Log4jXMLConfig init() {
        if (instance == null) {
            return new Log4jXMLConfig();
        }
        return instance;
    }
}
