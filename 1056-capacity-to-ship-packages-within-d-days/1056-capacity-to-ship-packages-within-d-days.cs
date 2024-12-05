public class Solution {
    public int ShipWithinDays(int[] weights, int days) {
        var n = weights.Length;
        var low = weights.Max();
        var high = weights.Sum();
        if(days == 1) return high;
        var ans = low;
        while(low < high){
            var mid = (low + high)/2;
            var requiredDays = DaysRequireWithCapacity(weights, mid);
            if(requiredDays < days){
                ans = mid;
                high = mid;
            }else{
                low = mid + 1;
            }
        }
        return ans;
    }

    int DaysRequireWithCapacity(int[] weights, int capacity){
        var days = 0;
        var cargo = 0;
        for(int i = 0; i < weights.Length; i++){
            cargo += weights[i];
            if(cargo > capacity){
                days++;
                cargo = weights[i];
            }
        }
        return days;
    }
}

/*
[1,2,3,1,1] 4
1 8
with capacity 4 => 3 < 4
1 4

2
*/