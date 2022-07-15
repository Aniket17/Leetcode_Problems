/*
no math, just recurse with memo
*/
public class Solution {
    Dictionary<string, int> memo = new Dictionary<string, int>();
    int MOD = (int)Math.Pow(10, 9) + 7;
    public int NumRollsToTarget(int n, int k, int target) {
        if(target > n * k || target < n){
            return 0;
        }
        if(n == 1){
            return target <= k ? 1: 0;
        }
        var key = $"{n},{target}";
        if(memo.ContainsKey(key)) return memo[key];
        var sum = 0;
        for(int i = 1; i <= k; i++){
            sum += NumRollsToTarget(n - 1, k, target - i);
            sum %= MOD;
        }
        return memo[key] = sum;
    }
}