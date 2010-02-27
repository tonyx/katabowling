namespace ocpBowling
{
    public interface Bowling
    {
        void AddRule(Rule rule);
        void AddFrame(Frame frame);
        int Score();
    }
}