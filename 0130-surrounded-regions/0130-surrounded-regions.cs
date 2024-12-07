public class Solution {
    public void Solve(char[][] board) {
        var m = board.Length;
        var n = board[0].Length;
        var queue = new Queue<(int, int)>();
        for(int i = 0; i < m; i++){
            if(board[i][n-1] == 'O'){
                queue.Enqueue((i,n-1));
                board[i][n-1] = 'Z';
            }
            if(board[i][0] == 'O'){
                queue.Enqueue((i,0));
                board[i][0] = 'Z';
            }
        }

        for(int i = 0; i < n; i++){
            if(board[0][i] == 'O'){
                queue.Enqueue((0, i));
                board[0][i] = 'Z';
            }
            if(board[m-1][i] == 'O'){
                queue.Enqueue((m-1, i));
                board[m-1][i] = 'Z';
            }
        }
        var dirs = new int[][]{
            new int[]{1,0},
            new int[]{-1,0},
            new int[]{0,1},
            new int[]{0,-1}
        };
        while(queue.Count != 0){
            var size = queue.Count;
            while(size-- != 0){
                var (row, col) = queue.Dequeue();
                foreach(var dir in dirs){
                    var newRow = row + dir[0];
                    var newCol = col + dir[1];
                    if(newRow < 0 || newRow >= m || newCol < 0 || newCol >= n || board[newRow][newCol] != 'O') continue;
                    board[newRow][newCol] = 'Z';
                    queue.Enqueue((newRow, newCol));
                }
            }
        }

        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(board[i][j] == 'Z'){
                    board[i][j] = 'O';
                }else{
                    board[i][j] = 'X';
                }
            }
        }
    }
}