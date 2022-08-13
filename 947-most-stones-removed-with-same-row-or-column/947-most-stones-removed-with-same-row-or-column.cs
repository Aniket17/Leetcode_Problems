public class Solution {
    public int RemoveStones(int[][] stones) {
        var uf = new UnionFind(stones);
        foreach(var stone in stones){
            var row = -(stone[0]+1);
            var col = (stone[1]+1);
            uf.Union(row, col);
        }
        return stones.Length - uf.Count;
    }
    
    class UnionFind{
        Dictionary<int, int> parents;
        public int Count;
        public UnionFind(int[][]stones){
            parents = new();
            foreach(var stone in stones){
                var row = -(stone[0] + 1);
                var col = stone[1] + 1;
                parents[row] = row;
                parents[col] = col;
            }
            Count = parents.Count;
        }
        
        public int Find(int id){
            if(id != parents[id]){
                parents[id] = Find(parents[id]);
            }
            return parents[id];
        }
        
        public void Union(int row, int col){
            var p1 = Find(row);
            var p2 = Find(col);
            if(p1 == p2){
                return;
            }
            Count--;
            parents[p2] = p1;
        }
    }
}
