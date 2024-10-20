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
    // going clockwise : 0: 'up', 1: 'right', 2: 'down', 3: 'left'
    int[][] directions = new int[4][]{
        new int[]{-1, 0},
        new int[]{0, 1},
        new int[]{1, 0},
        new int[]{0, -1}
    };
    Robot robot;
    HashSet<(int, int)> seen = new();
    public void CleanRoom(Robot robot) {
        this.robot = robot;
        Backtrack(0,0,0);
    }

    void GoBack(){
        robot.TurnRight();
        robot.TurnRight();
        robot.Move();
        robot.TurnRight();
        robot.TurnRight();
    }

    void Backtrack(int row, int col, int direction){
        seen.Add((row, col));
        robot.Clean();
        //go over all the directions
        for(int i = 0; i < 4; i++){
            var newDir = (direction + i)%4;
            var dir = directions[newDir];
            var newRow = row + dir[0];
            var newCol = col + dir[1];
            if(!seen.Contains((newRow, newCol)) && robot.Move()){
                Backtrack(newRow, newCol, newDir);
                //this means the direction the robot went in, 
                //all the path in that dir is cleaned up.
                //so lets go back track
                GoBack();
            }
            //either there is obstacle or path is cleaned up, 
            //so lets change the direction and clean the rest.
            robot.TurnRight();
        }
    }
}