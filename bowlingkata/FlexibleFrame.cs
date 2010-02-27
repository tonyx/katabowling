
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace ocpBowling
{
    public class FlexibleFrame
    {
        private int index;
        private int rolls;
        private int[] plays;
        public FlexibleFrame(int rolls)
        {
            this.rolls = rolls;
            plays = new int[rolls];
        }
        public void Roll(int value)
        {
            if (index<rolls)
                plays[index++] = value;
        }
    }
}