/**
 * // This is the robot's control interface.
 * // You should not implement it, or speculate about its implementation
 * interface Robot {
 *     // Returns true if the cell in front is open and robot moves into the cell.
 *     // Returns false if the cell in front is blocked and robot stays in the current cell.
 *     public bool Move();
 *
 *     // Robot will stay in the same cell after calling turnLeft/turnRight.
 *     // Each turn will be 90 degrees.
 *     public void TurnLeft();
 *     public void TurnRight();
 *
 *     // Clean the current cell.
 *     public void Clean();
 * }
 */

class Solution {
    public void CleanRoom(Robot robot) {
        var cleaned = new HashSet<string>();
        CleanRoomUtil(robot, 0, 0, 0, cleaned);
    }
    int[][] directions = new int[4][]{
        new int[]{1,0},
        new int[]{0,1},
        new int[]{-1,0},
        new int[]{0,-1},
    };
    
    private void GoBack(Robot robot){
        robot.TurnRight();
        robot.TurnRight();
        robot.Move();
        robot.TurnRight();
        robot.TurnRight();
    }
    
    private void CleanRoomUtil(Robot robot, int row, int col, int dir, HashSet<string> cleaned){
        robot.Clean();
        cleaned.Add($"{row},{col}");
        for(int i = 0; i < 4; i++){
            var newDir = directions[(dir + i)%4];
            var newRow = row + newDir[0];
            var newCol = col + newDir[1];
            var key = $"{newRow},{newCol}";
            if(!cleaned.Contains(key) && robot.Move()){
                CleanRoomUtil(robot, newRow, newCol, (dir + i)%4, cleaned);
                GoBack(robot);
            }
            robot.TurnRight();
        }
    }
}