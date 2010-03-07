﻿using System;
using System.Collections.Generic;

namespace ocpBowling
{
    public interface Bowling
    {        
        void SetRulesForFrame(List<RuleForFrame> rules, int frameIndex);
        void SetConstraintForFrame(ConstraintAndDesription constraint, int frameIndex);
        /// <exception cref="FormatException"></exception>
        void AddFrame(Frame frame);
        List<Frame> Frames();
        void Roll(int roll);
        int Score();
    }
}