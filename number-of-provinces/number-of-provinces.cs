public class Solution {
    public int FindCircleNum(int[][] isConnected) {
        var n = isConnected.Length;
        var dsu = new DSU(n);
        for(int i = 0; i < n; i++){
            for(int j = 0; j < n; j++){
                if(isConnected[i][j] == 1 && i != j){
                    dsu.Union(i,j);
                }
            }
        }
        Console.WriteLine($"parent: {string.Join(",", dsu.parent)}");
        var count = 0;
        for(int i = 0; i < n; i++){
            if(-1 == dsu.parent[i]) 
                count += 1;
        }
        return count;
    }
    
    public class DSU{
        public int[] parent;
        
        public DSU(int size){
            parent = new int[size];
            for(int i = 0; i < size; i++){
                parent[i] = -1;
            }
        }
        
        public int Find(int n){
            if(-1 == parent[n]){
                return n;
            }
            return Find(parent[n]);
        }
        
        public void Union(int first, int second){
            var parent1 = Find(first);
            var parent2 = Find(second);
            
            if(parent1 == parent2){
                return;
            }
            parent[parent1] = parent2;
        }
    }
    
}

/*
[1,0,0,1]
[0,1,1,0]
[0,1,1,1]
[1,0,1,1]

0->0
3->0
1->2
2->3

1->2->3->0

[1,1,3,1,5,6,7,8,9]

*/