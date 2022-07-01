// { Driver Code Starts
//Initial Template for C#

using System;
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

                int n = Convert.ToInt32(Console.ReadLine());
                int[] arr = new int[n];
                var stringArray = Console.ReadLine().Split(' ');
                int j = 0;
                for (int i = 0; i < stringArray.Length; i++)
                {

                    if (stringArray[i].CompareTo(" ") != -1)
                    {
                        arr[j] = int.Parse(stringArray[i]);

                        j++;
                    }
                }
                int[] dep = new int[n];
                stringArray = Console.ReadLine().Split(' ');
                j = 0;
                for (int i = 0; i < stringArray.Length; i++)
                {

                    if (stringArray[i].CompareTo(" ") != -1)
                    {
                        dep[j] = int.Parse(stringArray[i]);
                        j++;
                    }
                }
                Solution obj = new Solution();
                var res = obj.findPlatform(arr, dep,n);
                Console.WriteLine(res);
            }

        }
    }



    
 // } Driver Code Ends
//User function Template for C#

    class Solution
    {
        
        //Function to find the minimum number of platforms required at the
        //railway station such that no train waits.
        public int findPlatform(int[] arr, int[] dep,int n)
        {
            //code here
            var sorted = new Train[n];
            for(int i = 0; i < n; i++){
                sorted[i] = new Train(arr[i], dep[i]);
            }
            sorted = sorted.OrderBy(x=>x.start).ToArray();
            var map = new Dictionary<int, Train>();
            map.Add(1, sorted[0]);
            var count = 1;
            for(int i = 1; i < n; i++){
                if(!PlatformAvailable(map, sorted[i])){
                    map.Add(++count, sorted[i]);
                }
            }
            //track and decrease
            return map.Count();
        }
        
        bool PlatformAvailable(Dictionary<int, Train> map, Train train){
            foreach(var p in map.Keys){
                if(!map[p].Overlaps(train)){
                    map[p] = train;
                    return true;
                }
            }
            return false;
        }
    }
    
    /*
    [0900 , 0940, 0950, 1100, 1500, 1800]
    {0910, 1200, 1120, 1130, 1900, 2000}
    
    sorted [900 - 910, 940 - 1200, 950 - 1120, 1100 - 1130, 1500 - 1900 1800 - 2000]
    
    count = 2

    
    */
    
    
    public class Train{
        public int start;
        public int end;
        
        public Train(int start, int end){
            this.start = start;
            this.end = end;
        }
        
        public bool Overlaps(Train other){
            if(other.start <= this.end){
                return true;
            }
            return false;
        }
    }

}

// { Driver Code Starts.  // } Driver Code Ends