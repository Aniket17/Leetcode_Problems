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
    List<int> result;
    public int KthSmallest(TreeNode root, int k) {
        result = new List<int>();
        Explore(root, k);
        return result.Last();
    }
    void Explore(TreeNode node, int k){
        if(node == null || result.Count == k) return;
        Explore(node.left, k);
        if(result.Count < k){
            result.Add(node.val);
            Explore(node.right, k);
        }
    }
}