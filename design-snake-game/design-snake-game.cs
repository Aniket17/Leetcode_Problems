public class SnakeGame {
    int width;
    int height;
    Queue<int> food;
    LinkedList<int> queue;
    HashSet<int> pos;
    Dictionary<string, int[]> directions;
    int score;
    public SnakeGame(int w, int h, int[][] f) {
        this.width = w;
        this.height = h;
        
        score = 0;
        queue = new LinkedList<int>();
        queue.AddFirst(0);
        
        pos = new HashSet<int>(){0};
        
        food = new Queue<int>();
        foreach(var el in f){
            food.Enqueue(GetPos(el));
        }
        
        directions = new Dictionary<string, int[]>();
        directions.Add("R", new int[]{0,1});
        directions.Add("L", new int[]{0,-1});
        directions.Add("D", new int[]{1,0});
        directions.Add("U", new int[]{-1,0});
        
    }
    int GetPos(int[] pos){
        if(pos[0] < 0 || pos[1] < 0 || pos[0] >= height || pos[1] >= width) return -1;
        return (pos[0] * width) + pos[1];
    }
    
    int[] GetCord(int el){
        return new int[]{el/width, el%width};
    }
    
    int[] AddCord(int[] pos1, int[] pos2){
        return new int[]{pos1[0] + pos2[0], pos1[1] + pos2[1]};
    }
    
    public int Move(string direction) {
        // decrease by one
        var el = queue.First();
        var newPos = GetPos(AddCord(GetCord(el), directions[direction]));

        if(newPos >= width*height || newPos < 0){
            return -1;
        }
        Console.WriteLine($"{el} -> {newPos} -> {direction}");
        if(food.Count > 0 && food.Peek() == newPos){
            score++;
            food.Dequeue();
        }else{
            pos.Remove(queue.Last());
            queue.RemoveLast();
        }
        var exists = pos.Add(newPos);
        queue.AddFirst(newPos);
        if(!exists) return -1;
        Console.WriteLine("POS - "+string.Join(",", pos));
        Console.WriteLine("QUEUE - "+string.Join(",", queue));
        return score;
    }
}

/**
 * Your SnakeGame object will be instantiated and called as such:
 * SnakeGame obj = new SnakeGame(width, height, food);
 * int param_1 = obj.Move(direction);
 */


/*
maintain a hashset of numbers indicating the current occupied positions of snake
maintain a queue of numbers indicating current length  of snake

*/