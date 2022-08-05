public class Solution {
    public class IntComparer:IComparer<int[]>{
        public int Compare(int[] a, int[] b){
            return GetDistance(b).CompareTo(GetDistance(a));
        }
        private double GetDistance(int[] point){
            return Math.Sqrt(point[0]*point[0] + point[1]*point[1]);
        }
    }
    public int[][] KClosest(int[][] points, int k) {
        PriorityQueue<int[], int[]> queue = new(new IntComparer());
        foreach(var point in points){
            queue.Enqueue(point, point);
            if(queue.Count > k){
                queue.Dequeue();
            }
        }
        var result = new int[queue.Count][];
        var index = 0;
        while(queue.Count != 0){
            result[index++] = queue.Dequeue();
        }
        return result;
    }
}