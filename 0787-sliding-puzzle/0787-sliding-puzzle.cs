public class Solution {
    public int SlidingPuzzle(int[][] board) {
        var target = "123450";
        var curr = GetBoardKey();
        //these are the allowed moves for index 0 to 5
        var allowedMoves = new int[][]{
            new int[]{1,3}, //0
            new int[]{0,2,4}, //1
            new int[]{1,5}, //2
            new int[]{0,4}, //3
            new int[]{1,3,5},//4
            new int[]{4,2} //5
        };

        var numberOfMoves = 0;
        var seen = new HashSet<string>();

        var queue = new Queue<string>();
        queue.Enqueue(curr);

        while(queue.Count != 0){
            var size = queue.Count;
            while(size-- != 0){
                var state = queue.Dequeue();
                if(state == target) return numberOfMoves;
                if(seen.Contains(state)) continue;
                seen.Add(state);

                var indexOfZero = state.IndexOf("0");
                foreach(var newIndex in allowedMoves[indexOfZero]){
                    var newState = Swap(state, indexOfZero, newIndex);
                    if(seen.Contains(newState)) continue;
                    queue.Enqueue(newState);
                }
            }
            numberOfMoves++;
        }
        return -1;

        string GetBoardKey(){
            var sb = new StringBuilder();
            foreach(var row in board){
                foreach(var val in row){
                    sb.Append(val);
                }
            }
            return sb.ToString();
        }

        string Swap(string str, int i, int j){
            var s = str.ToArray();
            var temp = s[j];
            s[j] = s[i];
            s[i] = temp;
            return new String(s);
        }
    }
}