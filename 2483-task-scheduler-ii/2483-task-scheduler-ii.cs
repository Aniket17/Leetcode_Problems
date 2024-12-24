public class Solution {
    public long TaskSchedulerII(int[] tasks, int space) {
        // Dictionary to track when a task can be next executed
        Dictionary<int, long> cooldown = new Dictionary<int, long>();
        long currentDay = 0L;

        foreach (int task in tasks)
        {
            // Check if the task is in cooldown
            if (cooldown.ContainsKey(task) && cooldown[task] > currentDay)
            {
                // Wait until the task becomes available
                currentDay = cooldown[task];
            }

            // Execute the task
            currentDay++;

            // Set the cooldown time for the task
            cooldown[task] = currentDay + space;
        }

        return currentDay;
    }
}