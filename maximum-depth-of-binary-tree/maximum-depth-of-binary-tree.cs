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
    public int MaxDepth(TreeNode root) {
        //get right longest
        //get left longest
        //return max+1
        if(root == null) return 0;
        if(root.left == null && root.right == null) return 1;
        var leftMax = MaxDepth(root.left);
        var rightMax = MaxDepth(root.right);
        return 1 + Math.Max(leftMax, rightMax);
    }
}