using System.Collections.Generic;

namespace ocpBowling
{
    public static class KataGameFactory
    {
        public static Bowling getTerrestrialBowling()
        {
            Bowling genericGenericBowling = new FlexibleBowling();
            List<Rule> ruleForPlainFrame =   new List<Rule>();
            ruleForPlainFrame.Add(new StrikeRule());
            ruleForPlainFrame.Add(new SpareRule());

            List<Rule> rulesForLastFrame = new List<Rule>();
            rulesForLastFrame.Add(new LastFrameRule());
            for (int i =0;i<9;i++)
                genericGenericBowling.AddConstraint(x => x.Total()<=10&&x.rollsInFrame[0]<10||x.rollsInFrame.Count==1);
            
            genericGenericBowling.AddConstraint(x => x.Total()<=30 && x.rollsInFrame[0]<10||x.rollsInFrame.Count>1);
            for (int i = 0; i < 9;i++ )
                genericGenericBowling.AddRulesForFrame(ruleForPlainFrame);

            genericGenericBowling.AddRulesForFrame(rulesForLastFrame);            
            
            genericGenericBowling.Init();

            return genericGenericBowling;
        }
    }
}