public class Solution {
    public int ShortestPathBinaryMatrix(int[][] grid) {
        var m = grid.Length;
        var n = grid[0].Length;
        
        if(m * n == 0) return 0;
        if(m * n == 1) return 1;
        if(grid[0][0] != 0 || grid[m - 1][n - 1] != 0) return -1;
        var count = 0;
        var seen = new int[m, n];
        
        var queue = new Queue<int[]>();
        
        queue.Enqueue(new int[]{0,0});
        seen[0,0] = 1;
        
        while(queue.Count != 0){
            var size = queue.Count;
            count++;
            while(size-- != 0){
                var node = queue.Dequeue();
                for(int i = -1; i < 2; i++){
                    for(int j = -1; j < 2; j++){
                        var row = node[0] + i;
                        var col = node[1] + j;
                        if(row == m - 1 && col == n - 1) return count + 1;
                        if(IsValid(row, col, m ,n) && grid[row][col] == 0 && seen[row, col] == 0){
                            seen[row, col] = 1;
                            queue.Enqueue(new int[]{row, col});
                        }
                    }
                }
            }
        }
        return -1;
    }
    
    bool IsValid(int row, int col, int m, int n){
        return row >= 0 && col >= 0 && row < m && col < n;
    }
}