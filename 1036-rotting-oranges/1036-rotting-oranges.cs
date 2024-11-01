public class Solution {
    public int OrangesRotting(int[][] grid) {
        int m = grid.Length, n = grid[0].Length, mins = 0;
        var dirs = new int[4][]{
            new int[]{-1,0},
            new int[]{1,0},
            new int[]{0,-1},
            new int[]{0,1}
        };
        var queue = new Queue<(int, int)>();
        int rotten = 0, total = 0;
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(grid[i][j] == 2){
                    queue.Enqueue((i, j));
                    rotten++;
                }
                if(grid[i][j] != 0){
                    total++;
                }
            }
        }
        if(total == 0) return 0;

        while(queue.Count != 0){
            var size = queue.Count;
            while(size-- != 0){
                var (row, col) = queue.Dequeue();
                foreach(var dir in dirs){
                    var newRow = row + dir[0];
                    var newCol = col + dir[1];
                    if(newRow < 0 || newCol < 0 || newRow >= m || newCol >= n || grid[newRow][newCol] == 2 || grid[newRow][newCol] == 0){
                        //dont want to continue exploring
                        continue;
                    }
                    queue.Enqueue((newRow, newCol));
                    grid[newRow][newCol] = 2;//avoid cycles
                    rotten++;
                }
            }
            mins++;
        }
        return rotten == total ? mins - 1 : -1;
    }
}