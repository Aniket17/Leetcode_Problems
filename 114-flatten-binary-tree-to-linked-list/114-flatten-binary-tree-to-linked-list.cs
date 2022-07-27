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
    public void Flatten(TreeNode root) {
        if(root == null) return;
        FlattenUtil(root);
    }
    public TreeNode FlattenUtil(TreeNode node){
        if(node == null) return node;
        if(node.right == null && node.left == null) return node;
        
        var left = FlattenUtil(node.left);
        var right = FlattenUtil(node.right);
        
        if(left != null){
            left.right = node.right;
            node.right = node.left;
            node.left = null;
        }
        return right == null ? left : right;
    }
}