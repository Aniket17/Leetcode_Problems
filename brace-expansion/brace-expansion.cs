public class Solution {
    public string[] Expand(string s) {
        var ans = new List<string>();
        var older = new List<string>();
        
        var curr = "";
        for(int i = s.Length - 1; i >= 0; i--){
            var ch = s[i];
            if(ch == '}'){
                var med = new List<string>();
                var rep = GetRepeaters(s, i - 1);
                i = rep.Item1;
                foreach(char r in rep.Item2){
                    var pre = $"{r}{curr}";
                    med.Add(pre);
                }
                Append(older, med);
                curr = "";
            }else{
                curr += ch;
            }
        }
        if(curr.Length > 0 && !older.Any()){
            return new string[]{ new String(curr.Reverse().ToArray()) };
        }else if(curr.Length == 0){
            return older.OrderBy(x=>x).ToArray();
        }else if(older.Any()){
            Append(older, new List<string>(){curr});
        }
        return older.OrderBy(x=>x).ToArray();
    }
    
    
    private void Append(List<string> d, List<string> x){
        if (d.Any())
            {
                var tmp = d.ToList();
                d.Clear();
                tmp.ForEach(w => {
                    x.ForEach(z => {
                        d.Add($"{z}{w}");
                    });
                });
            }
            else
            {
                x.ForEach(z => {
                    d.Add($"{z}");
                });
            }
    }
    
    private Tuple<int, List<char>> GetRepeaters(string s, int pos){
        var repeats = new List<char>();
        while(pos >= 0){
            if(s[pos] == '{') break;
            if(s[pos] == ',') {
                pos--;
                continue;
            };
            repeats.Add(s[pos]);
            pos--;
        }
        
        return Tuple.Create(pos, repeats);
    }
}


/*

"{a,b}c{d,e}f"


*/