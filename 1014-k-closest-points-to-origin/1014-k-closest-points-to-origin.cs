public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        var heap = new PriorityQueue<int[], double>(Comparer<double>.Create((x, y) => y.CompareTo(x)));
        foreach(var p in points){
            heap.Enqueue(p, GetDistance(p));
            if(heap.Count > k){
                heap.Dequeue();
            }
        }
        var result = new int[k][];
        while(heap.Count != 0){
            k--;
            result[k] = heap.Dequeue();
        }
        return result;
    }

    double GetDistance(int[] p1){
        return (p1[0] * p1[0]) + (p1[1] * p1[1]);
    }
}