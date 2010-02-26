﻿#define DBC_CHECK_ALL
namespace ocpBowling
{
    public class Frame
    {
        protected int first;
        protected int second;

        public Frame(int first, int second)
        {
            Check.Require(first + second <= 10);
            this.first = first;
            this.second = second;
        }
        protected Frame()
        {
        }

        public int First
        {
            get { return first; }
        }

        public int Second
        {
            get { return second; }
        }
    }
}