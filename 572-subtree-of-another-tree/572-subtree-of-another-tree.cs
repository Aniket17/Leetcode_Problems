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
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        if(root == null && subRoot == null) return true;
        if(root == null || subRoot == null) return false;
        
        if(IsSame(root, subRoot)){
            return true;
        }
        if(IsSubtree(root.left, subRoot)) return true;
        if(IsSubtree(root.right, subRoot)) return true;
        
        return false;
    }
    
    private bool IsSame(TreeNode root, TreeNode subRoot){
        if(root == null && subRoot == null) return true;
        if(root == null || subRoot == null) return false;
        return root.val == subRoot.val 
            && IsSame(root.left, subRoot.left) 
            && IsSame(root.right, subRoot.right);
    }
}