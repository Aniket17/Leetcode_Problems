
//User function Template for javascript

/**
 * @param {number} W
 * @param {Item[]} arr
 * @param {number} n
 * @returns {number}
*/

/*
class Item{
    constructor(value, weight){
        this.value = value;
        this.weight = weight;
    }
}
*/

class Solution 
{
    //Function to get the maximum total value in the knapsack.
    fractionalKnapsack(W, arr, n)
    {
        if(W == 0 || n == 0){
            return 0;
        }
        // code here
        var sorted = arr.sort((a,b) => {  
            const ratio1 = a.value/a.weight;
            const ratio2 = b.value/b.weight;
            return ratio2 - ratio1;
        });
        var profit = 0;
        for(var i = 0; i < n; i++){
            if(W <= 0) return profit;
            if(sorted[i].weight <= W){
                profit += sorted[i].value;
                W -= sorted[i].weight;
            }else{
                var ratio = sorted[i].value/sorted[i].weight;
                profit += ratio * W;
                W -= sorted[i].weight;
            }
        }
        return profit;
    }
}
