public class Solution {
    public string ReverseWords(string s) {
        var arr = s.Trim().Split(" ")
            .ToArray();
        Array.Reverse(arr);
        return string.Join(" ", arr.ToList().Where(x=> !string.IsNullOrEmpty(x))
            .Select(x=>x.Trim()));
    }
}