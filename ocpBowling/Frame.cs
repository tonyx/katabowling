#define DBC_CHECK_ALL

using System.Collections.Generic;
using System.Linq;

namespace ocpBowling
{
    public class Frame
    {
 
        public List<int> rollsInFrame;

        public Frame(params int[] args)
        {
            rollsInFrame = args.ToList();
        }

        public int Total()
        {
            return rollsInFrame.Sum(x => x);
        }

        public int SumOfFirstTwo()
        {
            return rollsInFrame.Take(2).Sum();
        }
                
    }
}