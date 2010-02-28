﻿#define DBC_CHECK_ALL

using System.Collections.Generic;
using System.Linq;

namespace ocpBowling
{
    public class Frame : Iframe
    {
        public List<int> rollsInFrame;


        public Frame(params int[] args)
        {
            rollsInFrame = args.ToList();
        }

        public int Total()
        {
            return rollsInFrame.Sum(x => x);
        }

        public int SumOfFirstTwo()
        {
            return rollsInFrame.Take(2).Sum();
        }                
    }

    public interface Iframe
    {
        int Total();
        int SumOfFirstTwo();
    }
}