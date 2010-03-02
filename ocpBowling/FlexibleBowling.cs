using System;
using System.Collections.Generic;
using System.Linq;
namespace ocpBowling
{
    public class FlexibleBowling : Bowling
    {
        private List<Frame> frames = new List<Frame>();
        private List<List<RuleForFrame>> rulesForFrame = new List<List<RuleForFrame>>();
        private List<ConstraintAndDesription> constraintAndDescriptionList = new List<ConstraintAndDesription>();

        private List<ConstraintAndDesription>.Enumerator _constraintsAndDescriptionEnumerator;
        private List<List<RuleForFrame>>.Enumerator rulesForFrameEnumerator;

        public void Init()
        {
            rulesForFrameEnumerator = rulesForFrame.GetEnumerator();
            _constraintsAndDescriptionEnumerator = constraintAndDescriptionList.GetEnumerator();
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


        public void AddConstraintAndDescription(ConstraintAndDesription constraintAndDescription)
        {
            constraintAndDescriptionList.Add(constraintAndDescription);
        }


        public void AddRulesForFrame(List<RuleForFrame> rules)
        {
            rulesForFrame.Add(rules);   
        }


        private void CheckConstraint(Frame frame)
        {
            if (_constraintsAndDescriptionEnumerator.MoveNext())
            {
                bool matches = _constraintsAndDescriptionEnumerator.Current.TheConstraint.Invoke(frame);
                if (!matches)
                {
                    throw new Exception("violated constraint "+_constraintsAndDescriptionEnumerator.Current +" in frame "+frame.ToString());
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