public class Solution {
    public int OrangesRotting(int[][] grid) {
        var rottenOranges = new Queue<int[]>();
        int total = 0;
        var m = grid.Length;
        var n = grid[0].Length;
        for(int row = 0; row < m; row++){
            for(int col = 0; col < n; col++){
                var el = grid[row][col];
                if(el == 2){
                    rottenOranges.Enqueue(new int[]{row, col});
                }
                if(el != 0){
                   total++; 
                }
            }
        }
        var seen = new HashSet<string>();
        var directions = new int[4][]
        {
             new int[]{0,1},
             new int[]{1,0},
             new int[]{0,-1},
             new int[]{-1,0}
        };
        int days = 0;
        int count = 0;
        while(rottenOranges.Count != 0){
            int k = rottenOranges.Count;
            count += k;
            while(k-- > 0){
                var top = rottenOranges.Dequeue();
                foreach(var dir in directions){
                    var newRow = top[0] + dir[0];
                    var newCol = top[1] + dir[1];
                    var pos = new int[]{newRow, newCol};
                    if(IsValid(pos, m, n) && grid[newRow][newCol] == 1){
                        rottenOranges.Enqueue(pos);
                        grid[pos[0]][pos[1]] = 2;
                    }
                }
            }
            if(rottenOranges.Count != 0) days++;
        }
        return total == count ? days : -1;
    }
    
    bool IsValid(int[] pos, int m, int n){
        var isInvalid = pos[0] < 0 || pos[0] >= m || pos[1] < 0 || pos[1] >= n;
        return !isInvalid;
    }
    string GetKey(int[] pos){
        return $"{pos[0]},{pos[1]}";
    }
}