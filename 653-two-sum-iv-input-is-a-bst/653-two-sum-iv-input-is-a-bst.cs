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
    public bool FindTarget(TreeNode root, int k) {
        var set = new HashSet<int>();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while(queue.Count != 0){
            var node = queue.Dequeue();
            var target = k - node.val;
            if(set.Contains(target)) return true;
            set.Add(node.val);
            if(node.left != null){
                queue.Enqueue(node.left);
            }
            if(node.right != null){
                queue.Enqueue(node.right);
            }
        }
        return false;
    }
}