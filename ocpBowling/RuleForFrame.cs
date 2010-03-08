using System.Linq;

namespace ocpBowling
{
    public interface RuleForFrame
    {
        int Bonus(Frame[] frames, int i);
        bool ConditionToBreak(Frame[] frames, int i);
    }
}