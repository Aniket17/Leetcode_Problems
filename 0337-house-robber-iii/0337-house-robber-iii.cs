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
    Dictionary<(TreeNode, bool), int> memo = new();
    public int Rob(TreeNode root) {
        //if i rob the parent, i cant rob the children
        //dp(root, parent) = max(root.val + dp(root.left, root) + root.val + dp(root.right, root),
        //or dp(root.left, parent) + dp(root.right, parent))
        var ifRootRobbed = Rob(root, true);
        var ifRootNotRobbed = Rob(root, false);
        return Math.Max(ifRootRobbed, ifRootNotRobbed);
    }

    int Rob(TreeNode node, bool isParentRobbed){
        if(node == null) return 0;
        if(memo.ContainsKey((node, isParentRobbed))) return memo[(node, isParentRobbed)];
        var result1 = 0;
        var result2 = 0;
        if(!isParentRobbed){
            //dont rob the children
            result2 = node.val + Rob(node.left, true) + Rob(node.right, true); //3
        }
        //dont rob at all
        result1 = Rob(node.left, false) + Rob(node.right, false); //3
        return memo[(node, isParentRobbed)] = Math.Max(result1, result2);
    }
}