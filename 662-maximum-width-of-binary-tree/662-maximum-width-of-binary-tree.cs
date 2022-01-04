/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public int WidthOfBinaryTree(TreeNode root) {
        if(root == null) return 0;
        
        var width = int.MinValue;
        
        var queue = new Queue<Tuple<int, TreeNode>>();
        queue.Enqueue(Tuple.Create(0, root));
        
        while(queue.Count != 0){
            var size = queue.Count;
            var minIndex = queue.Peek().Item1;
            var first = 0;
            var last = 0;
            while(size-- != 0){
                var tuple = queue.Dequeue();
                var idx = tuple.Item1;
                var node = tuple.Item2;
                var id = idx - minIndex;
                
                if(size == 0){
                    last = id;
                }
                if(node.left != null){
                    queue.Enqueue(Tuple.Create(id * 2 + 1, node.left));
                }
                if(node.right != null){
                    queue.Enqueue(Tuple.Create(id * 2 + 2, node.right));
                }
            }
            width = Math.Max(last - first + 1, width);
        }
        return width;
    }
}

/*
if left found, count the null nodes too
in between all nulls

*/