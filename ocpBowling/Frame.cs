﻿#define DBC_CHECK_ALL

using System.Collections.Generic;
using System.Linq;

namespace ocpBowling
{
    public class Frame 
    {
        readonly List<int> rollsInFrame;

        public Frame(List<int> rolls)
        {
            rollsInFrame = rolls;   
        }

        public Frame(params int[] args)
        {
            rollsInFrame = args.ToList();
        }

        public List<int > Rolls
        {
            get
            {
                return rollsInFrame;
            }
        }

        public override string ToString()
        {
            return Rolls.Aggregate("",(x,y) => x+=(y+" "));
        }
    }
}