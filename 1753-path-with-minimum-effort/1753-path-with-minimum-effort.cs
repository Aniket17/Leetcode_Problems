public class Solution {
    public int MinimumEffortPath(int[][] heights) {
        int m = heights.Length, n = heights[0].Length;
        var dirs = new int[][] {
            new int[] {0, 1}, new int[] {0, -1}, new int[] {1, 0}, new int[] {-1, 0}
        };
        var dist = new int[m * n];
        Array.Fill(dist, int.MaxValue);
        dist[0] = 0;

        bool updated = true;
        for (int iteration = 0; iteration < m * n - 1 && updated; iteration++) {
            updated = false;
            var temp = dist.ToArray(); // Copy to avoid immediate updates within the loop

            for (int i = 0; i < m; i++) {
                for (int j = 0; j < n; j++) {
                    int index = i * n + j;
                    if (dist[index] == int.MaxValue) continue; // Skip if unreachable

                    foreach (var dir in dirs) {
                        int newRow = i + dir[0];
                        int newCol = j + dir[1];

                        if (newRow >= 0 && newRow < m && newCol >= 0 && newCol < n) {
                            int newEffort = Math.Max(dist[index], Math.Abs(heights[newRow][newCol] - heights[i][j]));
                            int neighborIndex = newRow * n + newCol;

                            if (newEffort < temp[neighborIndex]) {
                                temp[neighborIndex] = newEffort;
                                updated = true;
                            }
                        }
                    }
                }
            }

            dist = temp; // Update the distances after processing all edges
        }

        return dist[m * n - 1] == int.MaxValue ? -1 : dist[m * n - 1];
    }
}
