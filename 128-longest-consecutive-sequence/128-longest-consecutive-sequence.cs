public class Solution {
    public int LongestConsecutive(int[] nums) {
        var set = new HashSet<int>();
        foreach(var n in nums){ 
            set.Add(n);
        }
        var longestStreak = 0;
        foreach(var num in nums){
            if(!set.Contains(num - 1)){
                //go further till end
                var current = num;
                while(set.Contains(current + 1)){
                    current++;
                }
                longestStreak = Math.Max(longestStreak, current - num + 1);
            }
        }
        return longestStreak;
    }
}