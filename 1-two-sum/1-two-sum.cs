public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var map = new Dictionary<int, int>();
        for(int i = 0; i < nums.Length; i++){
            var val = target - nums[i];
            if(map.ContainsKey(val)){
                return new int[2]{i, map[val]};
            }
            map[nums[i]] = i;
        }
        return new int[2]{-1,-1};
    }
}

/*
Input: nums = [2,7,11,15], target = 9

map = {
7: [0],
2: [1],
-2: [2],
-6: [3]
}

*/