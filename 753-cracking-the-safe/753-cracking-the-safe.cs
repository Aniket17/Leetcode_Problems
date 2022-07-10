public class Solution{
	StringBuilder ans = new StringBuilder();
	public string CrackSafe(int n, int k){
        if(n == 1 && k == 1){
            return "0";
        }
        var sb = new StringBuilder();
        for(int i = 0; i < n - 1; i++){
            sb.Append("0");
        }
        Dfs(sb.ToString(), k, new HashSet<string>());
        ans.Append(sb);
        return ans.ToString();
    }

    public void Dfs(string s, int k, HashSet<string> seen){
        for(int i = 0; i < k; i++){
            var newVal = s + i;
            if(!seen.Contains(newVal)){
                seen.Add(newVal);
                Dfs(newVal.Substring(1), k, seen);
                ans.Append(i);
            }
        }
    }
}

