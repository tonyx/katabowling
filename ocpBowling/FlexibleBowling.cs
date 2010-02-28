using System;
using System.Collections.Generic;

namespace ocpBowling
{
    public class FlexibleBowling : Bowling
    {
        private List<Frame> frames = new List<Frame>();
        private List<Rule> rules = new List<Rule>();

        public int Score()
        {
            Frame[] theFrames = frames.ToArray();
            int toReturn = 0;

            for (int i = 0; i < theFrames.Length; i++)
            {
                toReturn += theFrames[i].Total();
                int bonus = ComputeBonus(theFrames, i);
                toReturn += bonus;
            }
            return toReturn;
        }

        private int ComputeBonus(Frame[] frames, int i)
        {
            int toReturn = 0;
            foreach (Rule rule in frames[i].rules)
            {
                toReturn += rule.Bonus(frames, i);
                if (rule.ConditionToBreak(frames, i))
                {
                    break;
                }
            }
            return toReturn;
        }


        public void AddRule(Rule rule)
        {
            rules.Add(rule);
        }


        public void AddFrame(Frame frame)
        {
            frames.Add(frame);
        }
    }
}