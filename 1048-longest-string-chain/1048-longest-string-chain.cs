public class Solution {
    public int LongestStrChain(string[] words) {
        Dictionary<String, int> memo = new Dictionary<String, int>();
        HashSet<String> wordsPresent = words.ToHashSet();
        
        int ans = 0;
        foreach (String word in words) {
            ans = Math.Max(ans, dfs(wordsPresent, memo, word));
        }
        return ans;
    }
    
    private int dfs(HashSet<String> words, Dictionary<String, int> memo, String currentWord) {
        // If the word is encountered previously we just return its value present in the map (memoization).
        if (memo.ContainsKey(currentWord)) {
            return memo[currentWord];
        }
        // This stores the maximum length of word sequence possible with the 'currentWord' as the
        int maxLength = 1;
        StringBuilder sb = new StringBuilder(currentWord);

        // creating all possible strings taking out one character at a time from the `currentWord`
        for (int i = 0; i < currentWord.Length; i++) {
            sb.Remove(i,1);
            String newWord = sb.ToString();
            // If the new word formed is present in the list, we do a dfs search with this newWord.
            if (words.Contains(newWord)) {
                int currentLength = 1 + dfs(words, memo, newWord);
                maxLength = Math.Max(maxLength, currentLength);
            }
            sb.Insert(i, currentWord[i]);
        }
        memo[currentWord] = maxLength;

        return maxLength;
    }
    
}