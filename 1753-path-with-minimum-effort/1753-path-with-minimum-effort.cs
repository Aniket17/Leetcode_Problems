using System;
using System.Collections.Generic;

public class Solution {
    public int MinimumEffortPath(int[][] heights) {
        int m = heights.Length, n = heights[0].Length;
        var dirs = new int[][] {
            new int[] {0, 1}, new int[] {0, -1}, new int[] {1, 0}, new int[] {-1, 0}
        };

        // Min-heap to store (effort, row, col), prioritized by effort
        var pq = new PriorityQueue<(int effort, int row, int col), int>();
        pq.Enqueue((0, 0, 0), 0);

        // Effort array to track the minimum effort to reach each cell
        var effort = new int[m, n];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                effort[i, j] = int.MaxValue;
            }
        }
        effort[0, 0] = 0;

        // Dijkstra's algorithm
        while (pq.Count > 0) {
            var (currentEffort, row, col) = pq.Dequeue();

            // If we reached the bottom-right cell, return the effort
            if (row == m - 1 && col == n - 1) {
                return currentEffort;
            }

            // Explore neighbors
            foreach (var dir in dirs) {
                int newRow = row + dir[0];
                int newCol = col + dir[1];

                if (newRow >= 0 && newRow < m && newCol >= 0 && newCol < n) {
                    int nextEffort = Math.Max(currentEffort, Math.Abs(heights[newRow][newCol] - heights[row][col]));
                    if (nextEffort < effort[newRow, newCol]) {
                        effort[newRow, newCol] = nextEffort;
                        pq.Enqueue((nextEffort, newRow, newCol), nextEffort);
                    }
                }
            }
        }

        return -1; // Should not reach here if the grid is connected
    }
}
