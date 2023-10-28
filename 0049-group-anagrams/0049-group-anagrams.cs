public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        //use dict to get the freq map by char for each word => N*100
        //check each freq map with other maps => N^2
        var freqMap = new Dictionary<string, IList<string>>();
        
        for(int i = 0; i < strs.Length; i++){
            var word = strs[i];
            var freq = GetFreqMap(word);
            if(freqMap.ContainsKey(freq)){
                freqMap[freq].Add(word);
            }else{
                freqMap[freq] = new List<string>(){word};
            }
        }
//["eat","tea","tan","ate","nat","bat"]
//[a1e1t1,a1e1t1,a1n1t1,a1e1t1,a1n1t1,a1b1t1]
//[a1b1t1,a1e1t1,a1e1t1,a1e1t1,a1n1t1,a1n1t1]
        return freqMap.Select(x=>x.Value).ToList();
    }

    private string GetFreqMap(string word){
        SortedDictionary<char, int> map = new();
        foreach(var ch in word){
            if(map.ContainsKey(ch)){
                map[ch]++;
            }else{
                map[ch] = 1;
            }
        }
        var str = "";
        foreach(var kv in map){
            str += kv.Key.ToString() + kv.Value;
        }
        return str;
    }
}