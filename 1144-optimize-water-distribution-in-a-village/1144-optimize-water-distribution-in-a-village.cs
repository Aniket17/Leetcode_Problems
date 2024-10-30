public class Solution {
    public class Edge : IComparable<Edge>{
        public int src;
        public int dst;
        public int weight;
        public Edge(int s, int d, int w){
            src = s;
            dst = d;
            weight = w;
        }

        public int CompareTo(Edge other){
            return weight.CompareTo(other.weight);
        }
    }
    public int MinCostToSupplyWater(int n, int[] wells, int[][] pipes) {
        //this is a MST problem where we need to find MST for the houses. but the tweak here is cost to construct the well. this changes the solution and I am kinda stuck on this.
        //One possible solution is to find all the MST and include the cost of well at each node.
        //Or we can start with smallest cost to create the well and see if it forms MST but we may need to create multiple wells too.
        //Imagine creating a virtual node (let's call it node 0) that represents the "option" to build a well at each house.
        //For each house i, add an edge from this virtual node to the house with a weight equal to the well cost for that house (wells[i-1]).
        //This way, each edge from node 0 to a house represents the choice to build a well at that house rather than connecting to other houses.
        var edges = new List<Edge>();
        foreach(var pipe in pipes){
            edges.Add(new Edge(pipe[0], pipe[1], pipe[2]));
        }
        for(int i = 0; i < n; i++){
            edges.Add(new Edge(0, i+1, wells[i]));
        }

        //now we have to apply mst
        edges.Sort();
        var uf = new UnionFind(n);
        var minCost = 0;
        foreach(var edge in edges){
            if(uf.Union(edge.src, edge.dst)){
                minCost += edge.weight;
            }
        }

        return minCost;
    }

    public class UnionFind{
        int[] parent;
        public UnionFind(int n){
            parent = new int[n+1];
            for(int i = 0; i < n+1; i++) parent[i] = i;
        }

        int Find(int id){
            if(parent[id] != id){
                parent[id] = Find(parent[id]);
            }
            return parent[id];
        }
        public bool Union(int id1, int id2){
            var p1 = Find(id1);
            var p2 = Find(id2);
            if(p1 == p2) return false;
            parent[p1] = p2;
            return true;
        }
    }
}