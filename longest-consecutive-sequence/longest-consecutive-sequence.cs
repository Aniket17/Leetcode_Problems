public class Solution {
    public int LongestConsecutive(int[] nums) {
        var set = new HashSet<int>();
        foreach(var n in nums){ 
            set.Add(n);
        }
        
        var longestStreak = 0;
        foreach(var num in nums){
            if(!set.Contains(num - 1)){
                //skip till we get to first number of sequence
                var streak = 1;
                var current = num;
                while(set.Contains(current + 1)){
                    current++;
                    streak++;
                }
                
                longestStreak = Math.Max(longestStreak, streak);
            }
        }
        return longestStreak;
    }
}


/*
[100,4,200,1,3,2]





3   3
2   2       



[3,2]
*/