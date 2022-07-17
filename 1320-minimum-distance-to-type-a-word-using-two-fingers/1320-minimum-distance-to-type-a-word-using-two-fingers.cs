public class Solution {
    Dictionary<string, int> memo = new Dictionary<string, int>();
    //memo holds state [charPos][leftFinger][rightFinger];
    public int MinimumDistance(string word) {
        return Solve(word, 0, -1, -1);
    }
    
    private int Solve(string word, int pos, int lf, int rf){
        if(pos == word.Length) return 0;
        
        var current = word[pos] - 'A';
        var ans = int.MaxValue;
        var key = GetKey(pos, lf, rf);
        if(memo.ContainsKey(key)) return memo[key];
        var leftMoved = Solve(word, pos + 1, current, rf) + GetDistance(current, lf);
        var rightMoved = Solve(word, pos + 1, lf, current) + GetDistance(current, rf);
        
        ans = Math.Min(leftMoved, rightMoved);
        
        return memo[key] = ans;
    }
    
    private int GetDistance(int i, int j){
        if(i == -1 || j == -1) return 0;
        int x1 = i/6, y1 = i % 6;
        int x2 = j/6, y2 = j % 6;
        return Math.Abs(x1-x2) + Math.Abs(y1-y2);
    }
    
    private string GetKey(int i, int j, int k){
        return $"{i},{j},{k}";
    }
}