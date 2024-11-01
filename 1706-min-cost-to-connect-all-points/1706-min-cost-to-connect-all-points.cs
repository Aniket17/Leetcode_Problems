public class Solution {
    public class Edge:IComparable<Edge>{
        public int[] src, dst;
        public int weight;
        public Edge(int[] s, int[] d, int w){
            src = s; dst=d; weight = w;
        }

        public int CompareTo(Edge other){
            return weight.CompareTo(other.weight);
        }
    }
    public int MinCostConnectPoints(int[][] points) {
        var edges = new List<Edge>();
        var uf = new UnionFind();
        for(int i = 0; i < points.Length; i++){
            uf.MakeSet(points[i]);
            for(int j = i+1; j < points.Length; j++){
                var p1 = points[i];
                var p2 = points[j];
                var dist = Math.Abs(p1[0] - p2[0]) + Math.Abs(p1[1] - p2[1]);
                edges.Add(new Edge(p1, p2, dist));
            }
        }
        edges.Sort();
        var minCost = 0;
        foreach(var edge in edges){
            if(uf.Union(edge.src, edge.dst)){
                minCost += edge.weight;
            }
        }
        return minCost;
    }

    public class UnionFind{
        Dictionary<int[], int[]> parent = new();
        public void MakeSet(int[] p){
            parent[p] = p;
        }

        int[] Find(int[] id){
            if(parent[id] == id) return id;
            parent[id] = Find(parent[id]);
            return parent[id];
        }

        public bool Union(int[] id1, int[] id2){
            var p1 = Find(id1);
            var p2 = Find(id2);
            if(p1 == p2) return false;
            parent[p1] = p2;
            return true;
        }
    }

}