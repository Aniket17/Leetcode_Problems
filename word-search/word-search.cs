public class Solution {
    int[][] directions;
    Dictionary<string, bool> memo;
    public bool Exist(char[][] board, string word) {
        directions = new int[][]{
            new int[]{0,1},
            new int[]{1,0},
            new int[]{0,-1},
            new int[]{-1,0},
        };
        
        var m = board.Length;
        var n = board[0].Length;
        
        memo = new Dictionary<string, bool>();
        
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(board[i][j] == word[0]){
                    var seen = new HashSet<string>();
                    seen.Add($"{i},{j}");
                    if(BackTrack(board, word, 1, i, j, seen)){
                        return true;
                    }
                }
            }
        }
        return false;
    }
    
    bool BackTrack(char[][] board, string word, int pos, int i, int j, HashSet<string> seen){
        
        var m = board.Length;
        var n = board[0].Length;
        
        if(pos >= word.Length){
            return true;
        }
        
        foreach(var dir in directions){
            var newRow = i + dir[0];
            var newCol = j + dir[1];
            
            var key = $"{newRow},{newCol}";
            
            if(IsValid(newRow,newCol,m,n) && !seen.Contains(key) && board[newRow][newCol] == word[pos]){
                //great
                seen.Add(key);
                
                if(BackTrack(board, word, pos + 1, newRow, newCol, seen)){
                    return true;
                }
                seen.Remove(key);
            }
        }
        return false;
    }
    
    bool IsValid(int i, int j, int m, int n){
        if(i < 0 || i > m - 1 || j < 0 || j > n - 1){
            return false;
        }
        return true;
    }
}