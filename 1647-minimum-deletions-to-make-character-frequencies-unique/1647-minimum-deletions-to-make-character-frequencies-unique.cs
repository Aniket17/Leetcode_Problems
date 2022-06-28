public class Solution {
    public int MinDeletions(string s) {
        var arr = new int[26];
        Array.Fill(arr, 0);
        
        foreach(char ch in s){
            arr[ch - 'a']++;
        }
        
        Array.Sort(arr);
        var set = new HashSet<int>();
        
        set.Add(arr[0]);
        
        var deletions = 0;
        
        for(int i = 1; i < arr.Length; i++){
            if(set.Contains(arr[i])){
                var newFreq = Reduce(arr[i], set);
                deletions += (arr[i] - newFreq);
                arr[i] = newFreq;
            }
            set.Add(arr[i]);
        }
        return deletions;
    }
    
    private int Reduce(int num, HashSet<int> set){
        for(int i = num - 1; i >= 0; i--){
            if(set.Contains(i)){
                continue;
            }
            
            return i;
        }
        return 0;
    }
}

/*
aaabbbcc
a: 3
b: 3
c: 2
ceabaacb
e:1
b:2
c:2
a:3



create a map of char->int => O(n)
sort it by val => 26* O(26)

foreach val in map
    put val in hashset
    set has val? reduce O(26)
*/