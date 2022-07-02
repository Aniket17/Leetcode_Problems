public class Solution
{
    List<HashSet<int>> rows = new List<HashSet<int>>();
    List<HashSet<int>> cols = new List<HashSet<int>>();
    List<HashSet<int>> grid = new List<HashSet<int>>();

    public void SolveSudoku(char[][] board)
    {
        var n = board.Length;
        // preprocessing
        Preprocess(board);
        //backtracking
        //find ans, output, get next valid items, iterate, backtrack
        Solve(board, 0, 0);
    }

    private bool Solve(char[][] board, int row, int col)
    {
        if (row == board.Length - 1 && col == board.Length) return true;
        if(col == board.Length)
        {
            row = row + 1;
            col = 0;
        }
        if (board[row][col] != '.')
        {
            return Solve(board, row, col + 1);
        }

        for (int i = 1; i <= 9; i++)
        {
            if (board[row][col] == '.' && IsValid(i, row, col))
            {
                board[row][col] = (char)(i + '0');
                rows[row].Add(i);
                cols[col].Add(i);
                grid[(row / 3) * 3 + col / 3].Add(i);

                if (Solve(board, row, col + 1))
                {
                    return true;
                }
                board[row][col] = '.';
                rows[row].Remove(i);
                cols[col].Remove(i);
                grid[(row / 3) * 3 + col / 3].Remove(i);
            }
        }
        return false;
    }

    private bool IsValid(int n, int row, int col)
    {
        var isInvalid = rows[row].Contains(n)
                || cols[col].Contains(n)
                || grid[(row / 3) * 3 + col / 3].Contains(n);
        return !isInvalid;
    }

    private void Preprocess(char[][] board)
    {
        int counter = 0;
        while (counter < 9) { grid.Add(new HashSet<int>()); counter += 1; }
        for (int i = 0; i < 9; i++)
        {
            rows.Add(new HashSet<int>());
            cols.Add(new HashSet<int>());
            for (int j = 0; j < 9; j++)
            {
                if (board[i][j] != '.')
                {
                    rows[i].Add(((int)board[i][j] - '0'));
                    grid[(i / 3) * 3 + j / 3].Add(((int)board[i][j] - '0'));
                }
                if (board[j][i] != '.')
                {
                    cols[i].Add(((int)board[j][i] - '0'));
                }
            }
        }
    }
}
