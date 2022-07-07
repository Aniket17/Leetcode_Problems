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

/*
3,2,4,1,4,2,3
2,3,1,2,3
*/
public class Solution {
    public bool IsSymmetric(TreeNode root) {
        if(root == null) return true;
        return IsSame(root.left, root.right);
    }
    public bool IsSame(TreeNode left, TreeNode right){
        if(left == null && right == null) return true;
        if(left == null || right == null) return false;
        return left.val == right.val 
            && IsSame(left.left, right.right) 
            && IsSame(left.right, right.left);
    }
}