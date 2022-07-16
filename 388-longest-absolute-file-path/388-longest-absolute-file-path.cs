public class Solution {
    public int LengthLongestPath(string input) {
        // to store length the cumulative sum of word length
        // Remember in the stack, we are just storing the cumulative sum till the subdirectories, we aren't storing the file length.
	    Stack<int> st = new Stack<int>();
        int max = 0;
        st.Push(0); // to take care of the empty stack case, we dont' have to handle empty stack case seperately because st.peek() wil be 0 when "dir" is pushed
        
		foreach(String word in input.Split("\n")) {
            int len = word.Length; // includes tab as well
            int level = word.LastIndexOf("\t") + 1; // for eg: dir level is 0
            
			// stack.size() is similar to recursion or imagine it as a tree which will record the
            //  number nodes in that path, but if we encounter a string which has level less than stack size then it means we need to backtrack i.e pop the stack contents till we reach to the level where our current string is at. (Similar to cd.. operation in Linux, to go to the parent directory)
		   while(st.Count > level + 1) {
                st.Pop();
            }
            int actualWordLen = len - level;
            
            // to check if word is a file, and then calculate the max
            if(word.Contains(".")) {
                max = Math.Max(max, st.Peek() + actualWordLen); // since it will be last word in the string we don't have to add forward slash.
            }
            else {
                st.Push(st.Peek() + actualWordLen + 1); // 1 for forward slash
            }
        }
        return max;
    }
}