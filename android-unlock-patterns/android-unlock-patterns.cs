public class Solution {
    Dictionary<string, int> skips;
    public int NumberOfPatterns(int m, int n) {
        skips = new Dictionary<string, int>();
        skips.Add("1,3",2);
        skips.Add("3,1",2);
        skips.Add("1,7",4);
        skips.Add("7,1",4);
        skips.Add("3,9",6);
        skips.Add("9,3",6);
        skips.Add("7,9",8);
        skips.Add("9,7",8);
        
        skips.Add("1,9",5);
        skips.Add("9,1",5);
        skips.Add("3,7",5);
        skips.Add("7,3",5);
        skips.Add("2,8",5);
        skips.Add("8,2",5);
        skips.Add("4,6",5);
        skips.Add("6,4",5);
        
        var ans = 0;
        
        for(int i = m; i < n + 1; i++){
            for(int start = 1; start < 10; start++){
                var seen = new HashSet<int>(){start};
                ans += Backtrack(start, i - 1, seen);
            }
        }
        return ans;
    }
    
    private int Backtrack(int curr, int remain, HashSet<int> seen){
        if(remain == 0){
            return 1;
        }
        
        var ans = 0;
        
        for(int i = 1; i < 10; i++){
            if(!seen.Contains(i) && (!skips.ContainsKey($"{curr},{i}") || seen.Contains(skips[$"{curr},{i}"])) ){
                seen.Add(i);
                ans += Backtrack(i, remain - 1, seen);
                seen.Remove(i);
            }
        }
        return ans;
    }
}