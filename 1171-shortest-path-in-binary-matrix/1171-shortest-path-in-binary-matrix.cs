public class Solution {
    public int ShortestPathBinaryMatrix(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        if(m * n == 0) return 0;
        if(grid[0][0] != 0 || grid[m - 1][n - 1] != 0) return -1;
        if(m * n == 1) return 1;
        

        var seen = new HashSet<(int, int)>();
        var queue = new Queue<(int,int)>();
        queue.Enqueue((0,0));
        seen.Add((0, 0));
        var count = 0;
        while(queue.Count != 0){
            count++;
            var size = queue.Count;
            while(size-- != 0){
                var (row, col) = queue.Dequeue();
                for(int i = -1; i < 2; i++){
                    for(int j = -1; j < 2; j++){
                        var newRow = row + i;
                        var newCol = col + j;
                        if(newRow == m - 1 && newCol == n - 1) return count + 1;
                        if(newRow >= 0 && newCol >= 0 && newRow < m && newCol < n && grid[newRow][newCol] == 0 && !seen.Contains((newRow, newCol))){
                            queue.Enqueue((newRow, newCol));
                            seen.Add((newRow, newCol));
                        }
                    }
                }
            }
        }

        return -1;
    }
}