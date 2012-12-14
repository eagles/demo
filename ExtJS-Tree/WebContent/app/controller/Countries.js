Ext.define('TR.controller.Countries', {
    extend : 'Ext.app.Controller',

    //define the stores
    stores : ['Countries'],
    //define the models
    models : [],
    //define the views
    views : ['CountryTree'],
    refs: [{
        ref: 'myCountryTree',
        selector: 'countryTree'
    }],

    init : function() {
        this.control({
            'viewport' : {
                render : this.onPanelRendered
            },
            'countryTree button[text=Expand All]' : {
                click : this.expandAll  
            },
            'countryTree button[text=Collapse All]' : {
                click : this.collapseAll  
            },
            'countryTree' : {
                itemclick : this.treeItemClick  
            }
        });
    },

    onPanelRendered : function() {
        //just a console log to show when the panel si rendered
        console.log('The panel was rendered');
    },

    expandAll : function() {
        //expand all the Tree Nodes
        var myTree = this.getMyCountryTree();
        myTree.expandAll();
    },

    collapseAll : function() {
        //expand all the Tree Nodes
        var myTree = this.getMyCountryTree();
        myTree.collapseAll();
    },

    treeItemClick : function(view, record) {
        //some node in the tree was clicked
        //you have now access to the node record and the tree view
        Ext.Msg.alert('Clicked on a Tree Node',
            'Node id: ' + record.get('id') + '\n' +
            'Node Text: ' + record.get('text') + '\n' +
            'Parent Node id: ' + record.get('parentId') + '\n' +
            'Is it a leaf?: ' + record.get('leaf') + '\n' +
            'No of Children: ' + record.childNodes.length
        );
        //now you have all the information about the node
        //Node id
        //Node Text
        //Parent Node
        //Is the node a leaf?
        //No of child nodes
        //......................
        //go do some real world processing
    }
});