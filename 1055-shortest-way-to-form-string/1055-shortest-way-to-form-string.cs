public class Solution {
    public int ShortestWay(string source, string target) 
    {
        if(source==null || target == null)
        {
            return -1;
        }
        
        int result=0;
        int startIndex = 0;
        
        for(int i=0;i<target.Length;++i)
        {
            char ch = target[i];
            
            // find the char from target within the part of the source which is not
            // inspected yet, as it could be the case that we saw the char already
            // like "aaa","aaaaaaaa"
            int index = source.IndexOf(ch, startIndex);
            
            // not found
            if(index == -1)
            {
                // so check if we have it in the beginning, and have to start a new subsequence
                index = source.IndexOf(ch, 0, startIndex);
                    
                // not found -> impossible to find a set of subsequences to satisfy the criteria
                if(index==-1)
                {
                    return -1;
                }
                else
                {
                    // start a new subsequence using the 
                    // found index
                    ++result;
                }
            }
            
            // here we either start a new subsequence or continue the existing one
            startIndex = index+1;
        }
        
        // we've reached the end so add the last subsequence
        return ++result;
    }
}