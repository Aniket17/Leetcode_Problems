public class Solution {
    int[] memo;
    public int DeleteAndEarn(int[] nums) {
        Dictionary<int, int> counts = new();
        var memoSize = 0;
        foreach(var n in nums){
            memoSize = Math.Max(memoSize, n);
            counts[n] = n + counts.GetValueOrDefault(n);
        }
        memo = new int[memoSize + 1];
        Array.Fill(memo, -1);
        
        return MaxPoints(counts, memoSize);
    }
    
    private int MaxPoints(Dictionary<int, int> counts, int key){
        if(memo[key] != -1) return memo[key];
        if(key == 0) return 0;
        
        var profit = counts.GetValueOrDefault(key);
        if(key == 1) return profit;
        
        var take = profit + MaxPoints(counts, key - 2);
        var dontTake = MaxPoints(counts, key - 1);
        
        return memo[key] = Math.Max(dontTake, take);
    }
}