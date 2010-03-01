using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ocpBowling;

namespace bowlingkata
{
    [TestFixture]
    class MartianBowlingTest
    {
        private Bowling martianGame;
        [SetUp]
        public void Init()
        {
            martianGame = KataGameFactory.getMartianBowling();
        }

        [Test]
        public void testMartialBowlingAllowsThreeRollsInAFrame()
        {
            Frame frame = new Frame(9, 0, 0);
            martianGame.AddFrame(frame);
        }

        [Test]
        public void TestToString()
        {
            Frame frame = new Frame(9,9,1);
            Assert.AreEqual("9 9 1 ",frame.ToString());
        }


        [Test]
        [ExpectedException]
        public void shouldNotAllowLessThanThreeRoll()
        {
            Frame frame = new Frame(1, 1);
            martianGame.AddFrame(frame);
        }

        [Test]
        public void ShouldAllowSingleSlotIfthereIsStrike()
        {
            Frame frame = new Frame(10);
            martianGame.AddFrame(frame);
            martianGame.AddFrame(frame);
        }

        [Test]
        public void ShouldAllowTwoSlotIfScoreIsTen()
        {
            Frame frame = new Frame(1, 9);
            martianGame.AddFrame(frame);
            martianGame.AddFrame(frame);
        }

        [Test]
        public void BounsForAnyStrikeIsTheTotalOfLastFrame()
        {
            Frame frame = new Frame(10);
            Frame secondFrame = new Frame(1, 1, 1);
            Frame lastFrame = new Frame(2, 1, 1);
            martianGame.AddFrame(frame);
            martianGame.AddFrame(secondFrame);
            martianGame.AddFrame(lastFrame);
            Assert.AreEqual(10 + 3 + 4 + 4, martianGame.Score());
        }
    }
}
