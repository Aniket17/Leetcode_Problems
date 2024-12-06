public class Solution {
    public int[] ResultsArray(int[] nums, int k) {
        var deque = new LinkedList<int>();
        var result = new List<int>();
        for(int i = 0; i < nums.Length; i++){
            //check if deque size exceeds, delete the first
            if (deque.Count > 0 && deque.First() < i - k + 1)
            {
                deque.RemoveFirst();
            }
            //validate valid increasing order property in dequeue
            if (deque.Count > 0 && nums[i] - nums[i - 1] != 1)
            {
                //clear the dequeue
                deque.Clear();
            }
            deque.AddLast(i);
            if (i >= k - 1)
            {
                if (deque.Count == k)
                {
                    result.Add(nums[deque.Last()]);
                }
                else
                {
                    result.Add(-1);
                }
            }
        }

        return result.ToArray();
    }
}

/*
[1,1,2,3,3,2,5]
[1,0,1,1,-1,-1,3]



*/