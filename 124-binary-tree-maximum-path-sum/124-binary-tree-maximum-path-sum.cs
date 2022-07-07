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
        if(root.left == null && root.right == null) return root.val;
        ExplorePaths(root);
        return maxSum;
    }
    
    public int ExplorePaths(TreeNode root){
        if(root == null) return 0;
        var ls = Math.Max(ExplorePaths(root.left),0);
        var rs = Math.Max(ExplorePaths(root.right),0);
        var subSum = root.val + ls + rs;
        maxSum = Math.Max(subSum, maxSum);
        return root.val + Math.Max(ls, rs);
    }
}