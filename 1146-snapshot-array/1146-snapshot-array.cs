public class SnapshotArray {
    Dictionary<int, int> currentChanges;
    List<Dictionary<int, int>> snapshots;
    int[] arr;
    int snapId = -1;
    public SnapshotArray(int length) {
        ResetCurrentChanges();
        arr = new int[length];
        snapshots = new List<Dictionary<int, int>>();
    }
    
    public void Set(int index, int val) {
        currentChanges[index] = val;
        arr[index] = val;
    }
    
    public int Snap() {
        snapId++;
        snapshots.Add(currentChanges.ToDictionary(x=>x.Key, v=>v.Value));
        ResetCurrentChanges();
        return snapId;
    }
    
    public int Get(int index, int snap_id) {
        var changes = snapshots[snap_id];
        
        if(changes.ContainsKey(index)){
            return changes[index];
        }
        
        while(--snap_id >= 0){
            changes = snapshots[snap_id];
            if(changes.ContainsKey(index)){
                return changes[index];
            }
        }
        return 0;
    }
    
    void ResetCurrentChanges(){
        currentChanges = new Dictionary<int, int>();
    }
}

/**
 * Your SnapshotArray object will be instantiated and called as such:
 * SnapshotArray obj = new SnapshotArray(length);
 * obj.Set(index,val);
 * int param_2 = obj.Snap();
 * int param_3 = obj.Get(index,snap_id);
 
 
 manage diffs, change history
 
 when we get set, we update the value in the array and also push change {index, prev curr} to changes
 with index as key 
 we repeat this for every snap
 
 */