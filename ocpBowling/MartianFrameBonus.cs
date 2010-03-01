using System.Linq;

namespace ocpBowling
{
    public class MartianFrameBonus : RuleForFrame
    {
        public int Bonus(Frame[] frames, int i)
        {
            if (Strike(frames[i]))
                return frames[frames.Length - 1].Rolls.Sum();
            return 0;
        }
        public bool Strike(Frame frame)
        {
            return frame.Rolls[0] == 10;
        }

        public bool ConditionToBreak(Frame[] frames, int i)
        {
            return true;
        }
    }
}