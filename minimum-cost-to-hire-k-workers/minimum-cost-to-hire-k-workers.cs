public class Solution {
    public double MincostToHireWorkers(int[] quality, int[] wage, int k) {
        int N = quality.Length;
        Worker[] workers = new Worker[N];
        for (int i = 0; i < N; ++i)
            workers[i] = new Worker(quality[i], wage[i]);
        Array.Sort(workers);

        double ans = 1e9;
        int sumq = 0;
        PriorityQueue<int, int> pool = new(new IntComparer());
        foreach (Worker worker in workers) {
            pool.Enqueue(worker.quality, worker.quality);
            sumq += worker.quality;
            if (pool.Count > k)
                sumq -= pool.Dequeue();
            if (pool.Count == k)
                ans = Math.Min(ans, sumq * worker.Ratio());
        }

        return ans;
    }
    
    public class IntComparer:IComparer<int>{
        public int Compare(int a, int b){
            return b - a;
        }
    }
    
    public class Worker : IComparable<Worker> {
        public int quality, wage;
        public Worker(int q, int w) {
            quality = q;
            wage = w;
        }

        public double Ratio() {
            return (double) wage / quality;
        }

        public int CompareTo(Worker other) {
            return Ratio().CompareTo(other.Ratio());
        }
    }
}