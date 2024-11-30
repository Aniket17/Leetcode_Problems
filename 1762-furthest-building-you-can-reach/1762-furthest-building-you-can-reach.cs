
public class Solution {
    public int FurthestBuilding(int[] heights, int bricks, int ladders) {
        var heap = new PriorityQueue<int, int>(); // Min-heap to track largest height differences

        for (int i = 0; i < heights.Length - 1; i++) {
            int climb = heights[i + 1] - heights[i];

            if (climb > 0) {
                heap.Enqueue(climb, climb); // Add the climb difference to the heap
                
                // If the heap size exceeds the number of ladders, use bricks for the smallest climb
                if (heap.Count > ladders) {
                    bricks -= heap.Dequeue();

                    // If bricks run out, return the current building index
                    if (bricks < 0) return i;
                }
            }
        }

        return heights.Length - 1; // If we finish the loop, we reached the last building
    }
}