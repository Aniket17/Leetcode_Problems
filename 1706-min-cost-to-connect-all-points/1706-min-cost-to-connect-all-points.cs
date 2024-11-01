public class Solution {
    public int MinCostConnectPoints(int[][] points) {
        var edges = new List<Edge>();
        var uf = new UnionFind(points.Length);

        // Create edges between every pair of points
        for (int i = 0; i < points.Length; i++) {
            for (int j = i + 1; j < points.Length; j++) {
                var dist = Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]);
                edges.Add(new Edge(i, j, dist));
            }
        }

        // Sort edges by weight (Manhattan distance)
        edges.Sort();

        int minCost = 0;
        int numEdges = 0;

        // Process edges to form MST using Kruskal's algorithm
        foreach (var edge in edges) {
            if (uf.Union(edge.src, edge.dst)) {
                minCost += edge.weight;
                numEdges++;
                // Stop if we have included (n - 1) edges
                if (numEdges == points.Length - 1) break;
            }
        }

        return minCost;
    }

    public class Edge : IComparable<Edge> {
        public int src, dst, weight;
        public Edge(int s, int d, int w) {
            src = s;
            dst = d;
            weight = w;
        }

        public int CompareTo(Edge other) {
            return weight.CompareTo(other.weight);
        }
    }

    public class UnionFind {
        private int[] parent;
        private int[] rank;

        public UnionFind(int size) {
            parent = new int[size];
            rank = new int[size];
            for (int i = 0; i < size; i++) {
                parent[i] = i;
            }
        }

        public int Find(int node) {
            if (parent[node] != node) {
                parent[node] = Find(parent[node]); // Path compression
            }
            return parent[node];
        }

        public bool Union(int node1, int node2) {
            int root1 = Find(node1);
            int root2 = Find(node2);

            if (root1 == root2) return false; // Already in the same set

            // Union by rank
            if (rank[root1] > rank[root2]) {
                parent[root2] = root1;
            } else if (rank[root1] < rank[root2]) {
                parent[root1] = root2;
            } else {
                parent[root1] = root2;
                rank[root2]++;
            }

            return true;
        }
    }
}
