public class Solution {
    public int RemoveStones(int[][] stones) {
        // think of stones that share same row or col as connected component
        // number of stones we can remove are total stones - number of connected components
        // because there should be atleast one stone left in a component
        // to find connected components we can use unionfind ds
        var uf = new UnionFind();
        foreach(var stone in stones){
            uf.Union(stone[0], stone[1]); 
        }

        HashSet<int> uniqueParents = new HashSet<int>();
        foreach (var stone in stones) {
            int row = stone[0];
            int col = stone[1] + 10001;
            uniqueParents.Add(uf.Find(row));  // Find unique components (either row or column)
        }
        return stones.Length - uniqueParents.Count;
    }

    public class UnionFind{
        int[] parents;
        int[] ranks;
        int size = 20000;
        public UnionFind() {
            parents = new int[size];
            ranks = new int[size];
            for (int i = 0; i < size; i++) {
                parents[i] = i;  // Each node is its own parent initially
                ranks[i] = 0;    // Initialize ranks
            }
        }
        
        public int Find(int id){
            if(parents[id] != id){
                parents[id] = Find(parents[id]);
            }
            return parents[id];
        }

        public void Union(int id1, int id2){
            id2 = id2 + 10001; // +10k so that we avoid collision with rows
            var p1 = Find(id1);
            var p2 = Find(id2);
            if(p1 == p2) return; //already in same connected component
            if(ranks[p1] > ranks[p2]){
                parents[p2] = p1;
            }else if(ranks[p2] > ranks[p1]){
                parents[p1] = p2;
            }else{
                parents[p1] = p2;
                ranks[p2]++;
            }
        }
    }
}