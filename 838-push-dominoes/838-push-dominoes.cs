public class Solution {
    public string PushDominoes(string dominoes) {
        var len = dominoes.Length;
        var forces = new int[len];
        var force = 0;
        for(int i = 0; i < len; i++){
            if(dominoes[i] == 'R'){
                force = len;
            }else if(dominoes[i] == 'L'){
                force = 0;
            }else{
                force = Math.Max(force - 1, 0);
            }
            forces[i] += force;
        }
        
        force = 0;
        for(int i = len - 1; i >= 0; i--){
            if(dominoes[i] == 'L'){
                force = len;
            }else if(dominoes[i] == 'R'){
                force = 0;
            }else{
                force = Math.Max(force - 1, 0);
            }
            forces[i] -= force;
        }
        
        var sb = new StringBuilder();
        foreach(var f in forces){
            sb.Append(f > 0 ? 'R' : f < 0 ? 'L' : '.');
        }
        return sb.ToString();
    }
}