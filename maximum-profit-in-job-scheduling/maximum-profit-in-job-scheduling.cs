public class Solution {
    public class Job
    {
        public int start;
        public int end;
        public int profit;
        
        public Job(int start, int end, int profit)
        {
            this.start = start;
            this.end = end;
            this.profit = profit;
        }
    }
    Dictionary<int, int> memo = new Dictionary<int, int>();
    public int JobScheduling(int[] startTime, int[] endTime, int[] profit) {
        var jobs = new List<Job>();
        for(int i = 0; i < startTime.Length; i++){
            jobs.Add(new Job(startTime[i], endTime[i], profit[i]));
        }
        var sortedJobs = jobs.OrderBy(x=>x.start).ThenBy(x=>x.end).ToArray();
        return FindMaxProfit(sortedJobs, 0);        
    }
    
    private int FindMaxProfit(Job[] jobs, int i)
    {
        if(i >= jobs.Length) return 0;
        
        if(memo.ContainsKey(i)) return memo[i];
        
        var nextJobIndex = FindNextJob(jobs, jobs[i].end);
        
        var profit = Math.Max(FindMaxProfit(jobs, i + 1), jobs[i].profit + FindMaxProfit(jobs, nextJobIndex));
        
        memo[i] = profit;
        
        return profit;
    }
    
    private int FindNextJob(Job[] jobs, int lastEnd) {
        int start = 0, end = jobs.Length - 1, nextIndex = jobs.Length;
        
        while (start <= end) {
            int mid = (start + end) / 2;
            if (jobs[mid].start >= lastEnd) {
                nextIndex = mid;
                end = mid - 1;
            } else {
                start = mid + 1;
            }
        }
        return nextIndex;
    }
}

/*
//brute force - take profit for every slot n^2 + nlogn for sorting
//

[1,2,3,3],
[3,4,5,6],
[50,10,40,70]
*/