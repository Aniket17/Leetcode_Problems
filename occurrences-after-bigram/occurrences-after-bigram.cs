public class Solution {
    public string[] FindOcurrences(string text, string first, string second) {
        var firstList = text.Split(" ").ToList();
        var secondList = firstList.Skip(1).ToList();
        var thirdList = secondList.Skip(1).ToList();
        var ans = new List<string>();
        for(int i = 0; i < thirdList.Count; i++){
            if(firstList[i] == first && second == secondList[i]){
                ans.Add(thirdList[i]);
            }
        }
        return ans.ToArray();
    }
}