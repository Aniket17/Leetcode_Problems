public class Solution {
    public int MinimumTime(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        var directions = new int[][] { new[] { 0, 1 }, new[] { 0, -1 }, new[] { 1, 0 }, new[] { -1, 0 } };

        // Edge case: If the difference between the starting cell and the adjacent cell is too large
        if (grid[0][1] > 1 && grid[1][0] > 1) {
            return -1;
        }

        // Min-heap priority queue to store (time, row, col)
        var pq = new PriorityQueue<(int time, int row, int col), int>();
        pq.Enqueue((0, 0, 0), 0);

        // To track the minimum time to reach each cell
        var minTime = new int[m, n];
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                minTime[i, j] = int.MaxValue;

        minTime[0, 0] = 0;

        while (pq.Count > 0) {
            var (time, row, col) = pq.Dequeue();

            // If we reach the bottom-right cell, return the time
            if (row == m - 1 && col == n - 1)
                return time;

            foreach (var dir in directions) {
                int newRow = row + dir[0];
                int newCol = col + dir[1];

                if (newRow >= 0 && newRow < m && newCol >= 0 && newCol < n) {
                    int waitTime = 0;

                    // If the difference between the current time + 1 and grid[newRow][newCol] is odd, wait an additional second
                    if (grid[newRow][newCol] > time + 1) {
                        waitTime = (grid[newRow][newCol] - (time + 1) + 1) / 2 * 2;
                    }

                    int newTime = time + 1 + waitTime;

                    if (newTime < minTime[newRow, newCol]) {
                        minTime[newRow, newCol] = newTime;
                        pq.Enqueue((newTime, newRow, newCol), newTime);
                    }
                }
            }
        }

        return -1;
    }
}