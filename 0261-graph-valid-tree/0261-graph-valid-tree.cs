public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        if (edges.Length != n - 1) return false;
        var uf = new UnionFind(n);
        foreach(var edge in edges){
            if(!uf.Union(edge[0], edge[1])){
                return false;
            }
        }
        return true;
    }

    class UnionFind{
        int[] parent;
        int[] rank;
        public UnionFind(int n){
            parent = new int[n];
            rank = new int[n];
            for(int i = 0; i < n; i++){
                parent[i] = i;
            }
        }

        int Find(int id){
            if(id != parent[id]){
                parent[id] = Find(parent[id]);
            }
            return parent[id];
        }

        public bool Union(int id1, int id2){
            var p1 = Find(id1);
            var p2 = Find(id2);
            if(p1 == p2) return false;
            if(rank[p1] > rank[p2]){
                parent[p2] = p1;
            }else{
                parent[p1] = p2;
                if(rank[p1] == rank[p2]){
                    rank[p2]++;
                }
            }
            return true;
        }
    }
}