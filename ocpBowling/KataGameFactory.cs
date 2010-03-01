using System;
using System.Collections.Generic;
using System.Linq;

namespace ocpBowling
{
    public static class KataGameFactory
    {
        public static Bowling getTerrestrialBowling()
        {
            Bowling genericGenericBowling = new FlexibleBowling();
            List<RuleForFrame> ruleForPlainFrame =   new List<RuleForFrame>(){new StrikeRule(),new SpareRule()};
            
            List<RuleForFrame> rulesForLastFrame = new List<RuleForFrame>();
            rulesForLastFrame.Add(new LastFrameRule());
            for (int i =0;i<9;i++)
                genericGenericBowling.AddConstraint(x => x.Rolls.Sum()<=10&&((x.Rolls[0]==10&&x.Rolls.Count==1)||(x.Rolls[0]<10&&x.Rolls.Count>1)));            
            genericGenericBowling.AddConstraint(x => x.Rolls.Sum()<=30 && (x.Rolls[0]<10||x.Rolls.Count>1));       
            for (int i = 0; i < 9;i++ )
                genericGenericBowling.AddRulesForFrame(ruleForPlainFrame);
            genericGenericBowling.AddRulesForFrame(rulesForLastFrame);                                   
            genericGenericBowling.Init();

            return genericGenericBowling;
        }

        public static Bowling getMartianBowling()
        {
            Bowling martianBowling = new FlexibleBowling();
            martianBowling.AddConstraint(x => ((x.Rolls.Count == 3 &&  x.Rolls.Sum()<=10)||(x.Rolls.Count<3 && x.Rolls.Sum() == 10)));
            martianBowling.AddConstraint(x => ((x.Rolls.Count == 3 &&  x.Rolls.Sum()<=10)||(x.Rolls.Count<3 && x.Rolls.Sum() == 10)));
            martianBowling.AddConstraint(x => ((x.Rolls.Count == 3 &&  x.Rolls.Sum()<=10)||(x.Rolls.Count<3 && x.Rolls.Sum() == 10)));
            martianBowling.AddRulesForFrame(new List<RuleForFrame>{new MartianFrameBonus()});
            martianBowling.AddRulesForFrame(new List<RuleForFrame>{new MartianFrameBonus()});
            martianBowling.AddRulesForFrame(new List<RuleForFrame>{new MartianFrameNoBonus()});
            martianBowling.Init();
            return martianBowling;
        }


    }
}
