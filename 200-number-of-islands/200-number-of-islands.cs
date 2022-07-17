public class Solution {
    int[][] directions = new int[][]{
            new int[]{1,0},
            new int[]{0,1},
            new int[]{-1,0},
            new int[]{0,-1},
        };
    public int NumIslands(char[][] grid) {
        var m = grid.Length;
        var n = grid[0].Length;
        var count = 0;
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(grid[i][j] == '1'){
                    MarkZeros(grid, i, j);
                    count++;
                }
            }
        }
        return count;
    }
    
    void MarkZeros(char[][]grid, int i, int j){
        if(!IsValid(grid, i, j)){
            return;
        }
        grid[i][j] = '0';
        foreach(var dir in directions){
            var row = dir[0] + i;
            var col = dir[1] + j;
            MarkZeros(grid, row, col);
        }
    }
    
    bool IsValid(char[][] grid, int row, int col){
        var m = grid.Length;
        var n = grid[0].Length;
        
        if(row >= 0 && col >= 0 && row < m && col < n && grid[row][col] == '1'){
            return true;
        }
        return false;
    }
    
    public class UnionFind{
        int[] parents;
        int[] ranks;
        
        public UnionFind(int size){
            parents = new int[size];
            ranks = new int[size];
            Array.Fill(parents, -1);
        }
        
        private int FindParent(int n){
            if(n != parents[n]){
                parents[n] = FindParent(parents[n]);
            }
            return parents[n];
        }
        
        public void MakeSet(int n){
            parents[n] = n;
        }
        
        public void Union(int n1, int n2){
            var p1 = FindParent(n1);
            var p2 = FindParent(n2);
            if(p1 == p2) return;
            
            if(ranks[p1] > ranks[p2]){
                parents[p2] = p1;
            }else if(ranks[p1] < ranks[p2]){
                parents[p1] = p2;
            }else{
                parents[p1] = p2;
                ranks[p1]++;
            }
        }
        
        public void Print(){
            Console.WriteLine(string.Join(",", parents));
            Console.WriteLine(string.Join(",", ranks));
        }
    }
}