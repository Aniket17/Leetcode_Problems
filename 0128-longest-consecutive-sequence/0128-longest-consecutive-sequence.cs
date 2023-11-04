public class Solution {
    public int LongestConsecutive(int[] nums) {
        var set = nums.ToHashSet();
        int longest = 0;
        foreach(var num in nums){
            if(set.Contains(num-1)){
                //we will start from here when num-1 presents itself
                continue;
            }
            var curr = num;
            var streak = 1;
            while(set.Contains(curr+1)){
                 curr++;
                 streak++;   
            }
            longest = Math.Max(longest, streak);
        }
        return longest;
    }
}