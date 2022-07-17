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
    public int DeepestLeavesSum(TreeNode root) {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        var sum = 0;
        while(queue.Count != 0){
            var count = queue.Count;
            sum = 0;
            while(count-- > 0){
                var node = queue.Dequeue();
                if(node.left == null && node.right == null){
                    //leaf node
                    sum += node.val;
                }
                if(node.left != null){
                    queue.Enqueue(node.left);
                }
                if(node.right != null){
                    queue.Enqueue(node.right);
                }
            }
        }
        return sum;
    }
}