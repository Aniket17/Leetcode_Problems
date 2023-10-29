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
    public Node CloneGraph(Node node) {
        if(node == null) return null;
        
        HashSet<int> visited = new();
        var map = new Dictionary<int, Node>();
        return CloneGraph(node, map, visited);
    }

    Node CloneGraph(Node node, Dictionary<int, Node> map, HashSet<int> visited){
        if(visited.Contains(node.val)) return map[node.val];
        var root = new Node(node.val);
        map.Add(node.val, root);
        visited.Add(node.val);

        foreach(var nei in node.neighbors){
            root.neighbors.Add(CloneGraph(nei, map, visited));
        }
        return root;
    }
}