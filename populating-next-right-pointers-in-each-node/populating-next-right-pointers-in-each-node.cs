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
        if(root == null || (root.right == null && root.left == null)){
            return root;
        }
        var queue = new Queue<Node>();
        
        queue.Enqueue(root);
        
        while(queue.Count != 0){
            
            var size = queue.Count;
            Node prev = null;
            while(size-- > 0){
                var node = queue.Dequeue();
                node.next = prev;
                prev = node;
                if(node.right != null){
                    queue.Enqueue(node.right);
                }
                if(node.left != null){
                    queue.Enqueue(node.left);
                }
            }
        }
        
        return root;
    }
}

/*

bfs root right left

1               prev = null > 1->null
3 2             prev = null 3->null, prev = 3, 2->3
7 6 5 4         prev = null 7 -> null prev = 7 6->7



*/