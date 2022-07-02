public class Solution {
    public string GetPermutation(int n, int k) {
        var nums = new List<int>();
        int fact = 1;
        
        for(int i = 1; i < n; i++)
        {
            fact = fact * i;
            nums.Add(i);
        }
        nums.Add(n);
        k = k - 1;
        var sb = new StringBuilder();
        while(true){
            sb.Append(nums[k / fact].ToString());
            nums.RemoveAt(k / fact);
            
            if(nums.Count == 0) break;
            
            k = k % fact;
            fact = fact / nums.Count;
        }
        return sb.ToString();
    }
}