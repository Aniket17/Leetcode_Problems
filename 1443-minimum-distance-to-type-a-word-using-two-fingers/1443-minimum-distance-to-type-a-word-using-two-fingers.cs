public class Solution {
    Dictionary<(int, int, int), int> memo = new();

    public int MinimumDistance(string word) => MinimumDistanceUtil(word, 0, -1, -1);

    int MinimumDistanceUtil(string word, int index, int rPos, int lPos){
        if(index >= word.Length) return 0;
        if(memo.ContainsKey((index, rPos, lPos))) return memo[(index, rPos, lPos)];
        var rDist = MinimumDistanceUtil(word, index+1, word[index]-'A', lPos);;
        var lDist = MinimumDistanceUtil(word, index+1, rPos, word[index]-'A');
        
        if(rPos != -1){
            //right hand is not free
            rDist += GetDistance(rPos, word[index]-'A');
        }
        if(lPos != -1){
            //right hand is not free
            lDist += GetDistance(lPos, word[index]-'A');
        }

        return memo[(index, rPos, lPos)] = Math.Min(rDist, lDist);
    }

    int GetDistance(int i, int j){
        var n = 6;
        return Math.Abs(i/n - j/n) + Math.Abs(i%n - j%n);
    }
    //i will choose right or left hand every char
    //dp(index to word, currRight, currLeft) = Math.Min(currdist + dp(index+1, currRight', currLeft), currdist + dp(index+1, currRight, currLeft'));
}