public class Solution {
    int[] memo;
    public int MinCostClimbingStairs(int[] cost) {
        memo = new int[cost.Length];
        Array.Fill(memo, -1);
        var startAt0 = Climb(cost, 0);
        var startAt1 = Climb(cost, 1);
        return Math.Min(startAt0, startAt1);
    }
    
    private int Climb(int[] costs, int pos){
        if(pos >= costs.Length) return 0;
        if(memo[pos] != -1) return memo[pos];
        //climb 1 or climb 2
        var climb1 = costs[pos] + Climb(costs, pos + 1);
        var climb2 = costs[pos] + Climb(costs, pos + 2);
        return memo[pos] = Math.Min(climb1, climb2);
    }
}