/**
 * // This is the Master's API interface.
 * // You should not implement it, or speculate about its implementation
 * class Master {
 *     public int Guess(string word);
 * }
 */
class Solution {
    public void FindSecretWord(string[] wordlist, Master master) {
        int matches = -1;
        var wl = wordlist.ToList();
        while (matches != 6) {
            string selected = wl.Count> 3? wl[3]: wl[0];
            matches = master.Guess(selected);
            wl.RemoveAll(x => x.Zip(selected, (x, y) => x == y ? "" : x.ToString()).ToList().RemoveAll(z => z == "") != matches);
        }
    }
}