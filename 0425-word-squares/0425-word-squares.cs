public class Solution {
    Dictionary<string, List<string>> map;
    IList<IList<string>> ans;
    int LEN = 0;
    public IList<IList<string>> WordSquares(string[] words) {
        //lets say, we chose abat as first word, ["abat","baba","atan","atal"]
        //we will start at 0,0 and see if there is any word which starts with a
        //yes, there is atal => now we have abat, atal
        //now we will move to second index, that means we need word with "aa" as prefix and there is no such word
        //now we backtrack and see if baba works as first word ...
        //we need some kinda prefix map to store the prefixes and words

        map = new();
        ans = new List<IList<string>>();
        LEN = words[0].Length;
        foreach(var word in words){
            var sb = new StringBuilder();
            for(int i = 0; i < word.Length-1; i++){
                sb.Append(word[i]);
                var pre = sb.ToString();
                if(!map.ContainsKey(pre)) map[pre] = new();
                map[pre].Add(word);
            }
        }

        foreach(var word in words){
            Backtrack(new List<string>(){word}, 1);
        }
        return ans;
    }

    void Backtrack(List<string> words, int index){
        if(words.Count == LEN){
            ans.Add(words.ToList());
            return;
        }
        var curr = words[0];
        var sb = new StringBuilder();
        foreach(var word in words){
            sb.Append(word[index]);
        }
        var prefix = sb.ToString();
        Console.WriteLine(prefix);
        if(!map.ContainsKey(prefix)) return;
        
        foreach(var word in map[prefix]){
            //check if its valid nei
            words.Add(word);
            Backtrack(words, index+1);
            words.RemoveAt(words.Count - 1);
        }
    }
}

/*
["abat","baba","atan","atal"]
b a b a
a b a t
b a b a
a t a l

*/