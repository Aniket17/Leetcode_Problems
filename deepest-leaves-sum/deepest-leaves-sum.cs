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
    private int sum = 0;
    private int maxLevel = 0;
    public int DeepestLeavesSum(TreeNode root) {
        Dfs(root, 0);
        return sum;
    }
    
    private void Dfs(TreeNode node, int currentLevel){
        // base condition
        if(node.right == null && node.left == null){
            // leaf
            // Console.WriteLine($"{node.val}, {currentLevel}, {maxLevel}");
            if(currentLevel > maxLevel){
                //update the sum
                sum = node.val;
                maxLevel = currentLevel;
            }else if(currentLevel == maxLevel){
                sum += node.val;
            }
            return;
        }
        
        if(node.right != null) Dfs(node.right, currentLevel + 1);
        if(node.left != null) Dfs(node.left, currentLevel + 1);
        maxLevel = Math.Max(currentLevel, maxLevel);
        return;
    }
    
    /*
    DFS => root, currentLevel
    // when branch currentLevel + 1
    // base condition => leaf node => store the value of max level
    */
}