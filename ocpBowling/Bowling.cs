using System;
using System.Collections.Generic;
using System.Linq;
using bowlingkata;

namespace ocpBowling
{
    public class Bowling
    {

        private Dictionary<int,List<DelBonusRuleForFrame>> _indexBonusRuleForFrame = new Dictionary<int, List<DelBonusRuleForFrame>>();
        private List<int> rollsNotInFrame = new List<int>();
        private Dictionary<int, ConstraintAndDescription> indexConstraintForFrame = new Dictionary<int, ConstraintAndDescription>();
        private List<Frame> frames = new List<Frame>();

        private Dictionary<int,DelScoreRuleForFrame> delBasedRuleForFrame = new Dictionary<int, DelScoreRuleForFrame>();

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
                toReturn += ComputeScore(theFrames, i);
                int bonus = ComputeBonus(theFrames, i);
                toReturn += bonus;
            }
            return toReturn;
        }

        private int ComputeScore(Frame[] frames, int i)
        {
            int toReturn = 0;

            DelScoreRuleForFrame scoreScoreRuleForFrame;
            if (this.delBasedRuleForFrame.TryGetValue(i,out scoreScoreRuleForFrame))
            {
                return scoreScoreRuleForFrame.Invoke(frames[i]);
            }

            throw new FormatException("no score rule associated to frame index " + i);
        }

        private int ComputeBonus(Frame[] frames, int i)
        {
            int toReturn = 0;


            List<DelBonusRuleForFrame> bonusRulesForFrames;
            if (this._indexBonusRuleForFrame.TryGetValue(i,out bonusRulesForFrames))
            {
                foreach(DelBonusRuleForFrame rule in bonusRulesForFrames)
                {
                    toReturn += rule.Invoke(frames, i);
                }
                return toReturn;
            }
            throw new FormatException("no bonus rules list for the index "+i);
            
        }


        public void SetConstraintForFrame(ConstraintAndDescription constraint, int frameIndex)
        {
            indexConstraintForFrame.Add(frameIndex,constraint);
        }

        public void SetDelRuleForFrameIndex(DelScoreRuleForFrame scoreRule,int frameIndex)
        {
            this.delBasedRuleForFrame.Add(frameIndex,scoreRule);
        }


        public void SetDelBonusRulesForFrame(List<DelBonusRuleForFrame> bonusRule,int frameIndex)
        {
            this._indexBonusRuleForFrame.Add(frameIndex, bonusRule);            
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

    public delegate int DelScoreRuleForFrame(Frame frame);
    public delegate int DelBonusRuleForFrame(Frame[] frames, int index);
    
}