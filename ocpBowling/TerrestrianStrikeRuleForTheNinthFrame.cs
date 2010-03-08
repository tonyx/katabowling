using System.Linq;
namespace ocpBowling
{
    public class TerrestrianStrikeRuleForTheNinthFrame : RuleForFrame
    {
        public int Bonus(Frame[] frames, int i)
        {
            Frame lastFrame = ( frames[frames.Length - 1]);
            if (Strike(frames[i]))
                return lastFrame.Rolls.Take(2).Sum();
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
