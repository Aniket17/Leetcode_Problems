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
        var list = new List<IList<int>>();
        if(root == null) return list;
        
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while(queue.Count != 0){
            var nodesAtLevel = queue.Count;
            var levelList = new List<int>();
            while(nodesAtLevel-- != 0){
                var node = queue.Dequeue();
                if(node.left != null){
                    queue.Enqueue(node.left);
                }
                if(node.right != null){
                    queue.Enqueue(node.right);
                }
                levelList.Add(node.val);
            }
            list.Add(levelList);
        }
        
        return list;
    }
}