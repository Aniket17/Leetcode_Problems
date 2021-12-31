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
    int maxDiff = int.MinValue;
    
    public int MaxAncestorDiff(TreeNode root) {
        if(root == null) return 0;
        Dfs(root, root.val, root.val);
        return maxDiff;
    }
    
    void Dfs(TreeNode node, int currMax, int currMin){
        if(node == null){
            return;
        }
        var res = Math.Max(Math.Abs(currMin - node.val), Math.Abs(currMax - node.val));
        maxDiff = Math.Max(maxDiff, res);
        
        currMax = Math.Max(currMax, node.val);
        currMin = Math.Min(currMin, node.val);
        Dfs(node.left, currMax, currMin);
        Dfs(node.right, currMax, currMin);
    }
}

/*

                  8
             3        10
           1    6         14
              4   7     13 
*/