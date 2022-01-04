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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        var ans = new List<IList<int>>();
        if(root == null) return ans;
        var leftToRight = true;
        
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while(queue.Count != 0){
            var size = queue.Count;
            var row = new int[size];
            for(int index = 0; index < size; index++){
                var node = queue.Dequeue();
                var zIndex = leftToRight ? index : size - index - 1;
                row[zIndex] = node.val;
                if(node.left != null) queue.Enqueue(node.left);
                if(node.right != null) queue.Enqueue(node.right);
            }
            ans.Add(row.ToList());
            leftToRight = !leftToRight;
        }
        return ans;
    }
}