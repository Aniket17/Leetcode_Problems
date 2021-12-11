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
       try{
           GetLevel(root);
       }catch{
           return false;
       }
        return true;
    }
    
    private int GetLevel(TreeNode node){
        if(node == null){
            return 0;
        }
        var leftLevel = 1 + GetLevel(node.left);
        var rightLevel = 1 + GetLevel(node.right);
        if(Math.Abs(leftLevel - rightLevel) > 1){
            throw new Exception();
        }
        return Math.Max(leftLevel, rightLevel);
    }
}