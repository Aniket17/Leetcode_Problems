public class Solution {
    public int CountUnguarded(int m, int n, int[][] guards, int[][] walls) {
        // Track walls and guards
        var wallSet = walls.Select(w => (w[0], w[1])).ToHashSet();
        var guardSet = guards.Select(g => (g[0], g[1])).ToHashSet();
        var guardedSet = new HashSet<(int, int)>();

        var directions = new (int, int)[] {
            (1, 0),   // Down
            (-1, 0),  // Up
            (0, 1),   // Right
            (0, -1)   // Left
        };

        foreach (var guard in guards) {
            var (row, col) = (guard[0], guard[1]);
            foreach (var (dr, dc) in directions) {
                int r = row, c = col;
                while (true) {
                    r += dr;
                    c += dc;
                    if (r < 0 || r >= m || c < 0 || c >= n || wallSet.Contains((r, c)) || guardSet.Contains((r, c))) {
                        break;
                    }
                    guardedSet.Add((r, c));
                }
            }
        }

        // Total cells - walls - guards - guarded cells
        return (m * n) - walls.Length - guards.Length - guardedSet.Count;
    }
}

/*
guard can see in all four directions
stop seeing after wall or another guard

depth first search algorithm from every guard and mark its visible range
and we will stop once we hit the wall or grid size
*/