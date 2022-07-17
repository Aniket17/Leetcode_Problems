public class Solution {
    
    public IList<int> NumIslands2(int m, int n, int[][] positions) {
        var uf = new UnionFind(m * n);
        int[][] directions = new int[][]{
            new int[]{1,0},
            new int[]{0,1},
            new int[]{-1,0},
            new int[]{0,-1},
        };
        var marked = new HashSet<int>();
        var ans = new List<int>();
        foreach(var pos in positions){
            var n1 = pos[0] * n + pos[1];
            uf.MakeSet(n1);
            marked.Add(n1);
            foreach(var dir in directions){
                var row = pos[0] + dir[0];
                var col = pos[1] + dir[1];
                var n2 = row * n + col;
                if(row < 0 || col < 0 || row >= m || col >= n || !marked.Contains(n2)) continue;
                uf.MakeSet(n2);
                uf.Union(n1, n2);
            }
            ans.Add(uf.numberOfIslands);
        }
        return ans;
    }
    
    public class UnionFind{
        int[] parents;
        int[] ranks;
        public int numberOfIslands = 0;
        
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
            if(parents[n] != -1) return;
            parents[n] = n;
            numberOfIslands++;
        }
        
        public void Union(int n1, int n2){
            var p1 = FindParent(n1);
            var p2 = FindParent(n2);
            if(p1 == p2) {
                return;
            }
            numberOfIslands--;
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