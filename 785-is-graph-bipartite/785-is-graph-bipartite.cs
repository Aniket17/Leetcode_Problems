public class Solution {
    public bool IsBipartite(int[][] graph) {
        int n = graph.Length;
        int[] color = new int[n];
        Array.Fill(color, -1);

        for (int start = 0; start < n; ++start) {
            if (color[start] == -1) {
                Stack<int> stack = new Stack<int>();
                stack.Push(start);
                color[start] = 0;

                while (stack.Count != 0) {
                    int node = stack.Pop();
                    foreach (int nei in graph[node]) {
                        if (color[nei] == -1) {
                            stack.Push(nei);
                            color[nei] = color[node] ^ 1;
                        } else if (color[nei] == color[node]) {
                            return false;
                        }
                    }
                }
            }
        }
        return true;
    }
}