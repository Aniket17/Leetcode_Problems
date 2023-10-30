public class Solution {
    public class Edge{
        public int src;
        public int dst;
        public int weight;

        public Edge(int s, int d, int w){
            src = s;
            dst = d;
            weight = w;
        }

        public string GetId(){
            return $"{src},{dst}";
        }
    }
    public int MinCostConnectPoints(int[][] points) {
        var edges = new List<Edge>();
        var uf = new UnionFind();
        var minDistance = 0;
        //var mstEdges = new List<string>();

        for(int i = 0; i < points.Length; i++){
            uf.MakeSet(i);
            for(int j = i + 1; j < points.Length; j++){
                edges.Add(new Edge(i, j, GetDistance(points[i], points[j])));
            }
        }
        var sorted = edges.OrderBy(x=>x.weight).ToList();

        foreach(var edge in sorted){
            if(uf.Union(edge.src, edge.dst)){
                minDistance += edge.weight;
                //mstEdges.Add(edge.GetId());
            }
        }
        //Console.WriteLine(string.Join("|", mstEdges));
        return minDistance;
    }

    public int GetDistance(int[] p1, int[] p2){
        return Math.Abs(p1[0] - p2[0]) + Math.Abs(p1[1] - p2[1]);
    }

    public class Node{
        public int data;
        public int rank;
        public Node parent;

        public Node(int d){
            data = d;
            rank = 0;
            parent = this;
        }
    }

    public class UnionFind{
        Dictionary<int, Node> map = new();
        public void MakeSet(int data){
            map.Add(data, new Node(data));
        }
        
        public Node Find(int d){
            var node = map[d];
            if(node.parent != node){
                node.parent = Find(node.parent.data);
            }
            return node.parent;
        }

        public bool Union(int d1, int d2){
            var p1 = Find(d1);
            var p2 = Find(d2);
            if(p1 == p2) return false;

            if(p1.rank > p2.rank){
                p1.rank++;
                p2.parent = p1.parent;
            }else{
                if(p1.rank != p2.rank)
                    p2.rank++;
                p1.parent = p2.parent;
            }
            return true;
        }
    }
}