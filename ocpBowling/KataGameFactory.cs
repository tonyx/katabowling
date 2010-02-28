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
            martianBowling.AddConstraint(x => ((x.rollsInFrame.Count == 3 &&  x.rollsInFrame.Sum()<=10)||(x.rollsInFrame.Count<3 && x.rollsInFrame.Sum() == 10)));
            martianBowling.AddConstraint(x => ((x.rollsInFrame.Count == 3 &&  x.rollsInFrame.Sum()<=10)||(x.rollsInFrame.Count<3 && x.rollsInFrame.Sum() == 10)));
            martianBowling.AddConstraint(x => ((x.rollsInFrame.Count == 3 &&  x.rollsInFrame.Sum()<=10)||(x.rollsInFrame.Count<3 && x.rollsInFrame.Sum() == 10)));
            martianBowling.AddRulesForFrame(new List<RuleForFrame>{new MartianFrameBonus()});
            martianBowling.AddRulesForFrame(new List<RuleForFrame>{new MartianFrameBonus()});
            martianBowling.AddRulesForFrame(new List<RuleForFrame>{new MartianFrameNoBonus()});
            martianBowling.Init();
            return martianBowling;
        }

        public class MartianFrameBonus : RuleForFrame
        {
            public int Bonus(Frame[] frames, int i)
            {
                if (Strike(frames[i]))
                    return frames[frames.Length - 1].rollsInFrame.Sum();
                return 0;
            }
            public bool Strike(Frame frame)
            {
                return frame.rollsInFrame[0] == 10;
            }

            public bool ConditionToBreak(Frame[] frames, int i)
            {
                return true;
            }
        }
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
}