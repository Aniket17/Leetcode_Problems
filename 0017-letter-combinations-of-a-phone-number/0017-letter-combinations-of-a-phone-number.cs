public class Solution {
    Dictionary<char, List<char>> map;
    public IList<string> LetterCombinations(string digits) {
        var ans = new List<string>();
        if(digits.Length == 0) return ans;
        
        map = new();
        map.Add('2', new List<char>(){'a','b','c'});
        map.Add('3', new List<char>(){'d','e','f'});
        map.Add('4', new List<char>(){'g','h','i'});
        map.Add('5', new List<char>(){'j','k','l'});
        map.Add('6', new List<char>(){'m','n','o'});
        map.Add('7', new List<char>(){'p','q','r', 's'});
        map.Add('8', new List<char>(){'t','u','v'});
        map.Add('9', new List<char>(){'w','x','y', 'z'});
        ans = map[digits[0]].Select(x=>x.ToString()).ToList();
        for(int i = 1; i < digits.Length; i++){
            ans = GenerateAllCombinations(ans, map[digits[i]]);
        }
        return ans;
    }
    List<string> GenerateAllCombinations(List<string> curr, List<char> chars){
        var ans = new List<string>();
        for(int i = 0; i < curr.Count; i++){
            foreach(char ch in chars){
                ans.Add(curr[i]+ch);
            }
        }
        return ans;
    }
}