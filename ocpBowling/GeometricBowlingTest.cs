using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bowlingkata;
using NUnit.Framework;

namespace ocpBowling
{
    [TestFixture]
    class GeometricBowlingTest
    {
        private Bowling geometricBowling;
                
        public bool geoConstraint(Frame frame)
        {
            if (frame.Rolls.Count == 1) {return frame.Rolls[0] != 10;}            
            Frame innerFrame = new Frame(frame.Rolls.GetRange(1, frame.Rolls.Count - 1));
            return frame.Rolls[0]==10&&geoConstraint(innerFrame);
        }
        
        [SetUp]
        public void SetUp()
        {
            geometricBowling = new Bowling();
            Constraint geometricConstraint = x => geoConstraint(x);            
            ConstraintAndDescription frameOver = new ConstraintAndDescription("over", geometricConstraint);
            geometricBowling.SetConstraintForFrame(frameOver,0);
        }

        [Test]      
        public void FrameIsOverForNoTenAtFirstRoll()
        {
            Frame frame = new Frame(9,1);
            Assert.IsFalse(geoConstraint(frame));
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void FrameIsOverIfFirstIsStrikeAndTheSecondNotAndThereIsAnotherRoll()
        {
            Frame frame = new Frame(10, 9,1);
            geometricBowling.AddFrame(frame);
        }


        [Test]
        public void FrameIsOverIfFirstIsNotSTrike()
        {
            Frame frame = new Frame(9);
            geometricBowling.AddFrame(frame);
            Assert.IsTrue(true);
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void IfFirstFrameIsStrikeThenThereShouldBeAnotherRoll()
        {
            Frame frame = new Frame(10);
            geometricBowling.AddFrame(frame);
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void WhileStrikeShoulDContinueNoException()
        {
            Frame frame = new Frame(10,10,10,10);
            geometricBowling.AddFrame(frame);            
        }

        [Test]
        public void ShouldAllowNStrikeAndALastFailure()
        {
            Frame frame = new Frame(10, 10, 10, 10,1);
            geometricBowling.AddFrame(frame);
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void secondFrameIsNotAllowed()
        {
            Frame frame = new Frame(10,1);
            Frame secondFrame = new Frame(9);
            geometricBowling.AddFrame(frame);
            geometricBowling.AddFrame(secondFrame);
        }

        [Test]
        [Ignore]
        public void TheLenOftheFirstFrameMinusOneIsTheTotalNumberOfAllowedFrames()
        {
            Frame frame = new Frame(10,10,10,1);
            Frame furtherFrame = new Frame(9);
            geometricBowling.AddFrame(frame);
            geometricBowling.AddFrame(furtherFrame);
            geometricBowling.AddFrame(furtherFrame);
        }

    }
}
