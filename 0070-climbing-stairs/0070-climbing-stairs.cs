public class Solution {
    Dictionary<int, int> cache = new();
    public int ClimbStairs(int n) {
        // base case
        if(n <= 0) return 0;
        if(n == 1) return 1;
        if(n == 2) return 2;
        if(cache.ContainsKey(n)) return cache[n];
        // decision tree
        var climb1 = ClimbStairs(n-1);
        var climb2 = ClimbStairs(n-2);
        // cache
        cache[n] = climb1 + climb2;
        return cache[n];
    }
}