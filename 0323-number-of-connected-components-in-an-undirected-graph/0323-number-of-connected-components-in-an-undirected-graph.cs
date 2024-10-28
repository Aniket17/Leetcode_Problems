public class Solution {
    public int CountComponents(int n, int[][] edges) {
        var uf = new UnionFind(n);
        foreach(var edge in edges){
            var canConnect = uf.Union(edge[0], edge[1]);
            if(canConnect){
                n--;
            }
        }
        return n;
    }

    public class UnionFind{
        int[] parents;
        int[] ranks;
        public UnionFind(int n){
            parents = new int[n];
            ranks = new int[n];
            for(int i = 0; i < n; i++){
                parents[i] = i;
            }
        }

        int Find(int id){
            if(id != parents[id]){
                parents[id] = Find(parents[id]);
            }
            return parents[id];
        }

        public bool Union(int id1, int id2){
            var p1 = Find(id1);
            var p2 = Find(id2);
            if(p1==p2) return false;
            if(ranks[p1] > ranks[p2]){
                parents[p2] = p1;
            }else{
                parents[p1] = p2;
                if(ranks[p1] == ranks[p2]) ranks[p2]++;
            }
            return true;
        }
    }
}