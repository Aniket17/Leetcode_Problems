public class Solution {
    public string GetPermutation(int n, int k) {
        var set = new HashSet<int>();
        var result = new List<string>();
        PermuteUtil(n,k, "", set, result);
        return result.Last();
    }
    
    public void PermuteUtil(int n, int k, string curr, HashSet<int> set, List<string> result){
        if(result.Count == k) return;
        if(curr.Length == n) {
            result.Add(curr);
            return;
        }
        
        for(int i = 1; i <= n; i++){
            if(set.Contains(i)) continue;
            set.Add(i);
            PermuteUtil(n, k, curr + i.ToString(), set, result);
            set.Remove(i);
        }
    }
}