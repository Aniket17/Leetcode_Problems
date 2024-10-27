public class Solution {
    public string MinWindow(string s, string t) {
        //create a map of s and t
        //check if s has all the chars+count of t otherwise early return
        //sliding window with i and j
        //whenever s[char] == t[char] reduce number of remaining
        //whenever remain == 0 then we will calculate the minwindow
        //minmize the window by moving i until the condition satisfies remain == 1
        var mapS = new Dictionary<char, int>();
        var mapT = new Dictionary<char, int>();
        foreach(var ch in s){
            mapS[ch] = mapS.GetValueOrDefault(ch) + 1;
        }

        foreach(var ch in t){
            mapT[ch] = mapT.GetValueOrDefault(ch) + 1;
        }
        foreach(var k in mapT.Keys){
            if(!mapS.ContainsKey(k) || mapS[k] < mapT[k]) return "";
        }

        int remain = mapT.Keys.Count(), i = 0, j = 0, minWindow = 0;
        var ans = s;
        while(j < s.Length){
            var ch = s[j];
            if(!mapT.ContainsKey(ch)){
                j++; 
                continue;
            }
            mapT[ch]--;
            if(mapT[ch] == 0){
                remain--;
            }
            if(remain == 0){
                //we have our window
                if(ans.Length > j - i + 1)
                    ans = s.Substring(i, j-i+1);

                //we want to minimize this further now
                //lets move i until we get remain == 1
                while(remain == 0){
                    var ich = s[i];
                    if(mapT.ContainsKey(ich)){
                        mapT[ich]++;
                        if(mapT[ich] > 0){
                            remain++;
                        }
                        //this is the point where we know that the current j-i+1 is the minWindow
                        var tmp = s.Substring(i, j-i+1);
                        if(tmp.Length < ans.Length){
                            ans = tmp;
                        }
                    }
                    i++;
                }
            }
            j++;
        }

        //Console.WriteLine($"remain: {remain}, mapT: {string.Join(",", mapT.Select(kv=>kv.Key + ":"+kv.Value))}");

        return ans;
    }
}

/*
ADOBECODEBANC ABC
remain = 1
ADO BECODEBANC
*/