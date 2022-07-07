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
        if(root == null) return 0;
        var lh = ExplorePath(root.left);
        var rh = ExplorePath(root.right);
        var max = Math.Max(lh, rh);
        return 1 + max;
    }
    
    int ExplorePath(TreeNode root){
        if(root == null) return 0;
        var lh = ExplorePath(root.left);
        var rh = ExplorePath(root.right);
        var max = Math.Max(lh, rh);
        return 1 + max;
    }
}