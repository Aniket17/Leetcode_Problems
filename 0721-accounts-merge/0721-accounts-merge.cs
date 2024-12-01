public class Solution {
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts) {
        var emailToParent = new Dictionary<string, string>();
        var emailToName = new Dictionary<string, string>();

        // Union-Find Helper Functions
        string Find(string email) {
            if (emailToParent[email] != email) {
                emailToParent[email] = Find(emailToParent[email]); // Path compression
            }
            return emailToParent[email];
        }

        void Union(string email1, string email2) {
            string parent1 = Find(email1);
            string parent2 = Find(email2);
            if (parent1 != parent2) {
                emailToParent[parent2] = parent1;
            }
        }

        // Step 1: Initialize Union-Find and map emails to names
        foreach (var account in accounts) {
            string name = account[0];
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

        // Step 2: Group emails by their root parent
        var components = new Dictionary<string, List<string>>();
        foreach (var email in emailToParent.Keys) {
            string root = Find(email);
            if (!components.ContainsKey(root)) {
                components[root] = new List<string>();
            }
            components[root].Add(email);
        }

        // Step 3: Format the result
        var result = new List<IList<string>>();
        foreach (var emails in components.Values) {
            emails.Sort(StringComparer.Ordinal);
            string name = emailToName[emails[0]]; // All emails share the same name
            var mergedAccount = new List<string> { name };
            mergedAccount.AddRange(emails);
            result.Add(mergedAccount);
        }

        return result;
    }
}