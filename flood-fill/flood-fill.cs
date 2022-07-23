public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int color) {
        var m = image.Length;
        var n = image[0].Length;
        var originalColor = image[sr][sc];
        
        var dirs = new int[][]{new int[]{0,1}, new int[]{1,0}, new int[]{0,-1}, new int[]{-1,0}};
        var seen = new HashSet<int>();
        var queue = new Queue<int[]>();
        
        queue.Enqueue(new int[]{sr, sc});
        seen.Add(sr*n+sc);
        
        while(queue.Count != 0){
            var count = queue.Count;
            while(count--!=0){
                var pos = queue.Dequeue();
                image[pos[0]][pos[1]] = color;
                foreach(var dir in dirs){
                    var row = pos[0] + dir[0];
                    var col = pos[1] + dir[1];
                    if(row < 0 || col < 0 || row >= m || col >= n 
                       || image[row][col] != originalColor || seen.Contains(row*n+col)){
                        continue;
                    }
                    image[row][col] = color;
                    seen.Add(row*n+col);
                    queue.Enqueue(new int[]{row, col});
                }
            }
        }
        return image;
    }
}