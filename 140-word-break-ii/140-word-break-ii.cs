public class Solution {
    List<string> _results = new List<string>();
    
    public IList<string> WordBreak(string s, IList<string> wordDict) {
        var wordSet = new HashSet<string>(wordDict);
        
        backtrack(s, 0, new StringBuilder(), new StringBuilder(), wordSet);
        
        return _results;
        
    }
    
    void backtrack(string s, int i, StringBuilder currentWord, StringBuilder phrase, ISet<string> wordSet) 
    {
        // choice, add space or keep going
        // constraint, to add space, current word must be in dictionary
        // goal, add spaces when words are complete
        if (i == s.Length)
        {
            if (wordSet.Contains(currentWord.ToString())) 
            {
                var p = phrase.ToString() + currentWord.ToString();
                _results.Add(p);
            }
            return;
        }
        
        // eat another char
        currentWord.Append(s[i]);
        backtrack(s, i+1, currentWord, phrase, wordSet);
        currentWord.Length -= 1;
        
        // space
        if (wordSet.Contains(currentWord.ToString()))
        {
            var toAppend = currentWord + " ";
            phrase.Append(toAppend);
            backtrack(s, i, new StringBuilder(), phrase, wordSet);
            phrase.Length -= toAppend.Length;
        }
    }
}