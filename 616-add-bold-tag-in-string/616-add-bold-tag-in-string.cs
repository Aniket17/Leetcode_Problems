public class Solution {
    public string AddBoldTag(string s, string[] words) {
        var ranges = Findings(s, words)
          .GroupBy(item => item.at)
          .Select(group => (at: group.Key, state: group.Sum(item => item.state)))
          .Where(item => item.state != 0)
          .ToDictionary(item => item.at, item => item.state);

          StringBuilder sb = new StringBuilder(s.Length * 4);

          int state = 0;

          for (int at = 0; at < s.Length; ++at) {
            if (!ranges.TryGetValue(at, out var delta)) {
              sb.Append(s[at]);

              continue;
            }

            if (state == 0 && delta > 0)
              sb.Append("<b>");
            else if (state > 0 && state + delta <= 0)
              sb.Append("</b>");

            state += delta;

            sb.Append(s[at]);
          }

          if (state > 0)
            sb.Append("</b>");

          return sb.ToString();
    }
    
    private static IEnumerable<(int at, int state)> Findings(string text, 
                                                             IEnumerable<string> words){
      foreach (string word in words) 
        for (int index = 0; ; ++index) {
          index = text.IndexOf(word, index);

          if (index < 0)
            break;

          yield return (index, 1);
          yield return (index + word.Length, -1);
        }
    }
}
