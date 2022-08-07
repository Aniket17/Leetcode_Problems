public class Solution {
    Trie trie = new Trie();
    
    public IList<IList<string>> WordSquares(string[] words) {
        var ans = new List<IList<string>>();
        foreach(var word in words){
            trie.Add(word);
        }
        
        foreach(var word in words){
            CanMakeSquare(words, new List<string>(){word}, 1, ans);
        }
        return ans;
    }
    bool CanMakeSquare(string[] words, List<string> result, int pos, List<IList<string>> ans){
        if(pos == words[0].Length){
            ans.Add(result.ToList());
            return true;
        }

        var sb = new StringBuilder();
        foreach(var w in result) {
            sb.Append(w[pos]);
        }
        var prefix = sb.ToString();
        var matches = trie.WordsStartingWith(prefix);
        if(!matches.Any()) return false;
        foreach(var match in matches){
            result.Add(match);
            CanMakeSquare(words, result, pos + 1, ans);
            result.RemoveAt(result.Count - 1);
        }
        return true;
    }
    
    public class TrieNode{
        char ch;
        Dictionary<char, TrieNode> children;
        public List<string> Words;
        public TrieNode(char ch){
            this.ch = ch;
            children = new();
            Words = new();
        }
        public bool HasChild(char ch){
            return children.ContainsKey(ch);
        }
        public TrieNode GetChild(char ch){
            return children[ch];
        }
        public void Add(char ch){
            children[ch] = new TrieNode(ch);
        }
    }
    
    public class Trie{
        TrieNode root = new TrieNode('a');
        public void Add(string s){
            var tmp = root;
            foreach(var ch in s){
                if(!tmp.HasChild(ch)){
                    tmp.Add(ch);
                }
                tmp = tmp.GetChild(ch);
                tmp.Words.Add(s);
            }
        }
        
        public List<string> WordsStartingWith(string s){
            var tmp = root;
            foreach(var ch in s){
                if(!tmp.HasChild(ch)){
                    return new List<string>();
                }
                tmp = tmp.GetChild(ch);
            }
            return tmp.Words;
        }
    }
}

/*
backtracking

["lady","ball","area","lead","wall"]
[ball, area, lead, lady]

b a l l
a r e a
l e a d
l a d y
*/