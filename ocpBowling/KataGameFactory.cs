using System;
using System.Collections.Generic;
using System.Linq;

namespace ocpBowling
{
    public static class KataGameFactory
    {
        public static Bowling getTerrestrialBowling()
        {
            Bowling terrestrialBowling = new FlexibleBowling();
            SetConstraintsForFirstNineFrames(terrestrialBowling);
            SetTerrestrianBonusRules(terrestrialBowling);
            terrestrialBowling.Init();
            return terrestrialBowling;
        }

        public static Bowling getMartianBowling()
        {
            Bowling martianBowling = new FlexibleBowling();

            Constraint upToThreeRollsUnlessDropTenEarlier =
                x => ((x.Rolls.Count == 3 && x.Rolls.Sum() <= 10) || (x.Rolls.Count < 3 && x.Rolls.Sum() == 10));
            
            martianBowling.AddConstraint(upToThreeRollsUnlessDropTenEarlier);
            martianBowling.AddConstraint(upToThreeRollsUnlessDropTenEarlier);
            martianBowling.AddConstraint(upToThreeRollsUnlessDropTenEarlier);

            martianBowling.AddRulesForFrame(new List<RuleForFrame> { new MartianFrameBonus() });
            martianBowling.AddRulesForFrame(new List<RuleForFrame> { new MartianFrameBonus() });
            martianBowling.AddRulesForFrame(new List<RuleForFrame> { new MartianFrameNoBonus() });
            martianBowling.Init();
            return martianBowling;
        }



        private static void SetTerrestrianBonusRules(Bowling terrestrialBowling)
        {
            List<RuleForFrame> ruleForPlainFrame = new List<RuleForFrame> { new TerrestrianStrikeRule(), new TerrestrianSpareRule() };
            List<RuleForFrame> rulesForLastFrame = new List<RuleForFrame> { new TerrestrianLastFrameRule() };

            for (int i = 0; i < 9;i++ )
                terrestrialBowling.AddRulesForFrame(ruleForPlainFrame);
            
            terrestrialBowling.AddRulesForFrame(rulesForLastFrame);
        }


        private static void SetConstraintsForFirstNineFrames(Bowling terrestrialBowling)
        {
            Constraint sumOfAllRollMustbeLessThanTen = (x => x.Rolls.Sum() <= 10);
            Constraint frameWithStrikeHasOnlyOneRoll = (x => (x.Rolls[0] == 10 && x.Rolls.Count == 1));
            Constraint frameWithNoStrikeHasTwoRolls = (x => (x.Rolls[0] < 10 && x.Rolls.Count == 2));
            Constraint plainFrameConstraint =
                (x =>
                 (sumOfAllRollMustbeLessThanTen(x) &&
                  (frameWithStrikeHasOnlyOneRoll(x) || frameWithNoStrikeHasTwoRolls(x))));

            for (int i = 0; i < 9; i++)
                terrestrialBowling.AddConstraint(plainFrameConstraint);

            Constraint sumRollsNoHigherThanThirty = x => x.Rolls.Sum() <= 30;
            Constraint ifFirstRollIsTenThanThereIsAtLeastAnotherRoll = x => x.Rolls[0]<10||x.Rolls.Count > 1;
            
            terrestrialBowling.AddConstraint(x => sumRollsNoHigherThanThirty(x) && ifFirstRollIsTenThanThereIsAtLeastAnotherRoll(x));
        }
    }
}
