/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node CopyRandomList(Node head) {
        if(head == null) return null;
        var dict = new Dictionary<Node, Node>();
        DeepCopy(head, dict);
        return dict[head];
    }
    
    private Node DeepCopy(Node node, Dictionary<Node, Node> visited)
    {
        if(node == null) return null;
        if(visited.ContainsKey(node)){
            return visited[node];
        }
        var newNode = new Node(node.val);
        visited.Add(node, newNode);
        newNode.next = DeepCopy(node.next, visited);
        newNode.random = DeepCopy(node.random, visited);
        return newNode;
    }
}