public class Solution {
    bool carry = true;
    public string NextClosestTime(string time)
    {
        Hashtable tempHash = new Hashtable();
        List<char> digitals = new List<char>();
        char[] result = time.ToArray();

        foreach (var digital in time)
            if (digital != ':' && !tempHash.ContainsKey(digital))
                tempHash.Add(digital, null);

        foreach (var item in tempHash.Keys)
            digitals.Add((char)item);

        digitals.Sort();

        result[4] = findNext(result[4], digitals, '9');

        if (carry)
            result[3] = findNext(result[3], digitals, '5');

        if (carry && (result[0] == '0' || result[0] == '1'))
            result[1] = findNext(result[1], digitals, '9');
        else if (carry && result[0] == '2')
            result[1] = findNext(result[1], digitals, '3');

        if (carry)
            result[0] = findNext(result[0], digitals, '2');

        return new string(result);
    }

    private char findNext(char currentDigital, List<char> digitals, char limit)
    {
        char next = '\0';

        foreach (var item in digitals)
            if (item > currentDigital)
            {
                next = item;
                break;
            }

        if (next > limit || next == '\0')
        {
            next = digitals[0];
            carry = true;
        }
        else
            carry = false;

        return next;
    }
}