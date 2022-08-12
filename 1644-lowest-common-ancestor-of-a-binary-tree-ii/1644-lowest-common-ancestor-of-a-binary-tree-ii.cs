/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    bool foundP;
    bool foundQ;
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        var res = SearchLCA(root, p.val, q.val);
        if(foundP && foundQ){
            return res;
        }
        return null;
    }
    private TreeNode SearchLCA(TreeNode node, int p, int q) {
        if(node == null) {
            return null;
        }
        
        TreeNode left = SearchLCA(node.left, p, q);
        TreeNode right = SearchLCA(node.right, p, q);
        
        if(left != null && right != null) {
            return node;
        }
        
        if(node.val == p) {
            foundP = true;
            return node;
        }
        if(node.val == q) {
            foundQ = true;
            return node;
        }
        
        return left != null ? left : right;
    }
}