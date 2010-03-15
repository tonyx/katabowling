using System;
using System.Linq;

namespace ocpBowling
{
    public class MartianFrameBonus : IBonusRuleForFrame
    {
        public int Bonus(Frame[] frames, int i)
        {
            if (Strike(frames[i]))
                return frames[frames.Length - 1].Rolls.Sum();
            return 0;
        }
        private bool Strike(Frame frame)
        {
            return frame.Rolls[0] == 10;
        }

        public bool ConditionToBreak(Frame[] frames, int i)
        {
            return true;
        }

    }
}