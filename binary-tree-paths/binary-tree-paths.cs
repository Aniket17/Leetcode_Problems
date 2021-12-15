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
    public IList<string> BinaryTreePaths(TreeNode root) {
        if(root.left == null && root.right == null){
            return new List<string>(){root.val.ToString()};
        }
        var list = new List<string>();
        if(root.left != null){
            Dfs(root.left, root.val.ToString(), list);
        }
        if(root.right != null){
            Dfs(root.right, root.val.ToString(), list);
        }
        return list;
    }
    
    private void Dfs(TreeNode root, string path, List<string> ans){
        if(root.right == null && root.left == null){
            ans.Add(path + "->" + root.val);
            return;
        }
        if(root.left != null) Dfs(root.left, path + "->" + root.val, ans);
        if(root.right != null) Dfs(root.right, path + "->" + root.val, ans);
    }
}