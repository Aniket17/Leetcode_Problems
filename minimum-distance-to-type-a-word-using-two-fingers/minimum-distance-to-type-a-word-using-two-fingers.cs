public class Solution {
    private const int m = 6;
    private const int n = 6;
    public int MinimumDistance(string word) {
        var memo = new Dictionary<string, int>();
        return Solve(word, '\0', '\0', 0, memo);
    }
    
    private int Solve(string word, char f1, char f2, int i, Dictionary<string, int> memo){
        // base case
        if(i == word.Length){ return 0;}
        var key = $"{f1}, {f2}, {i}";
        if(memo.ContainsKey(key)){
            return memo[key];
        }
        
        var chooseF1 = GetDistance(f1, word[i]) + Solve(word, word[i], f2, i + 1, memo);
        var chooseF2 = GetDistance(f2, word[i]) + Solve(word, f1, word[i], i + 1, memo);
        return memo[key] = Math.Min(chooseF1, chooseF2);
    }
    
    
    private int GetDistance(char c1, char c2){
        if(c1 == '\0' || c2 == '\0') return 0;
        var pos1 = GetPos(c1);
        var pos2 = GetPos(c2);
        return Math.Abs(pos1[0] - pos2[0]) + Math.Abs(pos1[1] - pos2[1]);
    }
    private int[] GetPos(char c){
        var id = (int)c;
        // Console.WriteLine(c);
        // Console.WriteLine(id);
        id -= 65;
        var row = id / m;
        var col = id % n;
        return new int[2]{row, col};
    }
}

// use ascii set
/* m = 5 n = 6

idx = i * n + j

pos = 78 => (-65) -> 13 => val/m, val%n [2, 1] 

0   -> 65 - 71   
1   -> 
2
3
4

            CAKE
        AKE
  C    0  0   
  A   2 0 0  2
      
*/