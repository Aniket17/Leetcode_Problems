public class Solution {
    public string GetPermutation(int n, int k) {
        var ans = new List<string>();
        var counts = new Dictionary<int, int>();
        for(int i = 1; i <= n; i++){
            counts.Add(i, 1);
        }
        GetPermutations(n, counts, new List<int>(), k, ans);
        return ans.Last();
    }
    
    void GetPermutations(int n, Dictionary<int, int> counts, List<int> current, int k, List<string> ans){
        if(ans.Count == k){
            return;
        }
        if(current.Count() == n){
            var str = string.Empty;
            if(ans.Count == k - 1){
                str = String.Join("", current);
            }
            ans.Add(str);
            return;
        }
        
        foreach(var key in counts.Keys){
            if(counts[key] <= 0) continue;
            current.Add(key);
            counts[key]--;
            GetPermutations(n, counts, current, k, ans);
            current.RemoveAt(current.Count - 1);
            counts[key]++;
        }
    }
}