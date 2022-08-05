public class Solution {
    public int TotalFruit(int[] fruits) {
        if(fruits.Length == 0) return 0;
        HashSet<int> baskets = new();
        int lastPickedIndex = 0;
        baskets.Add(fruits[0]);
        int count = 1;
        int max = 1;
        
        for(int i = 1; i < fruits.Length; i++){
            var curr = fruits[i];
            if(baskets.Contains(curr)){
                if(fruits[lastPickedIndex] != curr){
                    lastPickedIndex = i;
                }
                count++;
            }else{
                if(baskets.Count == 1){
                    count++;
                }else{
                    baskets.RemoveWhere(x => x != fruits[lastPickedIndex]);
                    count = i - lastPickedIndex + 1;
                }
                lastPickedIndex = i;
                baskets.Add(curr);
            }
            
            max = Math.Max(count, max);
        }
        return max;
    }
}

/*
[1,0,3,4,3]
*/