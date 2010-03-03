using System.Collections.Generic;

namespace ocpBowling
{
    public interface Bowling
    {        
        void SetRulesForFrame(List<RuleForFrame> rules, int frameIndex);
        void SetConstraintForFrame(ConstraintAndDesription constraint, int frameIndex);
        void AddFrame(Frame frame);
        int Score();
    }
}