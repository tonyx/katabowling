using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ocpBowling
{
    static class ExtendFrame
    {
        public static int NextTwoRolls(this Frame[] frames, int i)
        {
            return RollsFromFrame(frames,i+1).Take(2).Sum();
        }

        private static IEnumerable<int> RollsFromFrame(this Frame[] frames,int i)
        {
            if (i==frames.Length) return new List<int>();
            List<int> toReturn = frames[i].Rolls.ToList();
            toReturn.AddRange(RollsFromFrame(frames,i+1));
            return toReturn;
        }

    }
}
