public class Solution {
    public int LeastInterval(char[] tasks, int n)
    {
        // Step 1: Count task frequencies
        int[] frequencies = new int[26];
        foreach (char task in tasks)
        {
            frequencies[task - 'A']++;
        }
        
        // Step 2: Sort frequencies in descending order
        Array.Sort(frequencies);
        int maxFreq = frequencies[25];
        int idleSlots = (maxFreq - 1) * n;
        
        // Step 3: Fill idle slots with other tasks
        for (int i = 24; i >= 0 && frequencies[i] > 0; i--)
        {
            idleSlots -= Math.Min(frequencies[i], maxFreq - 1);
        }
        
        // Step 4: Calculate total intervals
        return tasks.Length + Math.Max(0, idleSlots);
    }
}