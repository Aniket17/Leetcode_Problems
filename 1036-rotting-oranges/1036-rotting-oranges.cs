public class Solution {
    public int OrangesRotting(int[][] grid) {
        int m = grid.Length, n = grid[0].Length, totalFresh = 0, minutes = 0;
        var queue = new Queue<int[]>();
        var dirs = new int[4][]{
            new int[]{-1,0},
            new int[]{0,-1},
            new int[]{1,0},
            new int[]{0,1}
        };
        for(int row = 0; row < m; row++){
            for(int col = 0; col < n; col++){
                if(grid[row][col] == 2){
                    queue.Enqueue(new int[]{row, col});
                }
                if(grid[row][col] == 1){
                    totalFresh++;
                }
            }
        }
        if(totalFresh == 0) return 0;
        //Console.WriteLine($"TotalFresh: {totalFresh}");

        while(queue.Count != 0){
            var count = queue.Count;
            while(count != 0){
                count--;
                var point = queue.Dequeue();
                foreach(var dir in dirs){
                    var newRow = point[0] + dir[0];
                    var newCol = point[1] + dir[1];
                    if(newRow >= 0 && newRow < m && newCol >= 0 && newCol < n){
                        if(grid[newRow][newCol] == 1){
                            totalFresh--;
                            grid[newRow][newCol] = 2;
                            queue.Enqueue(new int[]{newRow, newCol});
                        }
                    }
                }
            }
            minutes++;
            if(totalFresh == 0) return minutes;
        }
        return totalFresh == 0 ? minutes : -1;
    }
}