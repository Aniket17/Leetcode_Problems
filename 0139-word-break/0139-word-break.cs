public class Solution {
    Dictionary<string, bool> dp;
    public bool WordBreak(string s, IList<string> wordDict) {
        dp = new();
        var trie = new Trie();
        foreach(var w in wordDict){
            trie.AddWord(w);
        }

        return WordBreakUtil(s, trie);
    }

    bool WordBreakUtil(string s, Trie trie){
        if(s.Length == 0) return true;
        if(dp.ContainsKey(s)) return dp[s];
        for(int i = 0; i < s.Length; i++){
            if(trie.Search(s.Substring(0, i + 1)) && WordBreakUtil(s.Substring(i+1), trie)){
                return dp[s] = true;
            }
        }
        return dp[s] = false;
    }

    public class TrieNode{
        public char ch;
        public Dictionary<char, TrieNode> children;
        public bool isWord;
        public TrieNode(char c = '\0'){
            ch = c;
            children = new();
        }
    }

    public class Trie{
        TrieNode root = new();

        public void AddWord(string s){
            var dummy = root;
            foreach(var ch in s){
                if(!dummy.children.ContainsKey(ch)){
                    dummy.children.Add(ch, new());
                }
                dummy = dummy.children[ch];
            }
            dummy.isWord = true;
        }

        public bool Search(string s){
            var dummy = root;
            foreach(var ch in s){
                if(!dummy.children.ContainsKey(ch)){
                    return false;
                }
                dummy = dummy.children[ch];
            }
            return dummy.isWord;
        }
    }
}