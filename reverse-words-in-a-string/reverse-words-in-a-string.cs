public class Solution {
    public string ReverseWords(string s) {
        var arr = s.Trim().Split(" ").Where(x=>!string.IsNullOrEmpty(x.Trim())).ToArray();
        Array.Reverse(arr);
        return String.Join(" ", arr);
    }
}