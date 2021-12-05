public class Solution {
    public int MaxProfit(int[] prices) {
        //keep prices in max heap
        //remove top when
        var profit = 0;
        var minPrice = prices[0];
        for(int i = 1; i < prices.Length; i++){
            //can sell?
            minPrice = Math.Min(prices[i], minPrice);
            if(prices[i] - minPrice > profit){
                profit = prices[i] - minPrice;
            }
        }
        return profit;
    }
    
    public class MaxHeap{
        List<Tuple<int, int>> heap;
        public bool IsEmpty => !heap.Any();
        public MaxHeap(){
            heap = new List<Tuple<int, int>>();
        }
        
        public Tuple<int, int> Peek(){
            if(!IsEmpty){
                return heap.First();
            }
            return Tuple.Create(int.MinValue,-1);
        }
        
        public void Enqueue(int n, int idx){
            heap.Add(Tuple.Create(n, idx));
            HeapifyUp(heap.Count - 1);
        }
        
        public Tuple<int, int> Dequeue(){
            var el = Peek();
            if(el.Item1 == -1){
                return null;
            }
            heap.Remove(el);
            HeapifyDown(0);
            return el;
        }
        private int GetParentIndex(int pos){
            return pos/2;
        }
        private int GetRightChildIndex(int pos){
            return pos * 2 + 2;
        }
        private int GetLeftChildIndex(int pos){
            return pos * 2 + 1;
        }
        private void HeapifyUp(int pos){
            //start from end, check its parent is greater, 
            //if not swap with parent and call heapify again
            if(pos == 0){return;}
            var parentPos = GetParentIndex(pos);
            if(heap[parentPos].Item1 < heap[pos].Item1){
                var temp = heap[parentPos];
                heap[parentPos] = heap[pos];
                heap[pos] = temp;
            }
            HeapifyUp(parentPos);
            return;
        }
        private void HeapifyDown(int pos){
            int left  = GetLeftChildIndex(pos); 
            int right = GetRightChildIndex(pos);  
            int largestIndex = 0;  
          
            if (heap.Count - 1 < left) { 
                return;   
            } 
            if (heap.Count - 1 == left) { 
                if(heap[pos].Item1 < heap[left].Item1) {  
                    var tmp = heap[pos];  
                    heap[pos] = heap[left];  
                    heap[left] = tmp;  
                }
                return;  
            }else { //If both children are there  
                if(heap[left].Item1 > heap[right].Item1) { //Find out the smallest child  
                    largestIndex = left;  
                }else {  
                    largestIndex = right;  
                }  
                if(heap[pos].Item1 < heap[largestIndex].Item1) { //If Parent is greater than smallest child, then swap  
                    var tmp = heap[pos];  
                    heap[pos] = heap[largestIndex];  
                    heap[largestIndex] = tmp;  
                }  
            }  
            HeapifyDown(largestIndex); 
        }
        
        public void Print(){
            Console.WriteLine($"{String.Join(",", heap.Select(x=>x.Item1 + ":"+ x.Item2))}");
        }
    }
}

//[7,1,5,3,6,4]
// 0(7) -> 0
// 1(1) -> 5
// 2(5) -> 1
// 3(3) -> 0

//max heap

