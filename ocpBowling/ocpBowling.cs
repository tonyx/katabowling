#define DBC_CHECK_ALL
using System;
using System.Linq;
using System.Text;

namespace ocpBowling
{
    public class LastFrame : Frame
    {
        private int third;

        public LastFrame(int first)
        {
            Check.Require(first < 10);
            this.first = first;
        }

        public LastFrame(int first, int second)
        {
            Check.Require(first==10);
            this.first = first;
            this.second = second;
        }
        public LastFrame(int first, int second, int third)
        {
            Check.Require(first == 10 && second == 10);
            this.first = first;
            this.second = second;
            this.third = third;
        }
        public int Second
        {
            get
            {

                return second;
            }
        }
        public int Third
        {
            get
            {
                return third;
            }
        }
    }
}

