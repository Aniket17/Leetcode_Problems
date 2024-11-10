/*
// Definition for a QuadTree node.
public class Node {
    public bool val;
    public bool isLeaf;
    public Node topLeft;
    public Node topRight;
    public Node bottomLeft;
    public Node bottomRight;

    public Node() {
        val = false;
        isLeaf = false;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
    
    public Node(bool _val, bool _isLeaf) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
    
    public Node(bool _val,bool _isLeaf,Node _topLeft,Node _topRight,Node _bottomLeft,Node _bottomRight) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = _topLeft;
        topRight = _topRight;
        bottomLeft = _bottomLeft;
        bottomRight = _bottomRight;
    }
}
*/

public class Solution {
    // Returns true if all the values in the matrix are the same; otherwise, false.
    bool SameValue(int[][] grid, int x1, int y1, int length) {
        for (int i = x1; i < x1 + length; i++) {
            for (int j = y1; j < y1 + length; j++)
                if (grid[i][j] != grid[x1][y1])
                    return false;
        }
        return true;
    }

    Node Solve(int[][] grid, int x1, int y1, int length) {
        // Return a leaf node if all values are the same.
        if (SameValue(grid, x1, y1, length)) {
            return new Node(grid[x1][y1] == 1, true);
        } else {
            Node root = new Node(false, false);

            // Recursive call for the four sub-matrices.
            root.topLeft = Solve(grid, x1, y1, length / 2);
            root.topRight = Solve(grid, x1, y1 + length / 2, length / 2);
            root.bottomLeft = Solve(grid, x1 + length / 2, y1, length / 2);
            root.bottomRight = Solve(grid, x1 + length / 2, y1 + length / 2, length / 2);

            return root;
        }
    }

    public Node Construct(int[][] grid) {
        return Solve(grid, 0, 0, grid.Length);
    }
}