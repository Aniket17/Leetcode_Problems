public class Solution {
    HashSet<int>[] rowSet = new HashSet<int>[9];
    HashSet<int>[] colSet = new HashSet<int>[9];
    HashSet<int>[] gridSet = new HashSet<int>[9];
    public void SolveSudoku(char[][] board) {
        /*
        create hashsets -> rows, cols, grid
        start filling in col for every row
        if Solve returns false, break the tree
        if valid, do it for next col
        if col == n move to next row
        base condition row == n-1 and col == n
        */
        
        var m = board.Length;
        var n = board[0].Length;
        
        //preprocess
        for(int row = 0; row < m; row++){
            rowSet[row] = new HashSet<int>();
            for(int col = 0; col < n; col++){
                var gridIndex = (row / 3) * 3 + col / 3;
                if(colSet[col] == null) colSet[col] = new HashSet<int>();
                if(gridSet[gridIndex] == null) gridSet[gridIndex] = new HashSet<int>();

                if(board[row][col] == '.') continue;
                
                int val = (int)(board[row][col] - 48);
                rowSet[row].Add(val);
                colSet[col].Add(val);
                gridSet[gridIndex].Add(val);
            }
        }
        
        //solve
        for(int row = 0; row < m; row++){
            for(int col = 0; col < n; col++){
                if(board[row][col] != '.') continue;
                Solve(board, row, col);
            }
        }
        
        return;
    }
    
    public bool Solve(char[][] board, int row, int col){
        if(row == 8 && col == 9) return true;
        if(col == board.Length)
        {
            row = row + 1;
            col = 0;
        }
        if (board[row][col] != '.')
        {
            return Solve(board, row, col + 1);
        }
        var gridIndex = (row / 3) * 3 + col / 3;
        
        for(int i = 1; i <= 9; i++){
            if(IsValid(row, col, i)){
                board[row][col] = (char)(i + 48);
                rowSet[row].Add(i);
                colSet[col].Add(i);
                gridSet[gridIndex].Add(i);
                if(Solve(board, row, col + 1)){
                    return true;
                }
                board[row][col] = '.';
                rowSet[row].Remove(i);
                colSet[col].Remove(i);
                gridSet[gridIndex].Remove(i);
            }
        }
        return false;
    }
    
    public bool IsValid(int row, int col, int val){
        var gridIndex = (row / 3) * 3 + col / 3;
        if(rowSet[row].Contains(val) || colSet[col].Contains(val) || gridSet[gridIndex].Contains(val)){
            return false;
        }
        
        return true;
    }
}