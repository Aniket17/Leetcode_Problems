public class Solution {
    public bool IsStrobogrammatic(string num) {
        var set = new HashSet<int>(){1,0,9,6,8};
        var invalid = num.Select(x=> (int)x-'0').Any(x=> !set.Contains(x));
        if(invalid) return false;
        
        for(int i = 0; i < num.Length; i++){
            if(num[i] == '6'){
                // it should match with other index
                if(num[num.Length - 1 - i] != '9'){
                    return false;
                }
            }
            if(num[i] == '9'){
                // it should match with other index
                if(num[num.Length - i - 1] != '6'){
                    return false;
                }
            }
            if(num[i] == '1'){
                // it should match with other index
                if(num[num.Length - 1 - i] != '1'){
                    return false;
                }
            }
        }
        return true;
    }
}

/*
6->9
8->8
0->0

690
960
*/