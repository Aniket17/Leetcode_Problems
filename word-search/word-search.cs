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
        var set = new HashSet<char>();
        for (int r = 0; r < board.Length; r++)
        {
            for (int c = 0; c < board[0].Length; c++)
            {
                set.Add(board[r][c]);
            }
        }

        if (word.Any(w => !set.Contains(w))) return false;
        
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(board[i][j] == word[0]){
                    var tmp = board[i][j];
                    board[i][j] = '*';
                    if(BackTrack(board, word, 1, i, j)){
                        return true;
                    }
                    board[i][j] = tmp;
                }
            }
        }
        return false;
    }
    
    bool BackTrack(char[][] board, string word, int pos, int i, int j){
        
        var m = board.Length;
        var n = board[0].Length;
        
        if(pos >= word.Length){
            return true;
        }
        
        foreach(var dir in directions){
            var newRow = i + dir[0];
            var newCol = j + dir[1];
            
            var key = $"{newRow},{newCol}";
            
            if(IsValid(newRow,newCol,m,n) && board[newRow][newCol] == word[pos]){
                //great
                var tmp = board[newRow][newCol];
                board[newRow][newCol] = '*';
                if(BackTrack(board, word, pos + 1, newRow, newCol)){
                    return true;
                }
                
                board[newRow][newCol] = tmp;
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