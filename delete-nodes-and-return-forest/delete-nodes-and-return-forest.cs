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
    public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete) {
        if(root == null || to_delete.Length == 0) return new List<TreeNode>(){root};
        var deletes = to_delete.ToHashSet();
        var queue = new Queue<TreeNode>();
        var ans = new List<TreeNode>();
        var parentMap = new Dictionary<int, TreeNode>();
        parentMap.Add(root.val, null);
        queue.Enqueue(root);
        if(!deletes.Contains(root.val)) ans.Add(root);
        
        while(queue.Any()){
            var node = queue.Dequeue();
            if(deletes.Contains(node.val)){
                //detach parent node
                var parent = parentMap[node.val];
                if(node.left != null && !deletes.Contains(node.left.val)) ans.Add(node.left);
                if(node.right != null && !deletes.Contains(node.right.val)) ans.Add(node.right);
                DetachParent(parent, node.val);
            }
            if(node.left != null){
                queue.Enqueue(node.left);
                parentMap.Add(node.left.val, node);
            }
            if(node.right != null) {
                queue.Enqueue(node.right);
                parentMap.Add(node.right.val, node);
            }
            
        }
        return ans;
    }
    
    private void DetachParent(TreeNode parent, int val){
        if(parent == null) return;
        if(parent.left?.val == val){
            parent.left = null;
        }else{
            parent.right = null;
        }
    }
}