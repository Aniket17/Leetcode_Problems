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
    public TreeNode InvertTree(TreeNode root) {
        if(root == null) return root;
        if(root.left == null && root.right == null) return root;
        var tmp = root.right;
        root.right = root.left;
        root.left = tmp;
        InvertTree(root.left);
        InvertTree(root.right);
        return root;
    }
}