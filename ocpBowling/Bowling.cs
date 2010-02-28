using System.Collections.Generic;

namespace ocpBowling
{
    public delegate bool Constraint(Frame frame);
    public interface Bowling
    {
        void Init();
        void AddRulesForFrame(List<Rule> rules);
        void AddConstraint(Constraint constraint);
        void AddRule(Rule rule);
        void AddFrame(Frame frame);
        int Score();
    }
}