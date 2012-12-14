package com.fjxy.sample.extjs;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import com.fjxy.sample.extjs.util.CountryTree;
import com.fjxy.sample.extjs.util.CountryInformation;

@SuppressWarnings("serial")
public class CountryServlet {

    private static final long serialVersionUID = 1L;

    public CountryServlet() {
        super();
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        doPost(request,response);
    }

    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

        node = request.getParameter("node").trim();

        String delims = "[/]";
        String[] tokens = node.split(delims);

        PrintWriter out = response.getWriter();
        response.setContentType("text/html");

        JSONArray arrayObj = new JSONArray();
        CountryInformation countryInformation = new CountryInformation();
        ArrayList<CountryTree> countryList = new ArrayList<CountryTree>();

        if (tokens.length == 1) {
            countryList = countryInformation.getContinentTree(node);
        }
        else if (tokens.length == 2) {
            String continent = tokens[1];
            countryList = countryInformation.getRegionTree(node, continent);
        }
        else if (tokens.length == 3) {
            String continent = tokens[1];
            String region = tokens[2];
            countryList = countryInformation.getCountryTree(node, continent, region);
        }

        for (int i = 0; i < countryList.size(); i++) {
            CountryTree country = countryList.get(i);
            JSONObject itemObj = JSONObject.fromObject(country);
            arrayObj.add(itemObj);
        }

        out.println(arrayObj.toString());
        out.close();
    }

    private String node;
}
