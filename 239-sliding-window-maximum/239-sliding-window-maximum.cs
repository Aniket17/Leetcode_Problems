public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        var low = 0;
        var sg = new SegmentTree(nums.Length);
        sg.ConstructTree(nums, 0, nums.Length - 1, 0);
        
        var result = new List<int>();
        while(low + k <= nums.Length){
            result.Add(sg.QueryMax(low, low+k-1, 0, nums.Length - 1, 0));
            low++;
        }
        return result.ToArray();
    }
    
    public class SegmentTree{
        int[] _elements;
        int _size;
        public SegmentTree(int size){
            _elements = new int[size*4 + 1];
            Array.Fill(_elements, int.MinValue);
        }
        
        public void ConstructTree(int[] nums, int low, int high, int pos){
            if(low == high){
                _elements[pos] = nums[low];
                return;
            }
            var mid = low + (high - low)/2;
            ConstructTree(nums, low, mid, 2 * pos + 1);
            ConstructTree(nums, mid + 1, high, 2 * pos + 2);
            _elements[pos] = Math.Max(_elements[2 * pos + 1], _elements[2 * pos + 2]);
        }
        
        public int QueryMax(int qlow, int qhigh, int low, int high, int pos){
            //overlap, no overlap, partial overlap
            // total overlap
            if(qlow <= low && qhigh >= high){
                return _elements[pos];
            }
            // no overlap
            if(qlow > high || qhigh < low){
                return int.MinValue;
            }
            // partial overlap
            // search on both sides
            var mid = low + (high - low)/2;
            return Math.Max(QueryMax(qlow, qhigh, low, mid, pos * 2 + 1), 
                            QueryMax(qlow, qhigh, mid + 1, high, pos * 2 + 2));
        }
    }
}