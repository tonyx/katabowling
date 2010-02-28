using System.Collections.Generic;

namespace ocpBowling
{
    public delegate bool Constraint(Frame frame);
    public interface Bowling
    {
        void Init();
        void AddRulesForFrame(List<RuleForFrame> rules);
        void AddConstraint(Constraint constraint);
        void AddFrame(Frame frame);
        int Score();
    }
}