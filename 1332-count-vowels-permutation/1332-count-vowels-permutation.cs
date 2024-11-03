public class Solution {
    Dictionary<char, List<char>> options = new();
    Dictionary<(char, int), int> dp = new();
    int MOD = 100_000_0007;
    public int CountVowelPermutation(int n) {
        // CountVowelPermutationUtil(a, n-1) for a to u, and retrun the sum;
        // CountVowelPermutationUtil(prev, remChars)
        // remChar == 0 return 0;
        // remChar == 1 {
        //}
        // a = e
        // sum = 0
        //  for(i: validFolloweChar){
        //  sum+=CountVowelPermutationUtil(i, remChars-1);
        //}
        // return
        if(n == 1) return 5;
        options.Add('a', new List<char>(){'e'});
        options.Add('e', new List<char>(){'a','i'});
        options.Add('i', new List<char>(){'a', 'e', 'o', 'u'});
        options.Add('o', new List<char>(){'i', 'u'});
        options.Add('u', new List<char>(){'a'});
        var count = 0;
        foreach(var key in options.Keys){
            count = count % MOD + (CountVowelPermutation(key, n - 1) % MOD);
        }
        return count % MOD;
    }

    int CountVowelPermutation(char prev, int remain){
        if(remain == 0) return 0;
        if(remain == 1) return options[prev].Count;
        if(dp.ContainsKey((prev, remain))) return dp[(prev, remain)];
        var count = 0;
        foreach(var nei in options[prev]){
            count = count % MOD + (CountVowelPermutation(nei, remain - 1) % MOD);
        }
        return dp[(prev, remain)] = count % MOD;
    }
}