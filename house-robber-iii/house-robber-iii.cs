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
    public int Rob(TreeNode root) {
        if(root == null) return 0;
        int[] answer = Helper(root);
        return Math.Max(answer[0], answer[1]);
    }
    
    public int[] Helper(TreeNode node) {
        // return [rob this node, not rob this node]
        if (node == null) {
            return new int[] { 0, 0 };
        }
        int[] left = Helper(node.left);
        int[] right = Helper(node.right);
        // if we rob this node, we cannot rob its children
        int rob = node.val + left[1] + right[1];
        // else, we free to choose rob its children or not
        int notRob = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);

        return new int[] { rob, notRob };
    }

}