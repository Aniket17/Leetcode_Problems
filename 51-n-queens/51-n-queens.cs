public class Solution {
    public IList<IList<string>> SolveNQueens(int n) 
    {
        var result = new List<IList<string>>();
        DFS(new int[n], 0, result);
        return result;
    }
    
    private void DFS(int[] board, int n, List<IList<string>> list)
    {
        if(n == board.Length)
        {
            list.Add(ConvertToResult(board));
            return;
        }
        
        for(int i = 0; i < board.Length;i++)
        {
            if(IsValid(board, n, i))
            {
                board[n] = i;
                DFS(board, n + 1, list);
            }
        }
    }
    
    private bool IsValid(int[] board, int index, int val)
    {
        for(int i = 0; i < index; i++)
            if(i + board[i] == val + index || i - board[i] == index - val || board[i] == val)
                return false;
        return true;
    }
    
    private IList<string> ConvertToResult(int[] board)
    {
        var result = new List<string>();
        for(int i = 0; i < board.Length; i++)
        {
            var charArray = Enumerable.Repeat('.', board.Length).ToArray();
            charArray[board[i]] = 'Q';
            result.Add(new string(charArray));
        }
        
        return result;
    }

}