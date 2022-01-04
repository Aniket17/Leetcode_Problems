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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode[] nodes) {
        var targets = nodes.ToHashSet();
        return Dfs(root, targets);
    }
    
    public TreeNode Dfs(TreeNode root, HashSet<TreeNode> targets) {
        if(root == null) return null;
                
        if(targets.Contains(root)){
            return root;
        }
        var left = Dfs(root.left, targets);
        var right = Dfs(root.right, targets);
        if(left != null && right != null){
            return root;
        }else if(left == null){
            return right;
        }else{
            return left;
        }
    }
}