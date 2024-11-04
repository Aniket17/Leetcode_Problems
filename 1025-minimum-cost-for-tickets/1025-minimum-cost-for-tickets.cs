public class Solution {
    int[] dp = new int[366];
    int lastDay;
    public int MincostTickets(int[] days, int[] costs) {
        //if particular ith day isnt a travel day,
        //cost of traveling from that day until the last travel day is same as (i+1)th day
        Array.Fill(dp, -1);
        var daysSet = days.ToHashSet();
        lastDay = days.Last();
        return MinCostUtil(daysSet, costs, days[0]);
    }

    int MinCostUtil(HashSet<int> travelDays, int[] costs, int day){
        if(day > lastDay) return 0;
        if(dp[day] != -1) return dp[day];
        if(!travelDays.Contains(day)){
            dp[day] = MinCostUtil(travelDays, costs, day + 1);
        }else{
            var day1Pass = costs[0] + MinCostUtil(travelDays, costs, day + 1);
            var day7Pass = costs[1] + MinCostUtil(travelDays, costs, day + 7);
            var day30Pass = costs[2] + MinCostUtil(travelDays, costs, day + 30);
            dp[day] = Math.Min(day30Pass, Math.Min(day1Pass, day7Pass));
        }
        return dp[day];
    }
}