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
    Dictionary<int, int> map;
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        map = new Dictionary<int, int>();
        for(int i = 0; i < inorder.Length; i++){
            map[inorder[i]] = i;
        }
        return Construct(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
    }
    
    TreeNode Construct(int[] preorder, int pstart, int pend, int[] inorder, int istart, int iend){
        if(pstart > pend || istart > iend) return null;
        
        var root = new TreeNode(preorder[pstart]);
        
        // map[preorder[pstart]] - istart
        
        root.left = Construct(preorder, pstart+1, pstart + map[preorder[pstart]] - istart, inorder, istart, map[preorder[pstart]] - 1);
        root.right = Construct(preorder, pstart + map[preorder[pstart]] - istart + 1, pend, inorder, map[preorder[pstart]]+1, iend);
        return root;
    }
}