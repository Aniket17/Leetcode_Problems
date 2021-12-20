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
            var k = queue.Count;
            var list = new List<int>();
            while(k-- != 0){
                var node = queue.Dequeue();
                if(node != null){
                    list.Add(node.val);
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
            }
            if(queue.Count != 0) ans.Add(list);
        }
        return ans;
    }
}