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
    public bool IsBalanced(TreeNode root) {
        if(root == null){
            return true;
        }
        return Math.Abs(GetLevel(root.right) - GetLevel(root.left)) < 2 
            && IsBalanced(root.left) && IsBalanced(root.right);
    }
    
    private int GetLevel(TreeNode node){
        if(node == null){
            return 0;
        }
        var leftLevel = 1 + GetLevel(node.left);
        var rightLevel = 1 + GetLevel(node.right);
        return Math.Max(leftLevel, rightLevel);
    }
}