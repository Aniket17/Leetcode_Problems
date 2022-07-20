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
    public int MaxPathSum(TreeNode root) {
        GetMaxPathSum(root);
        return maxSum;
    }
    
    public int GetMaxPathSum(TreeNode node){
        if(node == null) return 0;
        var left = node.val + Math.Max(GetMaxPathSum(node.left), 0);
        var right = node.val + Math.Max(GetMaxPathSum(node.right), 0);
        maxSum = Math.Max(maxSum, left + right - node.val);
        return Math.Max(left, right);
    }
}