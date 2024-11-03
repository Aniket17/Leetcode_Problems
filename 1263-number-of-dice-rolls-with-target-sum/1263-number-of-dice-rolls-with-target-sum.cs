public class Solution {
    int[][] memo;
    public int NumRollsToTarget(int n, int k, int target) {
        memo = new int[n+1][];
        for(int i = 0; i <= n; i++){
            memo[i] = new int[target+1];
            Array.Fill(memo[i], -1);
        }
        return NumRolls(0,n,k,target,0);
    }

    int NumRolls(int dice, int n, int k, int target, int curr){
        if(dice == n){
            return curr == target ? 1 : 0;
        }
        if(memo[dice][curr] != -1) return memo[dice][curr];
        int mod = 7 + (int)Math.Pow(10,9);
        var ans = 0;
        for(int j = 1; j <= Math.Min(target-curr, k); j++){
            ans = (ans + NumRolls(dice+1, n, k, target, curr+j))%mod;
        }
        return memo[dice][curr] = ans;
    }
}