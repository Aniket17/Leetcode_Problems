public class Solution {
    Dictionary<(int, int), int> notAllowed;
    int numberOfMoves = 0;
    public int NumberOfPatterns(int m, int n) {
        //notAllowed jumps
        notAllowed = new();
        notAllowed.Add((1,3),2);
        notAllowed.Add((3,1),2);
        notAllowed.Add((1,7),4);
        notAllowed.Add((7,1),4);
        notAllowed.Add((3,9),6);
        notAllowed.Add((9,3),6);
        notAllowed.Add((7,9),8);
        notAllowed.Add((9,7),8);
        
        notAllowed.Add((1,9),5);
        notAllowed.Add((9,1),5);
        notAllowed.Add((3,7),5);
        notAllowed.Add((7,3),5);
        notAllowed.Add((2,8),5);
        notAllowed.Add((8,2),5);
        notAllowed.Add((4,6),5);
        notAllowed.Add((6,4),5);
        
        var ans = 0;
        for(int i = m; i <= n; i++){
            //for m keys to n keys, build the right transition
            for(int j = 1; j <= 9; j++){
                ans += CountPatterns(j, i-1, new HashSet<int>(){j});
            }
        }
        return ans;
    }

    int CountPatterns(int curr, int remain, HashSet<int> seen){
        if(remain == 0) return 1;
        var ans = 0;
        for(int next = 1; next <= 9; next++){
            var key = (curr, next);
            if(!seen.Contains(next) && (!notAllowed.ContainsKey(key) || seen.Contains(notAllowed[key]))){
                //allowed
                seen.Add(next);
                ans += CountPatterns(next, remain-1, seen);
                seen.Remove(next);
            }
        }
        return ans;
    }
}