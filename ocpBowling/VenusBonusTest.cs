using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bowlingkata;
using NUnit.Framework;

namespace ocpBowling
{
    [TestFixture]
    class VenusBonusTest
    {
        private Bowling venusBowling;
        [SetUp]
        public void SetUp()
        {
//            venusBowling = new Bowling();
//            Constraint ifThereIsNotATenAtFirstRollThenTheFrameIsOver = x => !(x.Rolls[0] != 10) || x.Rolls.Count == 1;
//            ConstraintAndDescription frameOver = new ConstraintAndDescription("over",ifThereIsNotATenAtFirstRollThenTheFrameIsOver);
//            venusBowling.SetConstraintForFrame(frameOver,0);
//            IScoreRuleForFrame venusScoreRule = new PlainScoreRuleForFrame(); 
//            venusBowling.SetBonusRulesForFrame(new List<IBonusRuleForFrame>(){new TerrestrianSpareBonusRule()},0 );
//            venusBowling.SetBonusRulesForFrame(new List<IBonusRuleForFrame>(){new TerrestrianSpareBonusRule()},1 );
//            venusBowling.SetBonusRulesForFrame(new List<IBonusRuleForFrame>(){new TerrestrianSpareBonusRule()},2 );
//            venusBowling.SetScoreForFrame(venusScoreRule,0);
//            venusBowling.SetScoreForFrame(venusScoreRule,1);
//            venusBowling.SetScoreForFrame(venusScoreRule,2);
        }

        [Test]      
        [ExpectedException(typeof(FormatException))]
        public void FrameIsOverForNoTenAtFirstRoll()
        {
//            Frame frame = new Frame(9,1);
//            venusBowling.AddFrame(frame);
        }
    }
}
