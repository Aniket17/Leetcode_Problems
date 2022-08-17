public class Solution {
    public int UniqueMorseRepresentations(string[] words) {
        var map = new string[26]{".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."
        };
        
        var hashSet = new HashSet<string>();
        foreach(var w in words){
            hashSet.Add(string.Join("",w.Select(c=> map[c-'a'])));
        }
        return hashSet.Count;
    }
}