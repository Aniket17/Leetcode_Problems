public class Solution {
    public IList<string> LetterCombinations(string digits) {
        var numberMap = new Dictionary<int, List<char>>();
        if(digits == "") return new List<string>();
        var ch = 'a';
        for(int i = 2; i < 10; i++){
            int count = i == 7 || i == 9 ? 4 : 3;
            numberMap[i] = new List<char>();
            while(count-- != 0){
                numberMap[i].Add(ch++);
            }
        }
        //Console.WriteLine(string.Join("\n", numberMap.Select(x=>$"{x.Key}: {string.Join(",", x.Value)}")));
        var result = new List<string>();
        Permute(numberMap, digits, 0, "", result);
        return result;
    }
    
    private void Permute(Dictionary<int, List<char>> map, string digits, int pos, string ans, List<string> result){
        if(digits.Length == ans.Length){
            result.Add(ans);
            return;
        }
        for(int i = pos; i < digits.Length; i++){
            foreach(var ch in map[digits[i] - '0']){
                Permute(map, digits, i+1, ans+ch.ToString(), result);
            }
        }
    }
}

/*
S - 
R
T
B
O
T

*/