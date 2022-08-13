public class Solution {
    public int[] AssignBikes(int[][] workers, int[][] bikes) {
        // List of WorkerBikePair's to store all the possible pairs
        List<WorkerBikePair> allTriplets = new();
        
        // Generate all the possible pairs
        for (int worker = 0; worker < workers.Length; worker++) {
            for (int bike = 0; bike < bikes.Length; bike++) {
                int distance = FindDistance(workers[worker], bikes[bike]);        
                WorkerBikePair workerBikePair 
                    = new WorkerBikePair(worker, bike, distance);
                allTriplets.Add(workerBikePair);
            }
        }
        var sorted = allTriplets.ToArray();
        // Sort the triplets as per the custom comparator 'WorkerBikePairComparator'
        Array.Sort(sorted, new WorkerBikePairComparator());  
        
        // Initialize all values to false, to signify no bikes have been taken
        bool[] bikeStatus = new bool[bikes.Length];
        // Initialize all index to -1, to mark all the workers available
        int[] workerStatus = new int[workers.Length];
        Array.Fill(workerStatus, -1);
        // Keep track of how many worker-bike pairs have been made
        int pairCount = 0;
        
        foreach (WorkerBikePair triplet in sorted) {
            int worker = triplet.workerIndex;
            int bike = triplet.bikeIndex;
            
            // If both worker and bike are free, assign them to each other
            if (workerStatus[worker] == -1 && !bikeStatus[bike]) {
                bikeStatus[bike] = true;
                workerStatus[worker] = bike;
                pairCount++;
                
                // If all the workers have the bike assigned, we can stop
                if (pairCount == workers.Length) {
                    return workerStatus;
                }
            }
        }
        
        return workerStatus;
    }
    
    public class WorkerBikePairComparator:IComparer<WorkerBikePair>{
        public int Compare(WorkerBikePair a, WorkerBikePair b){
            if (a.distance != b.distance) {
                // Prioritize the one having smaller distance
                return a.distance - b.distance;
            } else if (a.workerIndex != b.workerIndex) {
                // Prioritize according to the worker index
                return a.workerIndex - b.workerIndex;
            } else {
                // Prioritize according to the bike index
                return a.bikeIndex - b.bikeIndex;
            }
        }
    }
        // Function to return the Manhattan distance
    int FindDistance(int[] worker, int[] bike) {
        return Math.Abs(worker[0] - bike[0]) + Math.Abs(worker[1] - bike[1]);
    }
    
    public class WorkerBikePair {
        public int workerIndex;
        public int bikeIndex;
        public int distance;   
        
        // Constructor to initialize the member variables
        public WorkerBikePair(int workerIndex, int bikeIndex, int distance) {
            this.workerIndex = workerIndex;
            this.bikeIndex = bikeIndex;
            this.distance = distance;
        }
    }
    
}