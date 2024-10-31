public class Solution {
    public IList<string> FindItinerary(IList<IList<string>> tickets) {
        var map = new Dictionary<string, List<string>>();
        foreach(var ticket in tickets){
            string src = ticket[0], dst = ticket[1];
            if(!map.ContainsKey(src)) map[src] = new();
            map[src].Add(dst);
        }
        foreach(var key in map.Keys) map[key].Sort();
        var itinerary = new Stack<string>();

        void Dfs(string src){
            while(map.ContainsKey(src) && map[src].Count > 0){
                var nextAirport = map[src][0];
                map[src].RemoveAt(0);
                Dfs(nextAirport);
            }
            itinerary.Push(src);
        }

        Dfs("JFK");
        return itinerary.ToList();
    }
}