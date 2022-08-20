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
    private List<IList<int>> solution;
    
    private int GetHeight(TreeNode root) {
        // return -1 for null nodes
        if (root == null) {
            return -1;
        }
        
        // first calculate the height of the left and right children
        int leftHeight = GetHeight(root.left);
        int rightHeight = GetHeight(root.right);
        
        int currHeight = Math.Max(leftHeight, rightHeight) + 1;
        
        if (this.solution.Count == currHeight) {
            this.solution.Add(new List<int>());
        }
        
        this.solution[currHeight].Add(root.val);
        
        return currHeight;
    }
    
    public IList<IList<int>> FindLeaves(TreeNode root) {
        this.solution = new();
        
        GetHeight(root);
        
        return this.solution;
    }
}