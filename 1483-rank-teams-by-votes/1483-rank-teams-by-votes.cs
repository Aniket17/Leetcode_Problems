public class Solution {
    public string RankTeams(string[] votes) {
       var numberOfTeams = votes[0].Length;
       var n = votes.Length;
       var teams = new Dictionary<char, int[]>();
       foreach(var vote in votes){
            for(int i = 0; i < numberOfTeams; i++){
                var team = vote[i];
                if(!teams.ContainsKey(team)){
                    teams[team] = new int[numberOfTeams];
                }
                teams[team][i]++;
            }
       }

       //sort the dictionary
       var sorted = teams.Keys.ToList();
       sorted.Sort((a,b)=>{
        for(int i = 0; i < numberOfTeams; i++){
            if(teams[a][i] != teams[b][i]){
                return teams[b][i].CompareTo(teams[a][i]);
            }
        }
        return a.CompareTo(b);
       });
       return string.Join("", sorted);
    }

}