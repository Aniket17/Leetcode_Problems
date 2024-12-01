public class Solution {
    public int Change(int amount, int[] coins) {
        return GetCombinations(amount, coins, coins.Length - 1, new Dictionary<(int, int), int>());
    }

    private int GetCombinations(int amount, int[] coins, int index, Dictionary<(int, int), int> memo) {
        if (amount == 0) return 1; // Found a valid combination
        if (amount < 0 || index < 0) return 0; // Invalid combination

        if (memo.ContainsKey((amount, index))) return memo[(amount, index)];

        // Option 1: Include the current coin
        int include = GetCombinations(amount - coins[index], coins, index, memo);

        // Option 2: Exclude the current coin
        int exclude = GetCombinations(amount, coins, index - 1, memo);

        memo[(amount, index)] = include + exclude;
        return memo[(amount, index)];
    }
}