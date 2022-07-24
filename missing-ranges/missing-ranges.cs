public class Solution {
    public IList<string> FindMissingRanges(int[] nums, int lower, int upper) {
        var ans = new List<string>();
        if(nums.Length == 0){
            if(lower == upper){
                return new List<string>(){$"{lower}"};
            }
            return new List<string>(){$"{lower}->{upper}"};
        }
        
        var first = nums[0];
        if(first - lower == 1){
            ans.Add($"{lower}");
        }else if(first != lower){
            ans.Add($"{lower}->{first-1}");
        }
        for(int i = 0; i < nums.Length - 1; i++){
            var next = nums[i + 1];
            var curr = nums[i];
            if(next - curr > 2){
                ans.Add($"{curr + 1}->{next-1}");
            }else if(next - curr == 2){
                ans.Add($"{curr + 1}");
            }
        }
        
        var last = nums[nums.Length - 1];
        if(upper - last == 1){
            ans.Add($"{upper}");
        }else if(last != upper){
            ans.Add($"{last + 1}->{upper}");
        }
        return ans;
    }
}