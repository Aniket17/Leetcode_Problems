public class Solution {
    public bool CanChange(string start, string target) {
        var startQueue = new Queue<(char, int)>();
        var targetQueue = new Queue<(char, int)>();
        for(int i = 0; i < start.Length; i++){
            if(start[i] != '_'){
                startQueue.Enqueue((start[i], i));
            }
        }
        for(int i = 0; i < target.Length; i++){
            if(target[i] != '_'){
                targetQueue.Enqueue((target[i], i));
            }
        }

        if(startQueue.Count != targetQueue.Count) return false;

        while(startQueue.Count != 0){
            var (startCh, startIndex) = startQueue.Dequeue();
            var (targetCh, targetIndex) = targetQueue.Dequeue();
            if(startCh != targetCh 
                || (startCh == 'L' && startIndex < targetIndex)
                || (startCh == 'R' && startIndex > targetIndex)
                ){
                    return false;
                }
        }
        return true;
    }
}