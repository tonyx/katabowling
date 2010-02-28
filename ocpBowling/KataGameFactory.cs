using System.Collections.Generic;

namespace ocpBowling
{
    public static class KataGameFactory
    {
        public static Bowling getTerrestrialBowling()
        {
            Bowling genericGenericBowling = new FlexibleBowling();
            List<RuleForFrame> ruleForPlainFrame =   new List<RuleForFrame>();
            ruleForPlainFrame.Add(new StrikeRule());
            ruleForPlainFrame.Add(new SpareRule());
            
            List<RuleForFrame> rulesForLastFrame = new List<RuleForFrame>();
            rulesForLastFrame.Add(new LastFrameRule());

            for (int i =0;i<9;i++)
                genericGenericBowling.AddConstraint(x => x.Total()<=10&&((x.rollsInFrame[0]==10&&x.rollsInFrame.Count==1)||(x.rollsInFrame[0]<10&&x.rollsInFrame.Count>1)));
            
            genericGenericBowling.AddConstraint(x => x.Total()<=30 && (x.rollsInFrame[0]<10||x.rollsInFrame.Count>1));
       
            for (int i = 0; i < 9;i++ )
                genericGenericBowling.AddRulesForFrame(ruleForPlainFrame);

            genericGenericBowling.AddRulesForFrame(rulesForLastFrame);                                   
            genericGenericBowling.Init();

            return genericGenericBowling;
        }

        public static Bowling getMartianBowling()
        {
            Bowling martianBowling = new FlexibleBowling();
            martianBowling.AddConstraint(x => x.rollsInFrame.Count<=3);
            martianBowling.Init();
            return martianBowling;
        }
        


    }
}