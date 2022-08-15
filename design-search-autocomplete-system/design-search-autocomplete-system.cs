public class AutocompleteSystem {
    Dictionary<string, Sentence> map = new();
    StringBuilder current = new();
    Trie trie = new();

    public AutocompleteSystem(string[] sentences, int[] times) {
        for(int i = 0; i < sentences.Length; i++){
            var s = sentences[i];
            if(map.ContainsKey(s)){
                map[s].hotness += times[i];
            }else{
                map[s] = new Sentence(s, times[i]);
            }
            trie.Append(s);
        }
    }
    
    public IList<string> Input(char c) {
        if(c != '#'){
            current.Append(c);
            var str = current.ToString();
            var matches = trie.StartsWith(str)
                .Select(x=> map[x])
                .OrderByDescending(x=>x.hotness)
                .ThenBy(x=>x.s)
                .Take(3)
                .Select(x=>x.s)
                .ToList();
            return matches;
        }else{
            var str = current.ToString();
            if(map.ContainsKey(str)){
                map[str].hotness += 1;
            }else{
                map[str] = new Sentence(str, 1);
            }
            trie.Append(str);
            current = new();
            return new List<string>();
        }
    }
    
    class TrieNode{
        public Dictionary<char, TrieNode> children = new();
        public char val = '\0';
        public bool isWord = false;
        public HashSet<string> words = new();
        public TrieNode(char ch){
            val = ch;
        }
    }
    
    class Trie{
        TrieNode root = new TrieNode('\0');
        public void Append(string s){
            var temp = root;
            foreach(var ch in s){
                if(!temp.children.ContainsKey(ch)){
                    temp.children[ch] = new TrieNode(ch);
                }
                temp = temp.children[ch];
                temp.words.Add(s);
            }
            temp.isWord = true;
        }
        
        public List<string> StartsWith(string s){
            var temp = root;
            foreach(var ch in s){
                if(!temp.children.ContainsKey(ch)){
                    return new List<string>();
                }
                temp = temp.children[ch];
            }
            return temp.words.ToList();
        }
    }
    
    public class Sentence{
        public string s;
        public int hotness;
        public Sentence(string s, int h){
            this.s = s;
            hotness = h;
        }
    }
}

/**
 * Your AutocompleteSystem object will be instantiated and called as such:
 * AutocompleteSystem obj = new AutocompleteSystem(sentences, times);
 * IList<string> param_1 = obj.Input(c);
 */