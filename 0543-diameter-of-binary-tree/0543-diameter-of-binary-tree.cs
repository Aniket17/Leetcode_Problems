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
    int max = int.MinValue;
    public int DiameterOfBinaryTree(TreeNode root) {
        Explore(root);
        return max;
    }

    int Explore(TreeNode root){
        if(root == null) return 0;
        var left = Explore(root.left);
        var right = Explore(root.right);
        max = Math.Max(max, left+right);
        return 1 + Math.Max(left, right);
    }
}