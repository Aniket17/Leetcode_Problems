public class Solution {
    public int TotalFruit(int[] fruits) {
        var map = new Dictionary<int, int>();
        int i = 0, j = 0, max = 0;

        while(j < fruits.Length){
            if(map.ContainsKey(fruits[j])){
                map[fruits[j]]++;
            }else{
                map[fruits[j]] = 1;
            }
            if(map.Keys.Count > 2){
                //reduce by moving i
                while(map.Keys.Count != 2){
                    map[fruits[i]]--;
                    if(map[fruits[i]] == 0){
                        map.Remove(fruits[i]);
                    }
                    i++;
                }
            }

            //calculate
            max = Math.Max(max, map.Values.Sum(x=>x));
            j++;
        }
        return max;
    }
}