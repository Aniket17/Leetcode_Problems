public class Solution {
    int[][] dirs = new int[8][]{
        new int[]{0, 1},
        new int[]{0, -1},
        new int[]{1, 0},
        new int[]{-1, 0},
        new int[]{-1, -1},
        new int[]{1, 1},
        new int[]{1, -1},
        new int[]{-1, 1},
    };
    public void GameOfLife(int[][] board) {
        var m = board.Length;
        var n = board[0].Length;
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(IsValid(board, i, j, board[i][j])) continue;
                board[i][j] = board[i][j] == 0 ? 5 : -1;
            }
        }
        
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                board[i][j] = board[i][j] >= 1 ? 1 : 0;
            }
        }
    }
    
    bool IsValid(int[][] board, int i, int j, int val){
        var nei = GetNeibours(board, i, j);
        var live = nei.Count(x=> Math.Abs(x) == 1);
        if(val == 0){
             return live != 3;
        }
        if(live == 2 || live == 3){
            return true;
        }
        return false;
    }
    
    List<int> GetNeibours(int[][] board, int i, int j){
        var m = board.Length;
        var n = board[0].Length;
        var nei = new List<int>();
        foreach(var dir in dirs){
            var newRow = i + dir[0];
            var newCol = j + dir[1];
            if(newRow < 0 || newRow >= m || newCol < 0 || newCol >= n){
                continue;
            }
            nei.Add(board[newRow][newCol]);
        }
        
        return nei;
    }
}

/*
[0,1,0]         [0,0,0]         
[0,0,1]         [0,1,1]    
[1,1,1]         [0,1,1]    
[0,0,0]         [0,0,0]



*/