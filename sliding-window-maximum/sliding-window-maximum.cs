public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        var sg = new SegmentTree();
        var tree = sg.CreateSegmentTree(nums);
        Console.WriteLine(string.Join(",",tree));
        var ans = new List<int>();
        var low = 0;
        while(low + k <= nums.Length){
            ans.Add(sg.QueryMax(low, low + k - 1, 0, nums.Length - 1, 0));
            low++;
        }
        return ans.ToArray();
    }
    
    class SegmentTree{
        int[] tree;
        
        public int[] CreateSegmentTree(int[] nums){
            var treeSize = NextPowerOfTwo(nums.Length) * 2 - 1;
            tree = new int[treeSize];
            ConstructTree(0, nums.Length - 1, nums, 0);
            return tree;
        }
        
        private void ConstructTree(int low, int high, int[] nums, int pos){
            if(high == low){
                tree[pos] = nums[low];
                return;
            }
            var mid = low + (high - low)/2;
            ConstructTree(low, mid, nums, pos * 2 + 1); //left child
            ConstructTree(mid + 1, high, nums, pos * 2 + 2); //right child
            tree[pos] = Math.Max(tree[pos * 2 + 1], tree[pos * 2 + 2]);
        }
        
        int NextPowerOfTwo(int num){
            var pow = (int)Math.Ceiling(Math.Log(num)/Math.Log(2));
            return (int)Math.Pow(2, pow);
        }
        
        public int QueryMax(int qlow, int qhigh, int low, int high, int pos){
            // total overlap
            if(qlow <= low && qhigh >= high){
                return tree[pos];
            }
            // no overlap
            if(qlow > high || qhigh < low){
                return int.MinValue;
            }
            // partial overlap
            // search on both sides
            var mid = low + (high - low)/2;
            return Math.Max(QueryMax(qlow, qhigh, low, mid, pos * 2 + 1), QueryMax(qlow, qhigh, mid + 1, high, pos * 2 + 2));
        }
    }
    
}

/*
segment tree


*/