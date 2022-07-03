public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        var heap = new MaxHeap(k + 1);
        
        foreach(var p in points){
            heap.Add(new Cord(p[0], p[1]));
            if(heap.Size() > k){
                heap.Pop();
            }
        }
        var result = new int[k][];
        int i = 0;
        while(!heap.IsEmpty()){
            var p = heap.Pop();
            result[i++] = new int[2]{p.x, p.y};
        }
        return result;
    }
    
    public class MaxHeap{
        private Cord[] _elements;
        private int _size = 0;
        
        bool IsGreater(Cord p1, Cord p2){
            var dist1 = Math.Sqrt(
                Math.Abs(p1.x * p1.x) + Math.Abs(p1.y * p1.y)
            );
            var dist2 = Math.Sqrt(
                Math.Abs(p2.x * p2.x) + Math.Abs(p2.y * p2.y)
            );
            return dist1 - dist2 >= 0 ? true : false;
        }
        
        public MaxHeap(int size){
            _elements = new Cord[size];
        }
        
        public int Size(){
            return _size;
        }
        
        private int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
        private int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;
        private int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

        private bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) <= _size;
        private bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) <= _size;
        private bool IsRoot(int elementIndex) => elementIndex == 0;

        private Cord GetLeftChild(int elementIndex) => _elements[GetLeftChildIndex(elementIndex)];
        private Cord GetRightChild(int elementIndex) => _elements[GetRightChildIndex(elementIndex)];
        private Cord GetParent(int elementIndex) => _elements[GetParentIndex(elementIndex)];

        private void Swap(int firstIndex, int secondIndex)
        {
            var temp = _elements[firstIndex];
            _elements[firstIndex] = _elements[secondIndex];
            _elements[secondIndex] = temp;
        }
        public Cord Peek() => _elements[0];
        public bool IsEmpty() => _size == 0;
        
        public void Add(Cord p1){
            if(_size == _elements.Length) return;
            _elements[_size] = p1;
            _size++;
            HeapifyUp();
        }
        
        public Cord Pop(){
            var el = _elements[0];
            _elements[0] = _elements[_size - 1];
            _size--;
            HeapifyDown();
            return el;
        }
        
        private void HeapifyUp(){
            // last child has been added
            var index = _size - 1;
            while (!IsRoot(index) && IsGreater(_elements[index], GetParent(index)))
            {
                var parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }
        
        private void HeapifyDown(){
            var index = 0;
            while(HasLeftChild(index))
            {
                var biggerIndex = GetLeftChildIndex(index);
                if(HasRightChild(index) && IsGreater(GetRightChild(index), GetLeftChild(index))){
                    biggerIndex = GetRightChildIndex(index);
                }
                
                if(IsGreater(_elements[index], _elements[biggerIndex])){
                    break;
                }
                Swap(index, biggerIndex);
                index = biggerIndex;
            }
        }
    }
    
    public class Cord{
        public int x;
        public int y;
        public Cord(int x, int y){
            this.x = x;
            this.y = y;
        }
    }
}