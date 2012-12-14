package com.fjxy.sample.extjs.util;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.PreparedStatement;
import java.util.ArrayList;
import javax.naming.Context;
import javax.naming.InitialContext;
import javax.sql.DataSource;

public class CountryInformation {
    Connection conn = null;
    PreparedStatement stmt = null;
    String sql = null;

    public ArrayList<CountryTree> getContinentTree(String node) {

        ArrayList<CountryTree> countryList = new ArrayList<CountryTree>();  

        try {
            Context ctx = (Context) new InitialContext().lookup("java:comp/env");
            conn = ((DataSource) ctx.lookup("jdbc/mysql")).getConnection();

            sql = "Select distinct(continent) as c from COUNTRY";
            stmt = conn.prepareStatement(sql);
            ResultSet rs = stmt.executeQuery();
            
            while(rs.next()){
                CountryTree countryTree = new CountryTree();
                countryTree.setId(node + "/" + rs.getString(1).trim());
                countryTree.setText(rs.getString(1).trim());
                countryTree.setLeaf(false);
                countryTree.setCls("folder");
                countryList.add(countryTree);
            }

            rs.close();
            stmt.close();
            stmt = null;

            conn.close();
            conn = null;

        }
        catch (Exception e) {
            System.out.println(e);
        }
        finally {
            if (stmt != null) {
                try {
                    stmt.close();
                } catch (SQLException sqlex) {
                    // ignore -- as we can't do anything about it here          
                }

                stmt = null;
            }

            if (conn != null) {
                try {
                    conn.close();
                } catch (SQLException sqlex) {
                    // ignore -- as we can't do anything about it here    
                }
                conn = null;
            }
        }

        return countryList;

    }

    public ArrayList<CountryTree> getRegionTree(String node, String continent) {

        ArrayList<CountryTree> countryList = new ArrayList<CountryTree>();  

        try {     
            Context ctx = (Context) new InitialContext().lookup("java:comp/env");
            conn = ((DataSource) ctx.lookup("jdbc/mysql")).getConnection();

            sql = "Select distinct(region) as r from COUNTRY where continent = ?";
            stmt = conn.prepareStatement(sql);
            stmt.setString(1, continent.trim());
            ResultSet rs = stmt.executeQuery();

            while(rs.next()){
                CountryTree countryTree = new CountryTree();
                countryTree.setId(node + "/" + rs.getString(1).trim());
                countryTree.setText(rs.getString(1).trim());
                countryTree.setLeaf(false);
                countryTree.setCls("folder");
                countryList.add(countryTree);
            }
 
            rs.close();
            stmt.close();
            stmt = null;

            conn.close();
            conn = null;
        }
        catch(Exception e){
            System.out.println(e);
        }
        finally {
            if (stmt != null) {
                try {
                    stmt.close(); 
                } catch (SQLException sqlex) {
                    // ignore -- as we can't do anything about it here
                }              
                stmt = null;
            }

            if (conn != null) {
                try {
                    conn.close();
                } catch (SQLException sqlex) {
                    // ignore -- as we can't do anything about it here
                }

                conn = null;
            }
        }

        return countryList;
    }

    public ArrayList<CountryTree> getCountryTree(String node, String continent, String region) {

        ArrayList<CountryTree> countryList = new ArrayList<CountryTree>();  

        try {
            Context ctx = (Context) new InitialContext().lookup("java:comp/env");
            conn = ((DataSource) ctx.lookup("jdbc/mysql")).getConnection();

            sql = "Select * from COUNTRY where continent = ? and region = ?";
            stmt = conn.prepareStatement(sql);
            stmt.setString(1, continent.trim());
            stmt.setString(2, region.trim());
            ResultSet rs = stmt.executeQuery();

            while(rs.next()){
                CountryTree countryTree = new CountryTree();
                countryTree.setId(node + "/" + rs.getString("code").trim());
                countryTree.setText(rs.getString("name").trim());
                countryTree.setLeaf(true);
                countryTree.setCls("file");
                countryList.add(countryTree);
            }

            rs.close();
            stmt.close();
            stmt = null;
            conn.close();
            conn = null;

        }
        catch (Exception e) {
            System.out.println(e);
        }
        finally {
             
            if (stmt != null) {
                try {
                    stmt.close(); 
                } catch (SQLException sqlex) {
                    // ignore -- as we can't do anything about it here
                }
                stmt = null;
            }

            if (conn != null) {
                try {
                    conn.close();
                } catch (SQLException sqlex) {
                    // ignore -- as we can't do anything about it here    
                }
                conn = null;
            }
        }

        return countryList;
    }  
}
