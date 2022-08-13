public class Solution {
    // Maximum number of bikes is 10
    bool[] visited = new bool[10];
    int smallestDistanceSum = int.MaxValue;
    
    // Manhattan distance
    private int FindDistance(int[] worker, int[] bike) {
        return Math.Abs(worker[0] - bike[0]) + Math.Abs(worker[1] - bike[1]);
    }
    
    private void MinimumDistanceSum(int[][] workers, int workerIndex, int[][] bikes, int currDistanceSum) {
        if (workerIndex >= workers.Length) {
            smallestDistanceSum = Math.Min(smallestDistanceSum, currDistanceSum);
            return;
        }
        // If the current distance sum is greater than the smallest result 
        // found then stop exploring this combination of workers and bikes
        if (currDistanceSum >= smallestDistanceSum) {
            return;
        }
        for (int bikeIndex = 0; bikeIndex < bikes.Length; bikeIndex++) {
            // If bike is available
            if (!visited[bikeIndex]) {
                visited[bikeIndex] = true;
                MinimumDistanceSum(workers, workerIndex + 1, bikes, 
                    currDistanceSum + FindDistance(workers[workerIndex], bikes[bikeIndex]));
                visited[bikeIndex] = false;
            }
        }
    }
    
    public int AssignBikes(int[][] workers, int[][] bikes) {
        MinimumDistanceSum(workers, 0, bikes, 0);
        return smallestDistanceSum;
    } 
}