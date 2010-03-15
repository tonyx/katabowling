using System;
using System.Collections.Generic;
using System.Linq;
using bowlingkata;

namespace ocpBowling
{
    public class Bowling
    {
        private Dictionary<int,IScoreRuleForFrame> indexPlainScoreRuleForFrame = new Dictionary<int, IScoreRuleForFrame>();
        private List<int> rollsNotInFrame = new List<int>();
        private Dictionary<int, List<IBonusRuleForFrame>> indexRuleForFrame = new Dictionary<int, List<IBonusRuleForFrame>>();
        private Dictionary<int, ConstraintAndDescription> indexConstraintForFrame = new Dictionary<int, ConstraintAndDescription>();
        private List<Frame> frames = new List<Frame>();


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
//                toReturn += ComputeScoreForFrame(theFrames[i]);
                toReturn += ComputeScore(theFrames, i);
                int bonus = ComputeBonus(theFrames, i);
                toReturn += bonus;
            }
            return toReturn;
        }

        private int ComputeScore(Frame[] frames, int i)
        {
            int toReturn = 0;
            IScoreRuleForFrame scoreRule;
            if (indexPlainScoreRuleForFrame.TryGetValue(i, out scoreRule))
            {
                return scoreRule.Score(frames, i);
            }

            return ComputeScoreForFrame(frames[i]);
        }

        private int ComputeScoreForFrame(Frame frame)
        {
            return frame.Rolls.Sum();
        }


        private int ComputeBonus(Frame[] frames, int i)
        {
            int toReturn = 0;
            List<IBonusRuleForFrame> ruleForFrames;

            if (indexRuleForFrame.TryGetValue(i, out ruleForFrames))
            {
                foreach (IBonusRuleForFrame rule in ruleForFrames)
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


        public void SetConstraintForFrame(ConstraintAndDescription constraint, int frameIndex)
        {
            indexConstraintForFrame.Add(frameIndex,constraint);
        }



        public void SetRulesForFrame(List<IBonusRuleForFrame> rules, int frameIndex)
        {
            indexRuleForFrame.Add(frameIndex,rules);
        }

        public void SetScoreForFrame(IScoreRuleForFrame scoreRule, int frameIndex)
        {
            this.indexPlainScoreRuleForFrame.Add(frameIndex,scoreRule);            
        }


        /// <exception cref="FormatException"></exception>
        private void CheckConstraint(Frame frame, int index)
        {
            ConstraintAndDescription constrintAndDescription;
            if (indexConstraintForFrame.TryGetValue(index,out constrintAndDescription))
            {
                if (!constrintAndDescription.Matches(frame))
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