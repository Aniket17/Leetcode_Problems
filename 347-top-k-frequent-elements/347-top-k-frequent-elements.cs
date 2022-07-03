public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var map = new Dictionary<int, int>();
        foreach(var n in nums){
            map[n] = 1 + map.GetValueOrDefault(n);
        }
        
        var heap = new MinHeap(k+1);
        foreach(var pair in map){
            heap.Add(new Pair(pair.Key, pair.Value));
            if(heap.Size() > k){
                heap.Pop();
            }
        }
        var list = new List<int>();
        while(!heap.IsEmpty()){
            list.Add(heap.Pop().key);
        }
        return list.ToArray();
    }
    
    public class Pair{
        public int value;
        public int key;
        public Pair(int key, int value){
            this.key = key;
            this.value = value;
        }
    }
    
    public class MinHeap{
        private Pair[] _elements;
        private int _size = 0;
        
        bool IsSmaller(Pair p1, Pair p2){
            return p1.value <= p2.value;
        }
        
        public MinHeap(int size){
            _elements = new Pair[size];
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

        private Pair GetLeftChild(int elementIndex) => _elements[GetLeftChildIndex(elementIndex)];
        private Pair GetRightChild(int elementIndex) => _elements[GetRightChildIndex(elementIndex)];
        private Pair GetParent(int elementIndex) => _elements[GetParentIndex(elementIndex)];

        private void Swap(int firstIndex, int secondIndex)
        {
            var temp = _elements[firstIndex];
            _elements[firstIndex] = _elements[secondIndex];
            _elements[secondIndex] = temp;
        }
        public Pair Peek() => _elements[0];
        public bool IsEmpty() => _size == 0;
        
        public void Add(Pair p1){
            if(_size == _elements.Length) return;
            _elements[_size] = p1;
            _size++;
            HeapifyUp();
        }
        
        public Pair Pop(){
            var el = _elements[0];
            _elements[0] = _elements[_size - 1];
            _size--;
            HeapifyDown();
            return el;
        }
        
        private void HeapifyUp(){
            // last child has been added
            var index = _size - 1;
            while (!IsRoot(index) && IsSmaller(_elements[index], GetParent(index)))
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
                var smallerIndex = GetLeftChildIndex(index);
                if(HasRightChild(index) && IsSmaller(GetRightChild(index), GetLeftChild(index))){
                    smallerIndex = GetRightChildIndex(index);
                }
                
                if(IsSmaller(_elements[index], _elements[smallerIndex])){
                    break;
                }
                Swap(index, smallerIndex);
                index = smallerIndex;
            }
        }
    }
}