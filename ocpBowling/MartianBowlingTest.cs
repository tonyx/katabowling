﻿using System;
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
            martianGame = BowlingFactory.CreateMartianBowling();
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
        [ExpectedException(ExpectedMessage = "up to three rolls unless drop ten earlier|ocpBowling.Constraint ] in frame 1 1",MatchType = MessageMatch.Contains)]
        public void shouldNotAllowLessThanThreeRoll()
        {
            Frame frame = new Frame(1, 1);
            martianGame.AddFrame(frame);
        }

        [Test]
        public void AllowSingleStrickeInAFrame()
        {
            Frame frame = new Frame(10);
            martianGame.AddFrame(frame);
            martianGame.AddFrame(frame);
        }
        [Test]
        public void AllowSingleStrickeInAFrameByRolling()
        {
            martianGame.Roll(10);
            martianGame.Roll(10);
            Assert.AreEqual(2,martianGame.Frames().Count);
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

        [Test]
        public void BounsForAnyStrikeIsTheTotalOfLastFrameByRolling()
        {
            martianGame.Roll(10);

            martianGame.Roll(1);
            martianGame.Roll(1);
            martianGame.Roll(1);
            
            martianGame.Roll(2);
            martianGame.Roll(1);
            martianGame.Roll(1);

            Assert.AreEqual(10 + 3 + 4 + 4, martianGame.Score());
        }



        [Test]
        [ExpectedException]
        public void ShouldNotAcceptMoreFrameIfGameIsOver()
        {
            Frame frame = new Frame(10);
            Frame secondFrame = new Frame(1, 1, 1);
            Frame lastFrame = new Frame(2, 1, 1);
            Frame oneMoreFrame = new Frame(10);
            martianGame.AddFrame(frame);
            martianGame.AddFrame(secondFrame);
            martianGame.AddFrame(lastFrame);
            martianGame.AddFrame(oneMoreFrame);

        }

        [Test]
        [ExpectedException]
        public void ShouldNotAcceptMoreFrameIfGameIsOverByRolling()
        {
            martianGame.Roll(10);

            martianGame.Roll(1);
            martianGame.Roll(1);
            martianGame.Roll(1);
            
            martianGame.Roll(2);
            martianGame.Roll(1);
            martianGame.Roll(1);
            
            martianGame.AddFrame(new Frame(10));;
                       
        }


    }





}
