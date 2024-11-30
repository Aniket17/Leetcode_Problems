public class Solution {
    int[][] dirs = new int[][] {
        new int[] { 1, 0 },
        new int[] { -1, 0 },
        new int[] { 0, 1 },
        new int[] { 0, -1 }
    };

    public int MaximumSafenessFactor(IList<IList<int>> grid) {
        int n = grid.Count;

        // Step 1: Compute distance to nearest thief using multi-source BFS
        int[][] dist = new int[n][];
        for (int i = 0; i < n; i++) {
            dist[i] = new int[n];
            Array.Fill(dist[i], int.MaxValue);
        }

        var queue = new Queue<(int, int)>();
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 1) {
                    queue.Enqueue((i, j));
                    dist[i][j] = 0;
                }
            }
        }

        while (queue.Count > 0) {
            var (row, col) = queue.Dequeue();
            foreach (var dir in dirs) {
                int newRow = row + dir[0];
                int newCol = col + dir[1];
                if (newRow >= 0 && newRow < n && newCol >= 0 && newCol < n && dist[newRow][newCol] == int.MaxValue) {
                    dist[newRow][newCol] = dist[row][col] + 1;
                    queue.Enqueue((newRow, newCol));
                }
            }
        }

        // Step 2: Binary search on safeness factor
        int left = 0, right = dist[0][0], result = 0;

        while (left <= right) {
            int mid = left + (right - left) / 2;

            if (CanReachEnd(mid, dist)) {
                result = mid;
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }

        return result;
    }

    private bool CanReachEnd(int safeness, int[][] dist) {
        int n = dist.Length;
        var queue = new Queue<(int, int)>();
        var visited = new HashSet<(int, int)>();

        if (dist[0][0] < safeness) return false;

        queue.Enqueue((0, 0));
        visited.Add((0, 0));

        while (queue.Count > 0) {
            var (row, col) = queue.Dequeue();

            if (row == n - 1 && col == n - 1) return true;

            foreach (var dir in dirs) {
                int newRow = row + dir[0];
                int newCol = col + dir[1];

                if (newRow >= 0 && newRow < n && newCol >= 0 && newCol < n &&
                    !visited.Contains((newRow, newCol)) && dist[newRow][newCol] >= safeness) {
                    queue.Enqueue((newRow, newCol));
                    visited.Add((newRow, newCol));
                }
            }
        }

        return false;
    }
}