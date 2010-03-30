using System;
using System.Linq;
namespace ocpBowling
{
    public class TerrestrianStrikeBonusRuleForTheNinthFrame : IBonusRuleForFrame
    {
        public int Bonus(Frame[] frames, int i)
        {
            if (Strike(frames[i]))
                return frames.NextTwoRolls(i);
            return 0;   
        }

        public bool ConditionToBreak(Frame[] frames, int i)
        {
            return Strike(frames[i]);
        }

        private bool Strike(Frame frame)
        {
            return frame.Rolls[0] == 10;
        }

    }
}
