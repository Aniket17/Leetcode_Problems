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
    List<string> ans = new List<string>();
    public int SumNumbers(TreeNode root) {
        if(root == null) return 0;
        Dfs(root, "");
        return ans.Select(int.Parse).Sum();
    }
    
    void Dfs(TreeNode node, string curr){
        if(node == null) return;
        if(node.right == null && node.left == null){
            ans.Add(curr + node.val.ToString());
            return;
        }
        Dfs(node.left, curr + node.val.ToString());
        Dfs(node.right, curr + node.val.ToString());
    }
}