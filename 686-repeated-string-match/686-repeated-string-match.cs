public class Solution {
    public int RepeatedStringMatch(string a, string b) {
        if(a == null || a == "") return -1;
        if(a.Length > b.Length){
            if(a.IndexOf(b) > -1) return 1;
            else if((a+a).IndexOf(b) > -1){
                return 2;
            }else return -1;
        }
        if(a == b) return 1; 
        
        var aset = a.ToHashSet();
        var bset = b.ToHashSet();
        if(bset.Intersect(aset).Count() != aset.Count){
            return -1;
        }
        var repeats = b.Length/a.Length + 2;
        int count = 1;
        var tmp = a;
        while(repeats-- > 0){
            tmp += a;
            count+=1;
            if(tmp.IndexOf(b) > -1){
                return count;
            }
        }
        return -1;
    }
}