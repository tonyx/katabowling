using System.Linq;
namespace ocpBowling
{
    public class TerrestrianSpareRule : RuleForFrame
    {

        public int Bonus(Frame[] frames, int i)
        {
            if (Matches(frames, i))
                return frames[i + 1].Rolls[0];            
            return 0;
        }

        private bool Matches(Frame[] frames, int i)
        {
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
            return ((frame.Rolls.Sum(x => x))==10);
        }

    }
}