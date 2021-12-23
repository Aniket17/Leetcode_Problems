public class Solution {
    public int NumTilePossibilities(string tiles) {
        var map = new Dictionary<char, int>();
        var set = new HashSet<string>();
        
        foreach(char c in tiles){
            map[c] = map.GetValueOrDefault(c)+1;
        }
        Permute(map, "", set);
        return set.Count;
    }
    
    private void Permute(Dictionary<char, int> map, string curr, HashSet<string> set){
        if(!string.IsNullOrEmpty(curr))set.Add(curr);
        foreach(var key in map.Keys){
            if(map[key] <= 0) continue;
            map[key]--;
            Permute(map, curr+key, set);
            map[key]++;
        }
        return;
    }
}

/*
000 
001    
010
011
100
101
111
110






*/