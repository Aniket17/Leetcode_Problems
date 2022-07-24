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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        var inMap = new Dictionary<int, int>();
        for(int i = 0; i < inorder.Length; i++){
            inMap[inorder[i]] = i;
        }
        var n = preorder.Length;
        return BuildTree(preorder, 0, n-1, inorder, 0, n-1, inMap);
    }
    
    TreeNode BuildTree(int[] preorder,int preStart,int preEnd,int[] inorder,int inStart,int inEnd,
                       Dictionary<int, int> map){
        if(inStart > inEnd) return null;
        var root = new TreeNode(preorder[preStart]);
        var mid = map[root.val];
        var remaining = mid - inStart;
        root.left = BuildTree(preorder, preStart+1,preStart+remaining, inorder, inStart, mid-1, map);
        root.right = BuildTree(preorder, preStart+remaining+1,preEnd, inorder, mid+1, inEnd, map);
        return root;
    }
}

/*
preorder= [3,9,20,15,7]
inorder = [9,3,15,20,7]
call ps pe is ie mid rem
0    0  4  0  4   1   1
1    2  4  2  4   3   1
*/