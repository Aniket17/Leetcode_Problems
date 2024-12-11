public class Solution {
    public bool[] IsArraySpecial(int[] nums, int[][] queries) {
        var badIndices = new List<int>();
        for(int i = 1; i < nums.Length; i++){
            if(nums[i] % 2 == nums[i-1] % 2) badIndices.Add(i);
        }
        var ans = new bool[queries.Length];
        var j = 0;
        foreach(var q in queries){
            int start = q[0], end = q[1];
            var hasBadIndex = HasBadIndex(start+1, end, badIndices);
            ans[j++] = !hasBadIndex;
        }
        return ans;
    }

    bool HasBadIndex(int start, int end, List<int> badIndices){
        int low = 0, high = badIndices.Count - 1;
        while(low <= high){
            var mid = low + (high - low)/2;
            var bad = badIndices[mid];
            if(bad < start){
                low = mid + 1;
            }else if(bad > end){
                high = mid - 1;
            }else{
                return true;
            }
        }
        return false;
    }
}

/*
[3,4,1,2,6]
[1,0,1,0,0]

*/