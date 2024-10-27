class Solution {
    public List<List<Integer>> findMissingRanges(int[] nums, int lower, int upper) {
        List<List<Integer>> answer = new ArrayList<>();
        if(nums.length == 0){
            List<Integer> list = new ArrayList<>();
            list.add(lower);
            list.add(upper);
            answer.add(list);
            return answer;
        }
        if(nums[0]!=lower){
            List<Integer> list = new ArrayList<>();
            list.add(lower);
            list.add(nums[0]-1);
            answer.add(list);
        }

        for(int i=0;i<nums.length - 1; i++){
            if(Math.abs(nums[i]-nums[i+1]) > 1){
                List<Integer> list = new ArrayList<>();
                list.add(nums[i]+1);
                list.add(nums[i+1]-1);
                answer.add(list);
            }
        }
        
        if(nums[nums.length-1]!=upper){
            List<Integer> list = new ArrayList<>();
            list.add(nums[nums.length-1] + 1);
            list.add(upper);
            answer.add(list);
        }

        return answer;
    }
}