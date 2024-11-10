public class Solution {
    public class Timing{
        public int index;
        public int start;
        public int leaving;

        public Timing(int i, int s, int l){
            index = i;
            start = s;
            leaving = l;
        }
    }
    public int SmallestChair(int[][] t, int targetFriend) {
    var timing = new PriorityQueue<(int friend, int leaveTime, int chair), int>();
    var chairs = new PriorityQueue<int, int>();
    var map = new Dictionary<int, int>();
    var chairCount = 0;
    var times = new List<Timing>();

    for(int i = 0; i < t.Length; i++){
        times.Add(new Timing(i, t[i][0], t[i][1]));
    }

    times = times.OrderBy(x => x.start).ToList();

    // Process each friend's arrival in order
    foreach (var time in times) {
        // Free chairs for any friends leaving before the current friend's arrival
        while (timing.Count > 0 && timing.Peek().leaveTime <= time.start) {
            var (_, _, leavingChair) = timing.Dequeue();
            chairs.Enqueue(leavingChair, leavingChair);
        }

        int currChair;
        if (chairs.Count > 0) {
            currChair = chairs.Dequeue(); // Get the smallest available chair
        } else {
            currChair = chairCount++;     // Assign a new chair if no free chairs
        }

        timing.Enqueue((time.index, time.leaving, currChair), time.leaving);
        map[time.index] = currChair;

        if (time.index == targetFriend) {
            return currChair;
        }
    }

    return -1; // In case the target friend is not found, though input guarantees their presence
}

    //craete a min heap with leaving time
    //next arrival > leaving? pop the leaving friend and assign the number to new arrival person
    //insert the arrived person in heap
    //insert the empty chair in another min heap
}