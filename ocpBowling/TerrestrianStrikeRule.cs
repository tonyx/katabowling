using System.Linq;
namespace ocpBowling
{
    public class TerrestrianStrikeRule : RuleForFrame
    {
        public int Bonus(Frame[] frames, int i)
        {
            if (i < frames.Length - 2)
            {
                if (Strike(frames[i]))
                    if (!Strike(frames[i + 1]))
                        return frames[i + 1].Rolls[0] + frames[i + 1].Rolls[1];
                    else
                        return frames[i + 1].Rolls[0]+ frames[i+2].Rolls[0];
            }
            if (i==frames.Length-2)
            {
                Frame lastFrame = ( frames[frames.Length - 1]);
                if (Strike(frames[i]))
                    return lastFrame.Rolls.Take(2).Sum();
                return 0;   
            }

            return 0;
        }

        public bool ConditionToBreak(Frame[] frames, int i)
        {
            if (Matches(frames, i))
                return true;
            return false;
        }

        private bool Matches(Frame[] frames, int i)
        {
            if (i != frames.Length - 1)
                if (Strike(frames[i]))
                    return true;
            return false;
        }

        private bool Strike(Frame frame)
        {
            return frame.Rolls[0] == 10;
        }
    }
}
