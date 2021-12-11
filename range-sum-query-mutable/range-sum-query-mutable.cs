public class NumArray {
    int[] tree;
    int size;
    int[] nums;
    public NumArray(int[] nums) {
        size = nums.Length;
        this.nums = nums;
        var treeSize = NextPowerOf2(size);
        tree = new int[treeSize * 2 - 1];
        ConstructSegmentTree(nums, 0, size - 1, 0);
    }
    
    public void Update(int index, int val) {
        var delta = val - nums[index];
        Console.WriteLine(delta);
        nums[index] = val;
        UpdateSegmentTree(index, delta, 0, size - 1, 0);
    }
    
    private void UpdateSegmentTree(int index, int delta, int low, int high, int pos){
         if(index < low || index > high){
            return;
        }
        tree[pos] += delta;
        if(low >= high){
            return;
        }
        
        var mid = (low + high)/2;
        UpdateSegmentTree(index, delta, low, mid, LeftChildIndex(pos));
        UpdateSegmentTree(index, delta, mid + 1, high, RightChildIndex(pos));
    }
    
    public int SumRange(int left, int right) {
        return RangeSumQuery(left, right, 0, size - 1, 0);
    }

    int RangeSumQuery(int qlow, int qhigh, int low, int high, int pos){
        if(qlow <= low && qhigh >= high){
            return tree[pos];
        }
        if(qlow > high || qhigh < low){
            return 0;
        }
        
        var mid = (low + high)/2;
        
        var ans = RangeSumQuery(qlow, qhigh, low, mid, LeftChildIndex(pos)) + RangeSumQuery(qlow, qhigh, mid+1, high, RightChildIndex(pos));
        return ans;
    }
    
    void ConstructSegmentTree(int[] nums, int low, int high, int pos){
        if(low == high){
            tree[pos] = nums[low];
            return;
        }
        var mid = (low + high)/2;
        ConstructSegmentTree(nums, low, mid, LeftChildIndex(pos));
        ConstructSegmentTree(nums, mid + 1, high, RightChildIndex(pos));
        tree[pos] = tree[LeftChildIndex(pos)] + tree[RightChildIndex(pos)];
    }
    
    private int LeftChildIndex(int pos) => pos * 2 + 1;
    private int RightChildIndex(int pos) => pos * 2 + 2;
    private int ParentIndex(int pos) => (pos - 1) / 2;
                     
    private int NextPowerOf2(int num) {
        if(num == 0){
            return 1;
        }
        if((num & (num - 1)) == 0){
            return num;
        }
        while((num & (num - 1)) != 0){
            num = (num & (num - 1));
        }
        return num << 1;
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * obj.Update(index,val);
 * int param_2 = obj.SumRange(left,right);
 */