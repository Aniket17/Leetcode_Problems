public class Solution {
    public bool IsValidSudoku(char[][] board) {
        var rowsSet = new HashSet<int>[9];
        var colsSet = new HashSet<int>[9];
        var gridSet = new HashSet<int>[9];
        
        for(int i = 0; i < 9; i++){
            rowsSet[i] = new HashSet<int>();
            for(int j = 0; j < 9; j++){
                if(board[i][j] == '.') continue;
                var intVal = (int)(board[i][j] - 48);
                var gridKey = (i / 3) * 3 + j / 3;
                if(colsSet[j] == null) colsSet[j] = new HashSet<int>();
                if(gridSet[gridKey] == null) gridSet[gridKey] = new HashSet<int>();
                
                if(intVal < 1 || intVal > 9) return false;
                if(!rowsSet[i].Add(intVal)) return false;
                if(!colsSet[j].Add(intVal)) return false;
                if(!gridSet[gridKey].Add(intVal)) return false;
            }
        }
        return true;
    }
}