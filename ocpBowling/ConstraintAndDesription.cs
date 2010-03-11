namespace ocpBowling
{
    public delegate bool Constraint(Frame frame);
    public class ConstraintAndDesription
    {
        private readonly Constraint _constraint;
        private readonly string _description;
                
        public ConstraintAndDesription(string description, Constraint constraint)
        {
            _description = description;
            _constraint = constraint;
        }

        public bool Matches(Frame frame)
        {
            return _constraint.Invoke(frame);
        }
        
        public override string ToString()
        {
            return "["+_description + "|"+ _constraint + " ]";
        }
    }
}