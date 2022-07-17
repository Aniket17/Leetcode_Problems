public class Solution {
    public IList<IList<string>> GroupStrings(string[] strings) {
        var map = new Dictionary<string, IList<string>>();
        foreach(var str in strings){
            var hash = str.Length.ToString();
            for(int i = 1; i < str.Length; i++){
                var count = str[i] - str[i - 1];
                if(count < 0){
                    count += 26;
                }
                hash += $"{count}";
            }
            //Console.WriteLine($"{hash}, {str}");
            if(!map.ContainsKey(hash)){
                map[hash] = new List<string>();
            }
            map[hash].Add(str);
        }
        return map.Select(x=>x.Value).ToList();
    }
}