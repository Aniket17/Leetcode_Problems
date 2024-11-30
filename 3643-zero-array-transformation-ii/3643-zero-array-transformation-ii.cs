public class Solution {
    public int MinZeroArray(int[] nums, int[][] queries) {
        var n = nums.Length;

        bool CanZeroArray(int k){
            var diff = new int[n + 1];
            for(int i = 0; i < k; i++){
                var query = queries[i];
                var li = query[0];
                var ri = query[1];

                diff[li] += query[2];
                if(ri + 1 < diff.Length){
                    diff[ri + 1] -= query[2];
                }
            }

            //calc prefix sum
            for(int i = 1; i < n; i++){
                diff[i] += diff[i-1];
            }

            for(int i = 0; i < n; i++){
                if(nums[i] > diff[i]) return false;
            }
            return true;
        }
        int low = 0, high = queries.Length, result = -1;
        while(low <= high){
            var mid = low + (high - low)/2;
            if(CanZeroArray(mid)){
                result = mid;
                high = mid - 1;
            }else{
                low = mid + 1;
            }
        }
        return result;
    }
}