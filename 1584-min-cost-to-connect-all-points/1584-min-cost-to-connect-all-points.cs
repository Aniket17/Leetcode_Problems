public class Solution {
    public int MinCostConnectPoints(int[][] arr) {
        var uf = new UnionFind();
        int n = arr.Length;
        var points = arr.Select(x=> new Point(x[0], x[1])).ToArray();
        var edges = new List<Edge>();
        for(int i = 0; i < points.Length; i++){
            for(int j = i + 1; j < points.Length; j++){
                edges.Add(new Edge(points[i], points[j]));
            }
        }
        edges = edges.OrderBy(x=>x.distance).ToList();
        foreach(var p in points){
            uf.MakeSet(p.id);
        }
        var minDistance = 0;
        var edgesUsed = 0;
        foreach(var edge in edges){
            if(uf.Union(edge.p1.id, edge.p2.id)){
                minDistance+=edge.distance;
                edgesUsed++;
            }
            if(edgesUsed >= n) break;
        }
        return minDistance;
    }
    
    public class UnionFind{
        Dictionary<string, string> parents;
        public UnionFind(){
            parents = new Dictionary<string, string>();
        }
        
        private string FindParent(string i){
            if(i == parents[i]){
                return parents[i];
            }
            parents[i] = FindParent(parents[i]);
            return parents[i];
        }
        
        public void MakeSet(string id){
            parents.Add(id, id);
        }
        
        public bool Union(string p1, string p2){
            var parent1 = FindParent(p1);
            var parent2 = FindParent(p2);
            
            if(parent1 == parent2) return false;
            parents[parent1] = parent2;
            return true;
        }
    }
    
     
    public class Point {
        public int x;
        public int y;
        public string id {get {return $"{x},{y}";}}
        public Point(int _x, int _y){
            x = _x;
            y = _y;
        }
    }
    
    public class Edge{
        public Point p1;
        public Point p2;
        public int distance { get{ return Math.Abs(p1.x - p2.x) + Math.Abs(p1.y - p2.y);}}
        public Edge(Point p1, Point p2){
            this.p1 = p1;
            this.p2 = p2;
        }
    }
}