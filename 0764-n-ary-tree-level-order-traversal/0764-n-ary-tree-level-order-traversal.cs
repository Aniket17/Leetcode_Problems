/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    public IList<IList<int>> LevelOrder(Node root) {
        var result = new List<IList<int>>();
        if(root == null) return result;

        var queue = new Queue<Node>();
        queue.Enqueue(root);

        while(queue.Count != 0){
            var size = queue.Count;
            var levelNodes = new List<int>();
            while(size-- != 0){
                var node = queue.Dequeue();
                levelNodes.Add(node.val);

                if(node.children != null){
                    foreach(var child in node.children){
                        if(child == null) continue;
                        queue.Enqueue(child);
                    }
                }
            }

            result.Add(levelNodes);
        }
        return result;
    }
}