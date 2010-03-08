using System;
using System.Collections.Generic;
using System.Linq;
namespace ocpBowling
{
    public class Bowling
    {
        private List<int> rollsNotInFrame = new List<int>();
        private Dictionary<int, List<RuleForFrame>> indexRuleForFrame = new Dictionary<int, List<RuleForFrame>>();
        private Dictionary<int, ConstraintAndDesription> indexConstraintForFrame = new Dictionary<int, ConstraintAndDesription>();
        private List<Frame> frames = new List<Frame>();
        private List<ConstraintAndDesription> constraintAndDescriptionList = new List<ConstraintAndDesription>();


        public void Roll(int roll)
        {
            rollsNotInFrame.Add(roll);
            Frame newFrame = new Frame(rollsNotInFrame);
            try
            {
                this.AddFrame(newFrame);
                rollsNotInFrame=new List<int>();
            } catch (FormatException e)
            {                
            }
        }

        public int Score()
        {
            Frame[] theFrames = frames.ToArray();
            int toReturn = 0;

            for (int i = 0; i < theFrames.Length; i++)
            {
                toReturn += ComputeScoreForFrame(theFrames[i]);
                int bonus = ComputeBonus(theFrames, i);
                toReturn += bonus;
            }
            return toReturn;
        }

        private int ComputeScoreForFrame(Frame frame)
        {
            return frame.Rolls.Sum();
        }


        private int ComputeBonus(Frame[] frames, int i)
        {
            int toReturn = 0;
            List<RuleForFrame> ruleForFrames;

            if (indexRuleForFrame.TryGetValue(i, out ruleForFrames))
            {
                foreach (RuleForFrame rule in ruleForFrames)
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


        public void SetConstraintForFrame(ConstraintAndDesription constraint, int frameIndex)
        {
            indexConstraintForFrame.Add(frameIndex,constraint);
        }

        public void AddConstraintAndDescription(ConstraintAndDesription constraintAndDescription)
        {
            constraintAndDescriptionList.Add(constraintAndDescription);
        }


        public void SetRulesForFrame(List<RuleForFrame> rules, int frameIndex)
        {
            indexRuleForFrame.Add(frameIndex,rules);
        }
       



        /// <exception cref="FormatException"></exception>
        private void CheckConstraint(Frame frame, int index)
        {
            ConstraintAndDesription constrintAndDescription;
            if (indexConstraintForFrame.TryGetValue(index,out constrintAndDescription))
            {
                bool matches = constrintAndDescription.TheConstraint.Invoke(frame);
                if (!matches)
                {
                    throw new FormatException("violated constraint " + constrintAndDescription + " in frame " + frame.ToString());                    
                }                
            }
            else
                throw new FormatException("rule error: there is no constraint for frame index "+index);            
        }


        /// <exception cref="FormatException"></exception>
        public void AddFrame(Frame frame)
        {
            CheckConstraint(frame,frames.Count);
            frames.Add(frame);
        }

        public List<Frame> Frames()
        {
            return this.frames;
        }
    }
}