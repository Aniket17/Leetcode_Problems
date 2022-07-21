public class Solution {
    public int LargestValsFromLabels(int[] values, int[] labels, int numWanted, int useLimit) {
        var n = labels.Length;
        var items = new List<Item>();
        for(int i = 0; i < n; i++){
            items.Add(new Item(labels[i], values[i]));
        }
        items = items.OrderByDescending(x=>x.val).ToList();
        
        var usedMap = new Dictionary<int, int>();
        var sum = 0;
        foreach(var item in items){
            if(!usedMap.ContainsKey(item.label)){
                usedMap[item.label] = 0;
            }
            if(usedMap[item.label] >= useLimit) continue;
            if(numWanted == 0) break;
            sum += item.val;
            usedMap[item.label]++;
            numWanted--;
        }
        return sum;
    }
    
    public class Item{
        public int label;
        public int val;
        
        public Item(int l, int v){
            label = l;
            val = v;
        }
    }
}