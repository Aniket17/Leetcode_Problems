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
    public IList<IList<int>> LevelOrder(TreeNode root) {
        var ans = new List<IList<int>>();
        if(root == null) return ans;
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while(queue.Count != 0){
            var count = queue.Count;
            var nodes = new List<int>();
            while(count-- > 0){
                var node = queue.Dequeue();
                nodes.Add(node.val);
                if(node.left != null) queue.Enqueue(node.left);
                if(node.right != null) queue.Enqueue(node.right);
            }
            ans.Add(nodes);
        }
        return ans;
    }
}