public class Solution {
    public string LargestNumber(int[] nums) {
        var strNums = nums.Select(x=>x.ToString()).ToArray();
        Array.Sort(strNums, Comparer<string>.Create((a, b) => (b+a).CompareTo((a + b))));
        if(strNums[0] == "0") return "0";
        return string.Join("", strNums);
    }
}

/*
largest number len is sum of all len(nums[i])
=> maximize this
for i = 0 ... i < len
    choose the lexographically largest  
*/