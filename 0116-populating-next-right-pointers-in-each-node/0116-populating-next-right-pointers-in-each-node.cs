/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
    public Node Connect(Node root) {
        if(root == null) return root;

       // var stack = new Stack<Node>();
        var queue = new Queue<Node>();
        queue.Enqueue(root);
        
        while(queue.Count != 0){
            var size = queue.Count;
            Node next = null;
            while(size-- != 0){
                var node = queue.Dequeue();
                node.next = next;
                next = node;
                if(node.left != null && node.right != null){
                    queue.Enqueue(node.right);
                    queue.Enqueue(node.left);
                }
            }
        }
        return root;
    }
}