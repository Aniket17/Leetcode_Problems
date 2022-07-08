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
public class BSTIterator {
    Stack<TreeNode> stack;
    public BSTIterator(TreeNode root){
        stack = new Stack<TreeNode>();
        PushAll(root);
    }
        
    
    public int Next() {
        if(stack.Count == 0) return -1;
        var el = stack.Pop();
        if(el.right != null) PushAll(el.right);
        return el.val;
    }
    
    public bool HasNext() {
        return stack.Count != 0;
    }
    void PushAll(TreeNode node){
        if(node == null) return;
        var temp = node;
        while(temp != null){
            stack.Push(temp);
            temp = temp.left;
        }
    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */