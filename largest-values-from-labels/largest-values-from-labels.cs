public class Solution {
    public int LargestValsFromLabels(int[] values, int[] labels, int numWanted, int useLimit) {
        var list = new List<Label>();
        for(int i = 0; i < labels.Length; i++){
            list.Add(new Label(labels[i], values[i]));
        }
        
        var sorted = list.OrderByDescending(x=>x.val).ToList();
        var dict = new Dictionary<int, int>();
        var max = 0;
        var size = 0;
        foreach(var item in sorted){
            if(size == numWanted){
                break;
            }
            if(!dict.ContainsKey(item.id)){
                // no item.. add
                max += item.val;
                dict[item.id] = 1;
                size++;
                continue;
            }
            
            if(dict[item.id] < useLimit){
                max += item.val;
                dict[item.id]++;
                size++;
            }
        }
        return max;
    }
    class Label{
        public int id;
        public int val;
        public Label(int id, int val){
            this.id = id;
            this.val = val;
        }
    }
}


/*
[5,4,3,2,1]
[1,1,2,2,3]
3, 2
*/