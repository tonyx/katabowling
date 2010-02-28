#define DBC_CHECK_ALL

using System.Collections.Generic;
using System.Linq;

namespace ocpBowling
{
    public class Frame : Iframe
    {
//        public List<Rule> rules;
        public List<int> rollsInFrame;

        private void Init()
        {
//            rules = new List<Rule>();
//            rules.Add(new StrikeRule());
//            rules.Add(new SpareRule());
        }

        public Frame(params int[] args)
        {
            Init();
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

    public interface Iframe
    {
        int Total();
        int SumOfFirstTwo();
    }
}