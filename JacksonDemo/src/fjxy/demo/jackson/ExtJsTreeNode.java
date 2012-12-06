package fjxy.demo.jackson;

import java.util.List;

public class ExtJsTreeNode {

    private String id;
    private String text;
    private Boolean leaf;
    private Boolean expanded;
    private List <ExtJsTreeNode> children;

    /**
     * @return the id
     */
    public String getId() {
        return id;
    }

    /**
     * @param id the id to set
     */
    public void setId(String id) {
        this.id = id;
    }
    
    /**
     * @return the text
     */
    public String getText() {
        return text;
    }

    /**
     * @param text the text to set
     */
    public void setText(String text) {
        this.text = text;
    }

    /**
     * @return the leaf
     */
    public Boolean getLeaf() {
        return leaf;
    }

    /**
     * @param leaf the leaf to set
     */
    public void setLeaf(Boolean leaf) {
        this.leaf = leaf;
    }

    /**
     * @return the expanded
     */
    public Boolean getExpanded() {
        this.expanded = this.leaf ? false : true;
        return this.expanded;
    }

    /**
     * @return the children
     */
    public List <ExtJsTreeNode> getChildren() {
        return children;
    }

    /**
     * @param children the children to set
     */
    public void setChildren(List <ExtJsTreeNode> children) {
        this.children = children;
    }

    public ExtJsTreeNode() {}

    public ExtJsTreeNode(String id, String text, Boolean leaf, Boolean expanded, List<ExtJsTreeNode> children) {
        this.id = id;
        this.text = text;
        this.leaf = leaf;
        this.expanded = expanded;
        this.children = children;
    }
}
