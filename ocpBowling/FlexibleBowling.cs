using System;
using System.Collections.Generic;
using System.Linq;
namespace ocpBowling
{
    public class FlexibleBowling : Bowling
    {
        private List<Frame> frames = new List<Frame>();
        private List<Constraint> constraintsForFrame = new List<Constraint>();
        private List<List<RuleForFrame>> rulesForFrame = new List<List<RuleForFrame>>();

        private List<Constraint>.Enumerator constraintsEnumerator;
        private List<List<RuleForFrame>>.Enumerator rulesForFrameEnumerator;

        public void Init()
        {
            constraintsEnumerator =  constraintsForFrame.GetEnumerator();
            rulesForFrameEnumerator = rulesForFrame.GetEnumerator();
        }

        public int Score()
        {
            Frame[] theFrames = frames.ToArray();
            int toReturn = 0;

            for (int i = 0; i < theFrames.Length; i++)
            {
                toReturn += theFrames[i].Rolls.Sum();                
                int bonus = ComputeBonus(theFrames, i);
                toReturn += bonus;
            }
            return toReturn;
        }

        private int ComputeBonus(Frame[] frames, int i)
        {
            int toReturn = 0;
            if (rulesForFrameEnumerator.MoveNext())
            {
                foreach (RuleForFrame rule in rulesForFrameEnumerator.Current)
                {
                    toReturn += rule.Bonus(frames, i);
                    if (rule.ConditionToBreak(frames, i))
                    {
                        break;
                    }
                }
                return toReturn;
            }
            return 0;
        }

        public void AddConstraint(Constraint constraint)
        {
            constraintsForFrame.Add(constraint);
        }

        
        public void AddRulesForFrame(List<RuleForFrame> rules)
        {
            rulesForFrame.Add(rules);   
        }


        private void CheckConstraint(Frame frame)
        {
            if (constraintsEnumerator.MoveNext())
            {
                bool matches = constraintsEnumerator.Current.Invoke(frame);
                if (!matches)
                {
                    throw new Exception("violated constraint in frame "+frame.ToString());
                }
            }
            else
                throw new Exception("rule error: the constraint rules are mandatories");
        }


        public void AddFrame(Frame frame)
        {
            CheckConstraint(frame);
            frames.Add(frame);
        }
    }
}