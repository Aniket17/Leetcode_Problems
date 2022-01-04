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
public class Solution{
	public int CountNodes(TreeNode node){
		if(node == null) return 0;
		var lh = GetLeftHeight(node);
		var rh = GetRightHeight(node);
        if(lh == rh){
            return (int)Math.Pow(2, lh)  - 1;
        }
        return 1 + CountNodes(node.right) + CountNodes(node.left);
    }

    public int GetLeftHeight(TreeNode node){
        if(node == null) return 0;
        return GetLeftHeight(node.left) + 1;
    }
    public int GetRightHeight(TreeNode node){
        if(node == null) return 0;
        return GetRightHeight(node.right) + 1;
    }
}
