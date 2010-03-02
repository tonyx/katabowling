using System.Collections.Generic;

namespace ocpBowling
{
    public delegate bool Constraint(Frame frame);
    public interface Bowling
    {
        void Init();
        void AddRulesForFrame(List<RuleForFrame> rules);
        void AddConstraintAndDescription(ConstraintAndDesription constraintAndDescription);
        void AddFrame(Frame frame);
        int Score();
    }

    public class ConstraintAndDesription
    {
        private readonly Constraint _constraint;
        private readonly string _description;
                
        public ConstraintAndDesription(string description, Constraint constraint)
        {
            _description = description;
            _constraint = constraint;
        }
        
        public Constraint TheConstraint
        {
            get
            {
                return _constraint;
            }
        }
        public override string ToString()
        {
            return "["+_description + "|"+ _constraint + " ]";
        }

    }

}