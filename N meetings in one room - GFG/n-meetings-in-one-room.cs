// { Driver Code Starts
//Initial Template for C#


using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverCode
{

    class GFG
    {
        static void Main(string[] args)
        {
            int testcases;// Taking testcase as input
            testcases = Convert.ToInt32(Console.ReadLine());
            while (testcases-- > 0)// Looping through all testcases
            {
                int N = Convert.ToInt32(Console.ReadLine());
                int[] start = new int[N];
                int[] end = new int[N];
                string elements = Console.ReadLine().Trim();
                elements = elements + " " + "0";
                start = Array.ConvertAll(elements.Split(), int.Parse);
                elements = Console.ReadLine().Trim();
                elements = elements + " " + "0";
                end = Array.ConvertAll(elements.Split(), int.Parse);
                Solution obj = new Solution();
                int res = obj.maxMeetings(start, end , N);
                Console.Write(res+"\n");
          }

        }
    }
}// } Driver Code Ends


//User function Template for C#


class Solution
    {
        //Complete this function
        public int maxMeetings(int[] start, int[] end, int n)
        {
            //Your code here
            var meets = new Interval[n];
            for(int i = 0; i < n; i++){
                meets[i] = new Interval(start[i], end[i]);
            }
            meets = meets.OrderBy(z=>z.end).ToArray();
            var max = 0;
            var ends = meets[0].end;
            for(int i = 1; i < n; i++){
                if(meets[i].start > ends){
                    max++;
                    ends = meets[i].end;
                }
            }
            return max + 1;
        }
        
        public class Interval{
            public int start;
            public int end;
            
            public Interval(int start, int end){
                this.start = start;
                this.end = end;
            }
        }
    }
    
    /*
    start[] = {1,3,0,5,8,5}
    end[] =   {2,4,6,7,9,9}
    
    0 1 3 5 5 8
    6 2 4 7 9 9
    
    
    
    */