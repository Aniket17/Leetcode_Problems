public class Solution {
    public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs) {
        int n = s.Length;
        
        // Union-Find to group indices
        var parent = new int[n];
        for (int i = 0; i < n; i++) parent[i] = i;
        
        // Find function with path compression
        int Find(int x) {
            if (parent[x] != x) {
                parent[x] = Find(parent[x]);
            }
            return parent[x];
        }
        
        // Union function
        void Union(int x, int y) {
            int rootX = Find(x);
            int rootY = Find(y);
            if (rootX != rootY) {
                parent[rootY] = rootX;
            }
        }
        
        // Union all pairs
        foreach (var pair in pairs) {
            Union(pair[0], pair[1]);
        }
        
        // Group indices by root parent
        var groups = new Dictionary<int, List<int>>();
        for (int i = 0; i < n; i++) {
            int root = Find(i);
            if (!groups.ContainsKey(root)) {
                groups[root] = new List<int>();
            }
            groups[root].Add(i);
        }
        
        // Build the smallest lexicographical string
        var arr = s.ToCharArray();
        foreach (var group in groups.Values) {
            // Extract characters and sort them
            var chars = group.Select(index => arr[index]).ToList();
            chars.Sort();
            
            // Place sorted characters back into positions
            for (int i = 0; i < group.Count; i++) {
                arr[group[i]] = chars[i];
            }
        }
        
        return new string(arr);
    }
}
