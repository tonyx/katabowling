namespace ocpBowling
{
    public static class KataGameFactory
    {
        public static Bowling getTerrestrialBowling()
        {
            Bowling genericGenericBowling = new FlexibleBowling();

//            genericGenericBowling.AddRule(new LastFrameRule());
//            genericGenericBowling.AddRule(new StrikeRule());
//            genericGenericBowling.AddRule(new SpareRule());
            return genericGenericBowling;
        }
    }
}