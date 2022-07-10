public class Solution {
    public int FindMaxForm(string[] strs, int m, int n) {
        var map = new Dictionary<int, int[]>();
        var index = 0;
        foreach(var str in strs){
            var ones = str.Count(x=>x == '1');
            var zeros = str.Length - ones;
            map[index++] = new int[]{zeros, ones};
        }
        var memo = new Dictionary<string, int>();
        return Solve(map, 0, m, n, memo);
    }
    
    private int Solve(Dictionary<int, int[]> map, int pos, int m, int n, Dictionary<string, int> memo){
        if(pos == map.Count){
            return 0;
        }
        
        var key = $"{pos},{m},{n}";
        if(memo.ContainsKey(key)) return memo[key];
        
        var zeros = map[pos][0];
        var ones = map[pos][1];
        var taken = -1;
        if(m - zeros >= 0 && n - ones >= 0){
            taken = 1 + Solve(map, pos + 1, m - zeros, n - ones, memo);
        }
        var notTaken = Solve(map, pos + 1, m, n, memo);
        return memo[key] = Math.Max(taken, notTaken);
    }
}

/*
base case 
pos == len
store max

map[index, [0s, 1s]]

include -> minus 0s from m and minus 1s from n and add 1
do not include -> keep m and n but increase pos
*/