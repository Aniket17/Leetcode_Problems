/*
[1,3,4,2]



*/
public class Solution {
    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        var map = new Dictionary<int, int>();
        for(int i = 0; i < nums2.Length; i++){
            map[nums2[i]] = i;
        }
        var result = new int[nums1.Length];
        int j = 0;
        foreach(var num in nums1){
            var ind = map[num];
            result[j++] = GetNextGreater(nums2, ind, num);
        }
        return result;
    }
    
    int GetNextGreater(int[] nums, int pos, int target){
        for(int i = pos + 1; i < nums.Length; i++){
            if(nums[i] > target) return nums[i];
        }
        return -1;
    }
}