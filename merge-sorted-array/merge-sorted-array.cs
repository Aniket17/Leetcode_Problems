public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        // m + n algorithm with O(1) space
        var i = m - 1;
        var j = n - 1;
        var k = m + n - 1;
        while(i >= 0 && j >= 0){
            if(nums1[i] > nums2[j]){
                nums1[k] = nums1[i];
                i--;
            }else if(nums1[i] < nums2[j]){
                nums1[k] = nums2[j];
                j--;
            }else{
                nums1[k--] = nums1[i];
                nums1[k] = nums2[j];
                i--;
                j--;
            }
            k--;
        }
        while(i >= 0){
            nums1[k--] = nums1[i--];
        }
        while(j >= 0){
            nums1[k--] = nums2[j--];
        }
    }
}

/*
[1,2,3,0,0,0]
[2,5,6]

[1,2,2,3,3,5,6]

[5,6,7,0,0,0]
[1,2,3]

[1,2,3,5,6,7]

*/