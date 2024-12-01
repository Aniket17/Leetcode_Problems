public class Solution {
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts) {
        var emailToParent = new Dictionary<string, string>();
        var emailToName = new Dictionary<string, string>();

        string Find(string email){
            if(emailToParent[email] != email){
                emailToParent[email] = Find(emailToParent[email]);
            }
            return emailToParent[email];
        }

        void Union(string email1, string email2){
            var p1 = Find(email1);
            var p2 = Find(email2);
            if(p1 != p2){
                emailToParent[p1] = p2;
            }
        }

        for(int j = 0; j < accounts.Count; j++){
            var account = accounts[j];
            var name = account[0];
            for (int i = 1; i < account.Count; i++) {
                if (!emailToParent.ContainsKey(account[i])) {
                    emailToParent[account[i]] = account[i];
                    emailToName[account[i]] = name;
                }
                if (i > 1) {
                    Union(account[i], account[i - 1]);
                }
            }
        }

        //merge by root
        var components = new Dictionary<string, List<string>>();
        foreach(var email in emailToParent.Keys){
            var root = Find(email);
            if(!components.ContainsKey(root)){
               components[root] = new List<string>();
            }
            components[root].Add(email);
        }
        var result = new List<IList<string>>();
        foreach(var component in components.Keys){
            var name = emailToName[component];
            var emails = components[component];
            emails.Sort(StringComparer.Ordinal);
            var item = new List<string>(){name};
            item.AddRange(emails);
            result.Add(item);
        }
        return result;
    }
}