using System;
using System.Collections.Generic;
using System.Linq;

namespace ocpBowling
{
    public static class BowlingFactory
    {
        public static Bowling CreateTerrestrialBowling()
        {
            Bowling terrestrialBowling = new FlexibleBowling();
            SetTerrestrialBowlingConstraints(terrestrialBowling);
            SetTerrestrianBonusRules(terrestrialBowling);
            return terrestrialBowling;
        }

        public static Bowling CreateMartianBowling()
        {
            Bowling martianBowling = new FlexibleBowling();
            SetMartianBowlingFrameConstraints(martianBowling);
            SetMartianBowlingRules(martianBowling);
            return martianBowling;
        }

        private static void SetMartianBowlingRules(Bowling martianBowling)
        {
            martianBowling.SetRulesForFrame(new List<RuleForFrame>{new MartianFrameBonus()},0);
            martianBowling.SetRulesForFrame(new List<RuleForFrame>{new MartianFrameBonus()},1);
            martianBowling.SetRulesForFrame(new List<RuleForFrame>{new MartianFrameNoBonus()},2);
        }

        private static void SetMartianBowlingFrameConstraints(Bowling martianBowling)
        {
            Constraint upToThreeRollsUnlessDropTenEarlier =
                x => ((x.Rolls.Count == 3 && x.Rolls.Sum() <= 10) || (x.Rolls.Count < 3 && x.Rolls.Sum() == 10));
            
            ConstraintAndDesription upToThreeRollsUnlessDropTenEarlierD =
                new ConstraintAndDesription("up to three rolls unless drop ten earlier",upToThreeRollsUnlessDropTenEarlier);

            martianBowling.SetConstraintForFrame(upToThreeRollsUnlessDropTenEarlierD,0);
            martianBowling.SetConstraintForFrame(upToThreeRollsUnlessDropTenEarlierD,1);
            martianBowling.SetConstraintForFrame(upToThreeRollsUnlessDropTenEarlierD,2);
        }


        private static void SetTerrestrianBonusRules(Bowling terrestrialBowling)
        {
            List<RuleForFrame> ruleForPlainFrame = new List<RuleForFrame> { new TerrestrianStrikeRule(), new TerrestrianSpareRule() };
            List<RuleForFrame> rulesForLastFrame = new List<RuleForFrame> { new TerrestrianLastFrameRule() };

            for (int i = 0; i < 9; i++)
            {
                terrestrialBowling.SetRulesForFrame(ruleForPlainFrame,i);
            }
            terrestrialBowling.SetRulesForFrame(rulesForLastFrame,9);
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
                terrestrialBowling.SetConstraintForFrame(plainFrameConstraintD,i);
            }
            Constraint sumRollsNoHigherThanThirty = x => x.Rolls.Sum() <= 30;
            Constraint ifFirstRollIsTenThanThereIsAtLeastAnotherRoll = x => x.Rolls[0]<10||x.Rolls.Count > 1;

            Constraint ifSecondRollIsTenThenThereIsAnotherRoll =
                x => (!(x.Rolls.Count > 1 && x.Rolls[1] == 10) || x.Rolls.Count == 3);

            Constraint noHigherThanThirtyAndAllowMoreRollsIfNoStrike =
                x => (sumRollsNoHigherThanThirty(x) && ifFirstRollIsTenThanThereIsAtLeastAnotherRoll(x)&& ifSecondRollIsTenThenThereIsAnotherRoll(x));

            ConstraintAndDesription noHigherThanThirtyAndAllowMoreRollsIfNoStrikeD = new ConstraintAndDesription("noHigherThanThirtyAndAllowMoreRollsIfNoStrike", noHigherThanThirtyAndAllowMoreRollsIfNoStrike);

            terrestrialBowling.SetConstraintForFrame(noHigherThanThirtyAndAllowMoreRollsIfNoStrikeD,9);
               
        }
    }
}
