namespace ocpBowling
{
    public class MartianFrameNoBonus : RuleForFrame
    {        
        public int Bonus(Frame[] frames, int i)
        {
            return 0;
        }

        public bool ConditionToBreak(Frame[] frames, int i)
        {
            return true;
        }
    }
}