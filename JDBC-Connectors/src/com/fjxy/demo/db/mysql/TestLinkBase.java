package com.fjxy.demo.db.mysql;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class TestLinkBase {

    public static void main(String[] args) {
        String driver = "com.mysql.jdbc.Driver";
        // URL指向要访问的数据库名test
        String url = "jdbc:mysql://127.0.0.1:3306/test";
        // MySQL配置时的用户名
        String user = "root";
        // Java连接MySQL配置时的密码
        String password = "root";

        try {
            // 加载驱动程序
            Class.forName(driver);
            // 连续数据库
            Connection conn = DriverManager.getConnection(url, user, password);
            if (!conn.isClosed())
                System.out.println("Succeeded connecting to the Database!");
            // statement用来执行SQL语句
            Statement statement = conn.createStatement();
            // 要执行的SQL语句
            String sql = "select * from user";
            ResultSet rs = statement.executeQuery(sql);
            System.out.println("-----------------");
            System.out.println("执行结果如下所示:");
            System.out.println("-----------------");
            System.out.println(" 姓名" + "\t" + " 年龄");
            System.out.println("-----------------");
            String name = null;
            while (rs.next()) {
                name = rs.getString("username");
                System.out.println(name + "\t" + rs.getString("age"));
            }
            rs.close();
            System.out.println("-----------------");
            System.out.println("Succeeded closing to the resultset!");
            conn.close();
            System.out.println("-----------------");
            System.out.println("Succeeded close to the connection!");
        } catch (ClassNotFoundException e) {
            System.out.println("Sorry,can`t find the Driver!");
            e.printStackTrace();
        } catch (SQLException e) {
            e.printStackTrace();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
