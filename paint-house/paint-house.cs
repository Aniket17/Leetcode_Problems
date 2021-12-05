public class Solution {
    Dictionary<string, int> memo;
    public int MinCost(int[][] costs) {
        if(costs.Length == 0) return 0;
        memo = new Dictionary<string, int>();
        var color1 = Math.Min(MinCost(costs, 0, 0), MinCost(costs, 0, 1));
        var color2 = Math.Min(MinCost(costs, 0, 2), color1);
        return color2;
    }
    
    private int MinCost(int[][] costs, int house, int color){
        if(house == costs.Length) return 0;
        var ans = 0;
        int color1 = 0;
        int color2 = 0;
        if(memo.ContainsKey($"{house},{color}")) return memo[$"{house},{color}"];
        switch(color){
            case 0:
                color1 = MinCost(costs, house + 1, 1) + costs[house][1];
                color2 = MinCost(costs, house + 1, 2) + costs[house][2];
                break;
            case 1:
                color1 = MinCost(costs, house + 1, 0) + costs[house][0];
                color2 = MinCost(costs, house + 1, 2) +  costs[house][2];
                break;
            case 2:
                color1 = MinCost(costs, house + 1, 0) + costs[house][0];
                color2 = MinCost(costs, house + 1, 1) + costs[house][1];
                break;
        }
        memo[$"{house},{color}"] = Math.Min(color1, color2);
        return memo[$"{house},{color}"];
    }
}


/*
[17,2,17]
[16,16,5]
[14,3,19]
*/