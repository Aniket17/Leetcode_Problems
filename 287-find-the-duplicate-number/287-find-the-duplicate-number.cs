public class Solution {
    public int FindDuplicate(int[] nums) {
        //tortoise and hare implementation T - O(n) and S - O(1)
        int tortoise = nums[0];
        int hare = nums[0];
        
        do {
            tortoise = nums[tortoise];
            hare = nums[nums[hare]];
        } while (tortoise != hare);

        // Find the "entrance" to the cycle.
        tortoise = nums[0];
        
        while (tortoise != hare) {
            tortoise = nums[tortoise];
            hare = nums[hare];
        }
        return hare;
    }
}

/*
[-1,-3,-4,-2,2]
*/