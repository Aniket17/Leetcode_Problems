public class Solution {
    public IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper) {
        var n = nums.Length;
        var ranges = new List<IList<int>>();
        if(n == 0){
            ranges.Add(new List<int>(){lower, upper});
            return ranges;
        }
        var left = nums[0];
        var right = nums[n - 1];
        

        if(left != lower){
            ranges.Add(new List<int>(){lower, left-1});
        }
        
        for(int i = 0; i < n - 1; i++){
            if(nums[i]+1 == nums[i+1]) continue;
            //found range element
            var newRange = new List<int>(){nums[i]+1, nums[i+1]-1};
            ranges.Add(newRange);
        }
        if(right != upper){
            ranges.Add(new List<int>(){right+1, upper});
        }
        return ranges;
    }
}
/*
[0,1,3,50,75,99]

*/