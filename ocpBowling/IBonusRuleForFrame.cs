using System.Linq;

namespace ocpBowling
{
    
    public interface IBonusRuleForFrame
    {
        int Bonus(Frame[] frames, int i);
        bool ConditionToBreak(Frame[] frames, int i);
    }
}