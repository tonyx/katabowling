#define DBC_CHECK_ALL

using System.Collections.Generic;
using System.Linq;

namespace ocpBowling
{
    public class Frame 
    {
        readonly List<int> rollsInFrame;

        public Frame(params int[] args)
        {
            rollsInFrame = args.ToList();
        }

        public int Total()
        {
            return rollsInFrame.Sum(x => x);
        }

        public List<int > Rolls
        {
            get
            {
                return rollsInFrame;
            }
        }

        public string ToString()
        {
            return Rolls.Aggregate("",(x,y) => x+=(y+" "));
        }
    }
}