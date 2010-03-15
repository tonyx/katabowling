using System;
using System.Collections.Generic;
using System.Linq;
using bowlingkata;

namespace ocpBowling
{
    public static class BowlingFactory
    {
        public static Bowling CreateTerrestrialBowling()
        {
            Bowling terrestrialBowling = new Bowling();
            SetTerrestrialBowlingFrameConstraints(terrestrialBowling);
            SetTerrestrianBonusRules(terrestrialBowling);
            SetTerrestrialScorerules(terrestrialBowling);
            return terrestrialBowling;
        }

        public static Bowling CreateMartianBowling()
        {
            Bowling martianBowling = new Bowling();
            SetMartianBowlingFrameConstraints(martianBowling);
            SetMartianBowlingRules(martianBowling);
            SetMartianBowlingScoreRules(martianBowling);
            return martianBowling;
        }


        private static void SetTerrestrialScorerules(Bowling terrestrialBowling)
        {
            IScoreRuleForFrame plainScoreRuleForFrame = new PlainScoreRuleForFrame();
            for (int i=0;i<10;i++)
                terrestrialBowling.SetScoreForFrame(plainScoreRuleForFrame,i);
        }


        private static void SetMartianBowlingScoreRules(Bowling bowling)
        {
            IScoreRuleForFrame plainScoreRuleForFrame = new PlainScoreRuleForFrame();
            for (int i = 0; i < 10; i++)
                bowling.SetScoreForFrame(plainScoreRuleForFrame, i);
            
        }

        private static void SetMartianBowlingRules(Bowling martianBowling)
        {
            martianBowling.SetRulesForFrame(new List<IBonusRuleForFrame>{new MartianFrameBonus()},0);
            martianBowling.SetRulesForFrame(new List<IBonusRuleForFrame>{new MartianFrameBonus()},1);
            martianBowling.SetRulesForFrame(new List<IBonusRuleForFrame>{new MartianFrameNoBonus()},2);
        }

        private static void SetMartianBowlingFrameConstraints(Bowling martianBowling)
        {
            Constraint upToThreeRollsUnlessDropTenEarlier =
                x => ((x.Rolls.Count == 3 && x.Rolls.Sum() <= 10) || (x.Rolls.Count < 3 && x.Rolls.Sum() == 10));
            
            ConstraintAndDescription upToThreeRollsUnlessDropTenEarlierD =
                new ConstraintAndDescription("up to three rolls unless drop ten earlier",upToThreeRollsUnlessDropTenEarlier);

            martianBowling.SetConstraintForFrame(upToThreeRollsUnlessDropTenEarlierD,0);
            martianBowling.SetConstraintForFrame(upToThreeRollsUnlessDropTenEarlierD,1);
            martianBowling.SetConstraintForFrame(upToThreeRollsUnlessDropTenEarlierD,2);
        }


        private static void SetTerrestrianBonusRules(Bowling terrestrialBowling)
        {
            List<IBonusRuleForFrame> ruleForNinthFrame = new List<IBonusRuleForFrame> { new TerrestrianStrikeBonusRuleForTheNinthFrame(), new TerrestrianSpareBonusRule() };
            List<IBonusRuleForFrame> ruleForFirstEightFrame = new List<IBonusRuleForFrame> {new TerrestrianFirstEightFramesStrikeBonusRule(),new TerrestrianSpareBonusRule()};            
            List<IBonusRuleForFrame> rulesForLastFrame = new List<IBonusRuleForFrame> { new TerrestrianLastFrameBonusRule() };


            for (int i = 0; i < 8;i++ )
            {
                terrestrialBowling.SetRulesForFrame(ruleForFirstEightFrame,i);
            }
            terrestrialBowling.SetRulesForFrame(ruleForNinthFrame, 8);

            terrestrialBowling.SetRulesForFrame(rulesForLastFrame,9);
        }


        private static void SetTerrestrialBowlingFrameConstraints(Bowling terrestrialBowling)
        {
            Constraint sumOfAllRollMustbeLessThanTen = (x => x.Rolls.Sum() <= 10);
            Constraint ifFirstRollIsTenThanTheFrameIsOver = (x => (!(x.Rolls[0] == 10) || x.Rolls.Count == 1));
            Constraint ifFirstRollIsLessThanTenThenThereIsAnotherRollInTheFrame = 
                (x => (!(x.Rolls[0] < 10) || x.Rolls.Count == 2));

            Constraint plainFrameConstraint =
                            (x =>
                             (sumOfAllRollMustbeLessThanTen(x) &&
                              (ifFirstRollIsTenThanTheFrameIsOver(x) && 
                              ifFirstRollIsLessThanTenThenThereIsAnotherRollInTheFrame(x))));

            ConstraintAndDescription plainFrameConstraintD = 
                new ConstraintAndDescription("sum of all roll must be less or equals to ten AND "+
                    "(frame with strike has only one roll OR frame with no strike has two rolls)", plainFrameConstraint);

            for (int i = 0; i < 9; i++)
            { 
                terrestrialBowling.SetConstraintForFrame(plainFrameConstraintD,i);
            }

            Constraint sumRollsNoHigherThanThirty = x => x.Rolls.Sum() <= 30;
            Constraint ifFirstRollIsTenThanThereIsAtLeastAnotherRoll = x => !(x.Rolls[0]==10)||x.Rolls.Count > 1;

            Constraint ifSecondRollIsTenThenThereIsAnotherRoll =
                x => (!(x.Rolls.Count > 1 && x.Rolls[1] == 10) || x.Rolls.Count == 3);

            Constraint noHigherThanThirtyAndAllowMoreRollsIfNoStrike =
                x => (sumRollsNoHigherThanThirty(x) && 
                    ifFirstRollIsTenThanThereIsAtLeastAnotherRoll(x)&& 
                    ifSecondRollIsTenThenThereIsAnotherRoll(x));

            ConstraintAndDescription noHigherThanThirtyAndAllowMoreRollsIfNoStrikeD = new ConstraintAndDescription("noHigherThanThirtyAndAllowMoreRollsIfNoStrike", noHigherThanThirtyAndAllowMoreRollsIfNoStrike);

            terrestrialBowling.SetConstraintForFrame(noHigherThanThirtyAndAllowMoreRollsIfNoStrikeD,9);
               
        }
    }
}
