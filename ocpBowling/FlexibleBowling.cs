using System;
using System.Collections.Generic;

namespace ocpBowling
{
    public class FlexibleBowling : Bowling
    {
        private List<Frame> frames = new List<Frame>();
        private List<Rule> rules = new List<Rule>();
        private List<Constraint> constraints = new List<Constraint>();
        private List<List<Rule>> rulesForFrame = new List<List<Rule>>();

        private List<Constraint>.Enumerator constraintsEnumerator;
        private List<List<Rule>>.Enumerator rulesForFrameEnumerator;

        public void Init()
        {
            constraintsEnumerator =  constraints.GetEnumerator();
            rulesForFrameEnumerator = rulesForFrame.GetEnumerator();
        }

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

            rulesForFrameEnumerator.MoveNext();
            foreach (Rule rule in rulesForFrameEnumerator.Current)
            {
                toReturn += rule.Bonus(frames, i);
                if (rule.ConditionToBreak(frames, i))
                {
                    break;
                }                
            }

//            foreach (Rule rule in frames[i].rules)
//            {
//                toReturn += rule.Bonus(frames, i);
//                if (rule.ConditionToBreak(frames, i))
//                {
//                    break;
//                }
//            }

            return toReturn;
        }

        public void AddConstraint(Constraint constraint)
        {
            constraints.Add(constraint);
        }

        
        public void AddRulesForFrame(List<Rule> rules)
        {
            this.rulesForFrame.Add(rules);   
        }

        public void AddRule(Rule rule)
        {
            rules.Add(rule);
        }

        private void CheckConstraint(Frame frame)
        {
            try
            {
                constraintsEnumerator.MoveNext();
                bool matches = constraintsEnumerator.Current.Invoke(frame);
                if (!matches)
                {
                    throw new Exception("constraint violation");
                }
            } catch
            {
                throw new Exception("constraint violation");   
            }
        }


        public void AddFrame(Frame frame)
        {
            CheckConstraint(frame);
            frames.Add(frame);
        }
    }
}