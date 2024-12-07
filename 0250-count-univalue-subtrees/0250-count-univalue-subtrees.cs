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
    int count = 0;
    public int CountUnivalSubtrees(TreeNode root) {
        dfs(root);
        return count;
    }

    public bool dfs(TreeNode node) {
        if (node == null) {
            return true;
        }

        bool left = dfs(node.left);
        bool right = dfs(node.right);

        // If both the children form uni-value subtrees, we compare the value of
        // chidren's node with the node value.
        if (left && right) {
            if (node.left != null && node.left.val != node.val) {
                return false;
            }
            if (node.right != null && node.right.val != node.val) {
                return false;
            }
            count++;
            return true;
        }
        // Else if any of the child does not form a uni-value subtree, the subtree
        // rooted at node cannot be a uni-value subtree.
        return false;
    }
}