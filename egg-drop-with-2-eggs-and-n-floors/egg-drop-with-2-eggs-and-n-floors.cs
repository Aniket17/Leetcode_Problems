public class Solution {
    public int TwoEggDrop(int floors, int eggs = 2) {
        int[,] T = new int[eggs+1, floors+1];
        int c =0;
        for(int i=0; i <= floors; i++){
            T[1,i] = i;
        }
        
        for(int e = 2; e <= eggs; e++){
            for(int f = 1; f <=floors; f++){
                T[e,f] = int.MaxValue;
                for(int k = 1; k <=f ; k++){
                    c = 1 + Math.Max(T[e-1, k-1], T[e, f-k]);
                    if(c < T[e, f]){
                        T[e, f] = c;
                    }
                }
            }
        }
        return T[eggs, floors];
    }
    
    private int CalculateRecursive(int floors, int eggs){
        if(floors <= 1){
            return floors;
        }
        if(eggs <= 0){
            return 0;
        }
        var min = int.MaxValue;
        
        for(int i = 1; i <= floors; i++){
            var val = 1 + Math.Max(CalculateRecursive(i - 1, eggs - 1), CalculateRecursive(floors - i, eggs));
            min = Math.Min(min, val);
        }
        return min;
    }
    
}