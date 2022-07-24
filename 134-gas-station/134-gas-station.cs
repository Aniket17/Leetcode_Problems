public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        var netGas = new int[gas.Length];
        for(int i = 0; i < gas.Length; i++){
            netGas[i] = gas[i] - cost[i];
        }
        if(netGas.Sum(x=>x) < 0) return -1;
        var start = 0;
        var total = 0;
        for(int i = 0; i < gas.Length; i++){
            total += netGas[i];
            if(total < 0){
                start = i + 1;
                total = 0;
            }
        }
        return start;
    }
}

/*
[1,2,3,4,5]
[3,4,5,1,2]
[-2,-2,-2,3,3] => 0

[2,4,3,4,5]
[3,3,4,1,5]
[-1,1,-1,3,0]
*/