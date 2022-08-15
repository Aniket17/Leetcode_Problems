public class RandomizedSet {
    private HashSet<int> _set;
    
    public RandomizedSet() {
        _set = new HashSet<int>();
    }
    
    public bool Insert(int val) {
        var result = _set.Add(val);
        return result;
    }
    
    public bool Remove(int val) {
        var result = _set.Remove(val);
        return result;
    }
    
    public int GetRandom() {
        return _set.ElementAt(new Random().Next(0, _set.Count));
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */