public class Solution {
    public int OddEvenJumps(int[] A) {
        int count = 0;
        
        int n = A.Length;
        if(n==0)
            return count;
        
        bool[] higher = new bool[n];
        bool[] lower = new bool[n];
        int [] nextHighers = GetNextJumps(A, true);
        int [] nextLowers = GetNextJumps(A, false);
        
        higher[n-1] = true;
        lower[n-1] = true;
        count++;
        
        for(int i=n-2;i>=0;i--){
            int hi = nextHighers[i];
            int low = nextLowers[i];
            
            if(hi > -1) higher[i] = lower[hi];
            if(low > -1) lower[i] = higher[low];
            
            if(higher[i])
                count++;
        }
         
        return count;
    }
    
    private int[] GetNextJumps(int[] A, bool high){
        int[] next = Enumerable.Repeat(-1, A.Length).ToArray();
        
        var sortedList = A.Select((x, i) => new KeyValuePair<int, int>(x, i));
        
        if(high)
            sortedList = sortedList.OrderBy(x => x.Key).ToList();
        else
            sortedList = sortedList.OrderByDescending(x => x.Key).ToList();
                            
        Stack<int> stack = new Stack<int>();
        foreach (var e in sortedList)
        {
            while (stack.Count > 0 && stack.Peek() < e.Value)
                next[stack.Pop()] = e.Value;
            stack.Push(e.Value);
        }
        return next;
    }
    
}