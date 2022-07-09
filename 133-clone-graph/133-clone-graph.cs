/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    Dictionary<Node, Node> map = new Dictionary<Node, Node>();
    public Node CloneGraph(Node node) {
        if(node == null) return null;
        var newNode = new Node(node.val);
        if(!map.ContainsKey(node)){
            map[node] = newNode;
        }else{
            return map[node];
        }
        foreach(var nei in node.neighbors){
            Node cloned = null;
            if(!map.ContainsKey(nei)){
                cloned = CloneGraph(nei);
            }else{
                cloned = map[nei];
            }
            newNode.neighbors.Add(cloned);
        }
        return newNode;
    }
}