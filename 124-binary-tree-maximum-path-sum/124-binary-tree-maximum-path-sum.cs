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
    int maxSum = int.MinValue;
    public int MaxPathSum(TreeNode node) {
        ExplorePath(node);
        return maxSum;
    }
    
    private int ExplorePath(TreeNode node){
        if(node == null) return 0;
        
        var left = Math.Max(ExplorePath(node.left), 0);
        var right = Math.Max(ExplorePath(node.right), 0);
        var subSum = node.val + left + right;
        maxSum = Math.Max(subSum, maxSum);
        return node.val + Math.Max(left, right);
    }
}