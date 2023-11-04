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
map
100:1
100:1, 4:1
100:1, 4:1, 200:1
100:1, 4:1, 200:1 1:1
100:1, 4:1, 200:1 1:1 3:2
100:1, 4:1, 200:1 1:1 3:2 2:4

[0,3,7,2,5,8,4,6,0,1]
0:3, 3:1, 7:1, 2:2, 5:1, 8:2 ,4:4 ,6:6,1

*/