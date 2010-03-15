using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ocpBowling;

namespace bowlingkata
{
    public interface IScoreRuleForFrame
    {
        int Score(Frame[] frames, int i);
    }

    public class PlainScoreRuleForFrame : IScoreRuleForFrame
    {
        public int Score(Frame[] frame, int i)
        {
            return frame[i].Rolls.Sum();
        }
    }
}
