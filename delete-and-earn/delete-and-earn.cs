public class Solution {
    int[] memo;
    int[] counts;
    public int DeleteAndEarn(int[] nums) {
        var memoSize = nums.Max(x=>x);
        counts = new int[memoSize + 1];
        
        memo = new int[memoSize + 1];
        Array.Fill(memo, -1);
        
        foreach(var n in nums){
            counts[n] += n;
        }

        return MaxPoints(memoSize);
    }
    
    private int MaxPoints(int key){
        if(memo[key] != -1) return memo[key];
        if(key == 0) return 0;
        
        var profit = counts[key];
        if(key == 1) return profit;
        
        var take = profit + MaxPoints(key - 2);
        var dontTake = MaxPoints(key - 1);
        
        return memo[key] = Math.Max(dontTake, take);
    }
}