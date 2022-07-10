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
    public int CountNodes(TreeNode root) {
        if(root == null) return 0;
        var lh = GetLeftHeight(root);
        var rh = GetRightHeight(root);
        if(lh == rh){
            //perfect binary tree
            return (int)Math.Pow(2, lh) - 1;//-1 because at root level there's only one node
        }
        //otherwise do same for left and right
        return 1 + CountNodes(root.left) + CountNodes(root.right);// +1 to count root/current node
    }
    
    private int GetLeftHeight(TreeNode node){
        if(node == null) return 0;
        return 1 + GetLeftHeight(node.left);
    }
    
    private int GetRightHeight(TreeNode node){
        if(node == null) return 0;
        return 1 + GetRightHeight(node.right);
    }
}