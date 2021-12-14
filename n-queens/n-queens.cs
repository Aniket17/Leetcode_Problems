public class Solution {
    HashSet<string> dups = new HashSet<string>();
    public IList<IList<string>> SolveNQueens(int n) {
        var ans = new List<IList<string>>();
        
        while(true){
            var board = GetNewBoard(n);
            var colSet = new HashSet<int>();
            if(Solve(board, 0, colSet, "")){
                ans.Add(board.Select(r => string.Join("", r)).ToList());
            }else{
                break;
            }
           
        }
        return ans;
    }
    
    bool Solve(char[][] board, int row, HashSet<int> colSet, string curr){
        if(row == board.Length){
            return true;
        }
        for(int col = 0; col < board.Length; col++){
            if(colSet.Contains(col) || !IsValid(board, row, col, colSet)){
                continue;
            }
            board[row][col] = 'Q';
            colSet.Add(col);
            var key = $"{row}{col},";
            if(Solve(board, row + 1, colSet, curr + key) && !dups.Contains(curr + key)){
                if(row == board.Length - 1)
                {
                    dups.Add(curr + key);
                    // Console.WriteLine(curr + key);
                    // Console.WriteLine(row);
                    // Console.WriteLine(string.Join("|", dups));
                }
                return true;
            }
            board[row][col] = '.';
            colSet.Remove(col);
        }
        return false;
    }
    
    bool IsValid(char[][] board, int row, int pos, HashSet<int> colSet){
        var res = true;
        var n = board.Count();
        if(row == 0) return true;
        
        for(int i = 0; i < colSet.Count(); i++){
            //check diagonal
            var p = colSet.ElementAt(i);
            if (pos == p + row - i || pos == p - row + i) return false;
        }
        if(pos == 0){
            res = res && board[row - 1][pos] == '.';
            res = res && board[row - 1][pos + 1] == '.';
        }else if(pos == n - 1){
            res = res && board[row - 1][pos] == '.';
            res = res && board[row - 1][pos - 1] == '.';
        }else{
            res = res && board[row - 1][pos] == '.';
            res = res && board[row - 1][pos - 1] == '.';
            res = res && board[row - 1][pos + 1] == '.';
        }
        return res;
    }
    
    char[][] GetNewBoard(int n){
        var board = new char[n][];
        for(int i = 0; i < n; i++){
            board[i] = new char[n];
            for(int j = 0; j < n; j++){
                board[i][j] = '.';
            }
        }
        return board;
    }
}