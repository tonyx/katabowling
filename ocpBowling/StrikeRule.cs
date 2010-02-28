namespace ocpBowling
{
    public class StrikeRule : Rule
    {
        public int Bonus(Frame[] frames, int i)
        {

            if (i < frames.Length - 2)
            {
                if (Strike(frames[i]))
                    if (!Strike(frames[i + 1]))
                        return frames[i + 1].rollsInFrame[0] + frames[i + 1].rollsInFrame[1];
             //           return frames[i + 1].First + frames[i + 1].Second;
                    else
             //           return frames[i + 1].First + frames[i+2].First;
                        return frames[i + 1].rollsInFrame[0]+ frames[i+2].rollsInFrame[0];
            }
            if (i==frames.Length-2)
            {
//                LastFrame lastFrame = ((LastFrame) frames[frames.Length - 1]);
                Frame lastFrame = ( frames[frames.Length - 1]);
                if (Strike(frames[i]))
                    return lastFrame.SumOfFirstTwo();

                return 0;   
//                    return lastFrame.rollsInFrame[0] + lastFrame.rollsInFrame[1];

            }

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
            return frame.rollsInFrame[0] == 10;
//            return frame.First == 10;
        }
    }
}