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
    public TreeNode SortedArrayToBST(int[] nums) {
        var low = 0; var high = nums.Length - 1;
        return ConstructTree(nums, low, high);
    }
    
    public TreeNode ConstructTree(int[] nums, int low, int high){
        if(low > high) return null;
        var mid = low + (high - low)/2;
        var node = new TreeNode(nums[mid]);
        node.left = ConstructTree(nums, low, mid - 1);
        node.right = ConstructTree(nums, mid + 1, high);
        return node;
    }
}