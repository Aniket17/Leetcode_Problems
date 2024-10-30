public class Solution {
    public int EarliestAcq(int[][] logs, int n) {
        //we need to understand two things
        //if every person becomes acq with every other person
        //if we think of persons friendships as graph, then we need to find if that graph is connected graph or not
        //there should not be any outliers or disconnected nodes
        //we can use disjoin set to find that
        //once we establish this, next question is when the earliest every person becomes acq
        //if we sort the logs by timestamps and then perform the union operation we can notice the time
        //but even without sorting, we can keep track of smallest time and update it whenever union returns true
        var uf = new UnionFind(n);
        var time = -1;
        logs = logs.OrderBy(x=>x[0]).ToArray();
        foreach(var log in logs){
            if(uf.Union(log[1], log[2])){
                time = log[0];
            }
        }

        if(!uf.IsFullyConnected(n)) return -1;
        return time;
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
            if(parent[p1] < parent[p2]){
                parent[p1] = p2;
            }else if(parent[p1] > parent[p2]){
                parent[p2] = p1;
            }else{
                parent[p1] = p2;
                rank[p2]++;
            }
            return true;
        }

        public bool IsFullyConnected(int n){
            var connected = 0;
            for(int i = 0; i < n; i++){
                if(parent[i] == i) connected++;
            }
            return connected == 1;
        }
    }
}