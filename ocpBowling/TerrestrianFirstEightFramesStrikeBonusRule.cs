using System;

namespace ocpBowling
{
    class TerrestrianFirstEightFramesStrikeBonusRule : IBonusRuleForFrame
    {
        public int Bonus(Frame[] frames, int i)
        {
            return NextTwoRolls(frames, i);
        }

        public bool ConditionToBreak(Frame[] frames, int i)
        {
            return Matches(frames, i);
        }

        private bool Matches(Frame[] frames, int i)
        {
            return Strike(frames[i]);
        }

        private bool Strike(Frame frame)
        {
            return frame.Rolls[0] == 10;
        }

        private int NextTwoRolls(Frame[] frames, int i)
        {
            if (Strike(frames[i]))
                if (Strike(frames[i + 1]))
                    return frames[i + 1].Rolls[0] + frames[i + 2].Rolls[0];
                else
                    return frames[i + 1].Rolls[0] + frames[i + 1].Rolls[1];
            return 0;
        }
    }
}