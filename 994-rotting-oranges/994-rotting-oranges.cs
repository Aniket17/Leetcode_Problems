public class Solution {
    public int OrangesRotting(int[][] grid) {
        var rottenOranges = new Queue<int[]>();
        var m = grid.Length;
        var n = grid[0].Length;
        var totalOranges = 0;
        
        for(int row = 0; row < m; row++){
            for(int col = 0; col < n; col++){
                var el = grid[row][col];
                if(el == 2)
                    rottenOranges.Enqueue(new int[2]{row, col});
                if(el != 0) totalOranges++;
            }
        }
        
        var dirs = new int[4][]{
            new int[] {0,1},
            new int[] {1,0},
            new int[] {-1,0},
            new int[] {0,-1}
        };
        
        int count = 0;
        var mins = 0;
        while(rottenOranges.Count != 0){
            int k = rottenOranges.Count;
            count += k;
            while(k-- > 0){
                var pos = rottenOranges.Dequeue();
                foreach(var dir in dirs){
                    var newRow = pos[0] + dir[0];
                    var newCol = pos[1] + dir[1];
                    if(newRow >= m || newRow < 0 || newCol >= n || newCol < 0){
                        continue;
                    }
                    if(grid[newRow][newCol] == 1){
                        rottenOranges.Enqueue(new int[]{newRow, newCol});
                        grid[newRow][newCol] = 2;
                    }
                }
            }
            if(rottenOranges.Count != 0) mins++;
        }
        return count == totalOranges ? mins : -1;
    }
}