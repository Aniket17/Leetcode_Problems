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
    public bool TwoSumBSTs(TreeNode root1, TreeNode root2, int target) {
        // put all the nodes in set while searching for other node
        var set1 = new HashSet<int>();
        var set2 = new HashSet<int>();
        Inorder(root1, set1);
        Inorder(root2, set2);
        foreach(var num in set1){
            if(set2.Contains(target - num)) return true;
        }
        return false;
    }
    
    private void Inorder(TreeNode root, HashSet<int> set){
        if(root == null) return;
        Inorder(root.left, set);
        set.Add(root.val);
        Inorder(root.right, set);
    }
}