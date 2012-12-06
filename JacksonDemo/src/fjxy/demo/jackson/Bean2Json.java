package fjxy.demo.jackson;

import java.util.ArrayList;
import java.util.List;

import com.fasterxml.jackson.annotation.JsonInclude.Include;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;

public class Bean2Json {

    public ExtJsTreeNode init() {
        ExtJsTreeNode tree = new ExtJsTreeNode();

        tree.setId("Root");
        tree.setText("Root");
        tree.setLeaf(false);

        // Build children items
        List<ExtJsTreeNode> children = buildChildren();
        tree.setChildren(children);

        return tree;
    }

    private List<ExtJsTreeNode> buildChildren() {
        List<ExtJsTreeNode> nodes = new ArrayList<ExtJsTreeNode>();

        for (int i = 0; i < 10; i++) {
            ExtJsTreeNode node = new ExtJsTreeNode();

            node.setId("Node" + i);
            node.setText("Node" + i);
            node.setLeaf(false);
            List<ExtJsTreeNode> children = new ArrayList<ExtJsTreeNode>();
            children.add(new ExtJsTreeNode("Child", "Child", true, false, null));

            node.setChildren(children);

            nodes.add(node);
        }
        
        return nodes;
    }
    
    public void convertToJson(ExtJsTreeNode tree) throws JsonProcessingException {
        ObjectMapper mapper = new ObjectMapper();
        // Don't output null fields
        mapper.setSerializationInclusion(Include.NON_NULL);
        String json = mapper.writeValueAsString(tree);

        System.out.println(json);
    }

    /**
     * @param args
     * @throws JsonProcessingException 
     */
    public static void main(String[] args) throws JsonProcessingException {
        Bean2Json jsonUtil = new Bean2Json();
        ExtJsTreeNode tree = jsonUtil.init();
        jsonUtil.convertToJson(tree);

    }

}
