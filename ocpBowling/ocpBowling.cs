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


    public class SpareRule : Rule
    {

        public int Bonus(Frame[] frames, int i)
        {
            if (Matches(frames, i))
                return frames[i + 1].First;

            return 0;
        }

        private bool Matches(Frame[] frames, int i)
        {
            if (i != frames.Length - 1)
                if (spare(frames[i]))
                    return true;
            return false;
        }

        public bool ConditionToBreak(Frame[] frames, int i)
        {
            if (Matches(frames, i))
                return true;
            return false;
        }

        private bool spare(Frame frame)
        {
            return frame.First + frame.Second == 10;
        }

    }

    public class StrikeRule : Rule
    {
        public int Bonus(Frame[] frames, int i)
        {

            if (i < frames.Length - 2)
            {
                if (Strike(frames[i]))
                    if (!Strike(frames[i + 1]))
                        return frames[i + 1].First + frames[i + 1].Second;
                    else
                        return frames[i + 1].First + frames[i+2].First;
            }
            if (i==frames.Length-2)
            {
                LastFrame lastFrame = ((LastFrame) frames[frames.Length - 1]);
                if (Strike(frames[i]))
                    return lastFrame.First + lastFrame.Second;
            }

        

//            else
//            {
//                return (frames[i + 1].First);
//            }
            return 0;
        }

        public bool ConditionToBreak(Frame[] frames, int i)
        {
            if (Matches(frames, i))
                return true;
            return false;
        }

        public bool Matches(Frame[] frames, int i)
        {
            if (i != frames.Length - 1)
                if (Strike(frames[i]))
                    return true;
            return false;

        }

        private bool Strike(Frame frame)
        {
            return frame.First == 10;
        }
    }


    public class LastFrameRule : Rule
    {
        public int Bonus(Frame[] frames, int i)
        {
            //            if (i==frames.Length-1)
            //            {
            //                if (frames[i].First==10)
            //                return frames[i].Second;   
            //            }
            return 0;
        }

        public bool ConditionToBreak(Frame[] frames, int i)
        {
            if (frames[i] is LastFrame )
                return true;
            return false;
        }
    }


    public interface Bowling
    {
        void AddRule(Rule rule);
        void AddFrame(Frame frame);
        int Score();
    }
}

