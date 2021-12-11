public class Solution {
    int count = 0;
    public int ReversePairs(int[] nums) {
        var n = nums.Length;
        Divide(nums, 0, n - 1);
        return count;
    }
    
    //merge sort
    public void Divide(int[] nums, int low, int high){
        if(low >= high){
            return;
        }
        var mid = low + (high - low)/2;
        Divide(nums, low, mid);
        Divide(nums, mid + 1, high);
        Merge(nums, low, high);
    }
    
    void Merge(int[] nums, int low, int high){
        var mid = low + (high - low)/2;
        var result = new int[high - low + 1];
        var i = low;
        var j = mid + 1;
        var k = 0;
        for(;i<=mid;i++) {
            while(j<=high && nums[i] > 2 * (long)nums[j]) {
                j++;
            }
            count += (j - (mid+1));
        }
        i = low;
        j = mid + 1;
        while(i <= mid && j <= high){
            if(nums[i] < nums[j]){
                result[k++] = nums[i++];
            }else if(nums[i] > nums[j]){
                //Console.WriteLine($"{i}, {j}, {mid}, {nums[i]} {nums[j]} ");
                result[k++] = nums[j++];
            }else{
                //equal
                result[k++] = nums[j++];
            }
        }
        while(i <= mid){
            result[k++] = nums[i++];
        }
        while(j <= high){            
            result[k++] = nums[j++];
        }
        i = low;
        for(int x=0; x < result.Length;){
            nums[i++] = result[x++];
        }
        return;
    }
    
    void UpdateCount(int[] nums, int i, int j, int mid){
        if(nums[i] > nums[j] * 2){
            count += (mid - i + 1);
        }else{
            var tmp = i;
            while(tmp <= mid && nums[tmp] <= 2 * (long)nums[j])
            {
                tmp++;
            }
            if(tmp <= mid)
            {
                count += (mid - tmp + 1);
            }
        }
    }
    
    public class SegmentTree{
        public int[] tree;
        
        public SegmentTree(int[] nums){
            tree = ConstructTree(nums);
        }
        
        private int[] ConstructTree(int[] nums){
            var size = GetNextPowerOf2(nums.Length);
            tree = new int[size * 2 - 1];
            ConstructTree(nums, 0, nums.Length - 1, 0);
            return tree;
        }
        
        private void ConstructTree(int[] nums, int low, int high, int pos){
            if(low == high){
                tree[pos] = low;
                return;
            }
            var mid = (low + high) / 2;
            ConstructTree(nums, low, mid, Left(pos));
            ConstructTree(nums, mid + 1, high, Right(pos));
            tree[pos] = Math.Min(Left(pos), Right(pos));
        }
        
        private int Left(int i) => i * 2 + 1;
        private int Right(int i) => i * 2 + 2;
        private int Parent(int i) => i / 2;
        private int GetNextPowerOf2(int num){
            if(num ==0){
                return 1;
            }
            var x = (int)Math.Ceiling(Math.Log(num) / Math.Log(2));
            return (int)Math.Pow(2, x);
        }
    }
}


/*
[2,4,3,5,1]


*/
