namespace ocpBowling
{
    public interface Rule
    {
        int Bonus(Frame[] frames, int i);
        bool ConditionToBreak(Frame[] frames, int i);
    }
}