public class Solution {
    public class Ride{
        public int start;
        public int end;
        public int num;
        
        public Ride(int s, int e, int n){
            start = s;
            end = e;
            num = n;
        }
    }
    public bool CarPooling(int[][] trips, int capacity) {
        var rides = trips.Select(x=> new Ride(x[1], x[2], x[0])).OrderBy(x=>x.start).ToList();
        var leavingQueue = new List<Ride>();
        
        for(var i = 0; i < rides.Count; i++){
            var ride = rides[i];
            
            if(capacity < ride.num){
                // check who is leaving
                // if(leavingQueue.Count == 0 || leavingQueue.Peek().end <= ride.start){
                //     return false;
                // }
                var leaving = leavingQueue.Where(x=>x.end <= ride.start).ToList();
                if(!leaving.Any()){
                    return false;
                }
                // while(leavingQueue.Count > 0 && leavingQueue.Peek().end <= ride.start){
                //     var l = leavingQueue.Dequeue();
                //     capacity += l.end;
                // }
                capacity += leaving.Sum(x=>x.num);
                leaving.ForEach(x=>leavingQueue.Remove(x));
                if(capacity < ride.num){
                    return false;
                }
            }
            leavingQueue.Add(ride);
            capacity -= ride.num;
        }
        
        return true;
    }
    
    public class MinHeap{
        Ride[] items;
        int count = 0;
        public MinHeap(int size){
            items = new Ride[size];
        }
        
        public void Enqueue(Ride ride){
            items[count++] = ride;
            Up();
        }
        public Ride Dequeue(){
            var top = items[0];
            var last = items[count];
            count--;
            items[0] = last;
            Down();
            return top;
        }
        
        public Ride Peek(){
            return items[0];
        }

        public int Count {get{return count;}}
        
        private void Up(){
            var curr = count - 1;
            while(curr > 0){
                var parentIndex = (curr - 1)/2;
                if(items[parentIndex].end > items[curr].end){
                    Swap(parentIndex, curr);
                    curr = parentIndex;
                }else{
                    break;
                }
            }
        }
        
        private void Down(){
            var parentIndex = 0;
            var leftIndex = 1;
            var rightIndex = 2;
            while(leftIndex < count || rightIndex < count ){
                var minIndex = leftIndex;
                
                if(rightIndex < count && items[rightIndex].end < items[leftIndex].end){
                    minIndex = rightIndex;
                }
                
                if(items[parentIndex].end > items[minIndex].end){
                    Swap(parentIndex, minIndex);
                    
                    parentIndex = minIndex;
                    leftIndex = parentIndex;
                    rightIndex = leftIndex + 1;
                }else{
                    break;
                }
            }
        }
        
        void Swap(int x, int y){
            var tmp = items[x];
            items[x] = items[y];
            items[y] = tmp;
        }
    }
}

/*
sort the array with start time
queue of end time and passengers leaving
// when out of capacity check pop all elements queue.front which have less time than current pickup time
and increase the capacity
*/


