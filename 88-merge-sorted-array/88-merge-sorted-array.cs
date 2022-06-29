/*
two pointer approach
loop over till i < m and j < n, k will track the index to be inserted
cases: m != n break when (i < m and j < n) and fill in rest of the elements sequentially

*/

public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        int i = 0;
        int j = 0;
        int k = 0;
        int[] result = new int[nums1.Length];
        
        while(i < m && j < n){
            if(nums1[i] < nums2[j]){
                result[k++] = nums1[i++];
            }else if(nums1[i] > nums2[j]){
                result[k++] = nums2[j++];
            }else{
                result[k++] = nums1[i++];
                result[k++] = nums2[j++];
            }
        }
        while(i != m){
            result[k++] = nums1[i++];
        }
        
        while(j != n){
            result[k++] = nums2[j++];
        }
        
        for(int ct = 0; ct < result.Length; ct++){
            nums1[ct] = result[ct];
        }
    }
}