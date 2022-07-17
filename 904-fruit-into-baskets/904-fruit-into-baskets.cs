public class Solution {
    public int TotalFruit(int[] fruits) {
       if(fruits.Length == 1) return 1;
        int j = 0;
         
        int second = fruits[0];
        int secondIndex = 0;
        int first = -1;
        int firstIndex = -1;
        
        int maxSize = 0;
        
        
        for(int i = 1; i < fruits.Length; i++) {
                        
            if(fruits[i] != first && fruits[i] != second) {
                if(first == -1) {
                    first = fruits[i];
                    firstIndex = i;
                } else {
                    if(fruits[i-1] == second) {
                        first = fruits[i];
                        firstIndex = i;
                        j = secondIndex;
                    } else {
                        second = fruits[i];
                        secondIndex = i;
                        j = firstIndex;
                    }
                }
            } else if(fruits[i-1] != fruits[i]) {
                if(fruits[i] == first) {
                    firstIndex = i;
                } else {
                    secondIndex = i;
                }
            }
            
            maxSize = Math.Max(maxSize, Math.Abs(i- j + 1));
        }
        
        return maxSize;
    }
}

/*
[1,2,1,3,2,2]
*/