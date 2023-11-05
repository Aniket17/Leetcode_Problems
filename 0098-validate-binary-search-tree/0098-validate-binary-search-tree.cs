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
    public bool IsValidBST(TreeNode root, int? low = null, int? high = null) {
        if(root == null) return true;
        
        if((low.HasValue && root.val <= low) || (high.HasValue && root.val >= high)){
            return false;
        }
        
        return IsValidBST(root.right, root.val, high) && IsValidBST(root.left, low, root.val);
    }
}