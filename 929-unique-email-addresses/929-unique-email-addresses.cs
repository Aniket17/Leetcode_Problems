public class Solution {
    public int NumUniqueEmails(string[] emails) {
        var set = new HashSet<string>();
        foreach(var email in emails){
            var parts = email.Split("@");
            var local = Clean(parts[0]);
            set.Add(local +"@"+ parts[1]);
        }
        return set.Count;
    }
    
    string Clean(string email){
        var sb = new StringBuilder();
        foreach(var ch in email){
            if(ch == '.')continue;
            if(ch == '+') break;
            sb.Append(ch);
        }
        return sb.ToString();
    }
}