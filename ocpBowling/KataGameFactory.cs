﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ocpBowling
{
    public static class KataGameFactory
    {
        public static Bowling getTerrestrialBowling()
        {
            Bowling terrestrialBowling = new FlexibleBowling();
            SetTerrestrialBowlingConstraints(terrestrialBowling);
            SetTerrestrianBonusRules(terrestrialBowling);
            terrestrialBowling.Init();
            return terrestrialBowling;
        }

        public static Bowling getMartianBowling()
        {
            Bowling martianBowling = new FlexibleBowling();

            Constraint upToThreeRollsUnlessDropTenEarlier =
                x => ((x.Rolls.Count == 3 && x.Rolls.Sum() <= 10) || (x.Rolls.Count < 3 && x.Rolls.Sum() == 10));
            
            ConstraintAndDesription upToThreeRollsUnlessDropTenEarlierD =
                new ConstraintAndDesription("upToThreeRollsUnlessDropTenEarlier",upToThreeRollsUnlessDropTenEarlier);

            martianBowling.AddConstraintAndDescription(upToThreeRollsUnlessDropTenEarlierD);
            martianBowling.AddConstraintAndDescription(upToThreeRollsUnlessDropTenEarlierD);
            martianBowling.AddConstraintAndDescription(upToThreeRollsUnlessDropTenEarlierD);

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


        private static void SetTerrestrialBowlingConstraints(Bowling terrestrialBowling)
        {
            Constraint sumOfAllRollMustbeLessThanTen = (x => x.Rolls.Sum() <= 10);
            Constraint frameWithStrikeHasOnlyOneRoll = (x => (x.Rolls[0] == 10 && x.Rolls.Count == 1));
            Constraint frameWithNoStrikeHasTwoRolls = (x => (x.Rolls[0] < 10 && x.Rolls.Count == 2));
            Constraint plainFrameConstraint =
                (x =>
                 (sumOfAllRollMustbeLessThanTen(x) &&
                  (frameWithStrikeHasOnlyOneRoll(x) || frameWithNoStrikeHasTwoRolls(x))));

            ConstraintAndDesription plainFrameConstraintD = new ConstraintAndDesription("sum of all roll must be less or equals to ten AND (frame with strike has only one roll OR frame with no strike has two rolls)", plainFrameConstraint);

            for (int i = 0; i < 9; i++)
            {
               terrestrialBowling.AddConstraintAndDescription(plainFrameConstraintD);
            }
            Constraint sumRollsNoHigherThanThirty = x => x.Rolls.Sum() <= 30;
            Constraint ifFirstRollIsTenThanThereIsAtLeastAnotherRoll = x => x.Rolls[0]<10||x.Rolls.Count > 1;

            Constraint noHigherThanThirtyAndAllowMoreRollsIfNoStrike =
                x => (sumRollsNoHigherThanThirty(x) && ifFirstRollIsTenThanThereIsAtLeastAnotherRoll(x));

            ConstraintAndDesription noHigherThanThirtyAndAllowMoreRollsIfNoStrikeD = new ConstraintAndDesription("noHigherThanThirtyAndAllowMoreRollsIfNoStrike", noHigherThanThirtyAndAllowMoreRollsIfNoStrike);

            terrestrialBowling.AddConstraintAndDescription(noHigherThanThirtyAndAllowMoreRollsIfNoStrikeD);

               
        }
    }
}
