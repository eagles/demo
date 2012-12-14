package com.fjxy.sample.extjs.util;

public class CountryTree {
    String id = null;
    String text = null;
    boolean leaf = false;
    String cls = null;

    public String getId() {
        return id;
    }
    public void setId(String id) {
        this.id = id;
    }
    public String getText() {
        return text;
    }
    public void setText(String text) {
        this.text = text;
    }
    public boolean isLeaf() {
        return leaf;
    }
    public void setLeaf(boolean leaf) {
        this.leaf = leaf;
    }
    public String getCls() {
        return cls;
    }
    public void setCls(String cls) {
        this.cls = cls;
    }
}
