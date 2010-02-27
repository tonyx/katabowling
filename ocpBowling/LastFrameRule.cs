namespace ocpBowling
{
    public class LastFrameRule : Rule
    {
        public int Bonus(Frame[] frames, int i)
        {
            return 0;
        }

        public bool ConditionToBreak(Frame[] frames, int i)
        {
            if (frames[i] is LastFrame )
                return true;
            return false;
        }
    }
}