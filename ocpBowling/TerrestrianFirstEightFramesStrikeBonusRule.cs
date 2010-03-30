﻿using System;
using System.Linq;

namespace ocpBowling
{
    class TerrestrianFirstEightFramesStrikeBonusRule : IBonusRuleForFrame
    {
        public int Bonus(Frame[] frames, int i)
        {
            if (Strike(frames[i]))
                return frames.NextTwoRolls(i);
            return 0;
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

    }
}