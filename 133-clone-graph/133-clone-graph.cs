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
    Dictionary<int, Node> visited = new Dictionary<int, Node>();
    public Node CloneGraph(Node node) {
        if(node == null) return node;
        if(visited.ContainsKey(node.val)) return visited[node.val];
        
        var newNode = new Node(node.val);
        visited.Add(node.val, newNode);
        
        foreach(var oldNode in node.neighbors){
            newNode.neighbors.Add(CloneGraph(oldNode));
        }
        return newNode;
    }
}