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
    int maxSum = 0;
    public int DiameterOfBinaryTree(TreeNode root) {
        if(root.left == null && root.right == null) return 0;
        GetHeight(root);
        return maxSum;
    }
    
    public int GetHeight(TreeNode node){
        if(node == null) return 0;
        var lh = GetHeight(node.left);
        var rh = GetHeight(node.right);
        var subSum = lh + rh;
        maxSum = Math.Max(maxSum, subSum);
        return 1 + Math.Max(lh, rh);
    }
}