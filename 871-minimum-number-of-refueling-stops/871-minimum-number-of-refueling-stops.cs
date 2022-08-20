public class Solution {
    Dictionary<string, int> memo;
    public int MinRefuelStops2(int target, int startFuel, int[][] stations) {
        int N = stations.Length;
        long[] dp = new long[N + 1];
        dp[0] = startFuel;
        for (int i = 0; i < N; ++i)
        {
            for (int t = i; t >= 0; --t)
            {
                if (dp[t] >= stations[i][0])
                    dp[t+1] = Math.Max(dp[t+1], dp[t] + (long) stations[i][1]);
            }
        }

        for (int i = 0; i <= N; ++i)
        {
            if (dp[i] >= target) return i;
        }
        return -1;
    }
    
    
    public class IntComparer:IComparer<int>{
        public int Compare(int a, int b) => b-a;
    }
    public int MinRefuelStops(int target, int tank, int[][] stations){
         // pq is a maxheap of gas station capacities
        PriorityQueue<int,int> pq = new(new IntComparer());
        int ans = 0, prev = 0;
        foreach(int[] station in stations) {
            int location = station[0];
            int capacity = station[1];
            tank -= location - prev;
            while (pq.Count > 0 && tank < 0) {  // must refuel in past
                tank += pq.Dequeue();
                ans++;
            }

            if (tank < 0) return -1;
            pq.Enqueue(capacity, capacity);
            prev = location;
        }

        // Repeat body for station = (target, inf)
        {
            tank -= target - prev;
            while (pq.Count > 0 && tank < 0) {
                tank += pq.Dequeue();
                ans++;
            }
            if (tank < 0) return -1;
        }
        return ans;
    }
    int Solve(int fuel, int curr, int end, int[][] stations, int pos){
        var distanceLeft = end - curr;
        if(distanceLeft <= 0) return 0;
        if(fuel >= distanceLeft) return 0;
        if(pos >= stations.Length) return int.MaxValue;
        
        var stopDist = stations[pos][0] - curr;
        var stopFuel = stations[pos][1];
        if(fuel < stopDist){
            return int.MaxValue;
        }
        var key = $"{fuel},{curr}";
        if(memo.ContainsKey(key)){
            return memo[key];
        }
        
        var stop = Solve(fuel-stopDist+stopFuel, curr+stopDist, end, stations, pos+1);
        var dontStop = Solve(fuel, curr, end, stations, pos+1);
        
        if(stop == int.MaxValue){
            return dontStop;
        }
        return memo[key] = Math.Min(1+stop, dontStop);
    }
}

/*
target = 100, startFuel = 10, stations = [[10,60],[20,30],[30,30],[60,40]]
stopDist
*/