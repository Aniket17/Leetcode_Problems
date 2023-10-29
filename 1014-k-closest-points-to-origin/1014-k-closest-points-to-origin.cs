public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        var heap = new PriorityQueue<int[], double>();
        foreach(var point in points){
            heap.Enqueue(point, GetDistanceFromOrigin(point));
        }
        var result = new int[k][];
        for(int i = 0; i < k; i++){
            result[i] = heap.Dequeue();
        }
        return result;
    }

    double GetDistanceFromOrigin(int[] point) {
        return Math.Sqrt((point[0] * point[0]) + (point[1] * point[1]));
    }
}