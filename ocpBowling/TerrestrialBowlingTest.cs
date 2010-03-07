using NUnit.Framework;

namespace ocpBowling
{
    [TestFixture]
    public class TerrestrialBowlingTest
    {
        private Bowling terrestrialGame;
        
        [SetUp]
        public void Init()
        {
            terrestrialGame = BowlingFactory.CreateTerrestrialBowling();                 
        }


        [Test]
        public void TestAllZeroes()
        {
            Frame frame = new Frame(0,0);
            for (int i = 0; i < 10; i++)
            {
                terrestrialGame.AddFrame(frame);
            }
            Assert.AreEqual(0, terrestrialGame.Score());
        }

        [Test]
        public void TestAllZeroesByRolling()
        {
            for (int i=0;i<20;i++)
            {
                terrestrialGame.Roll(0);
                
            }
            Assert.AreEqual(0,terrestrialGame.Score());
        }


        [Test]
        public void TestPlaingGameNoSpareOrStrikes()
        {
            Frame frame = new Frame(1,1);
            for (int i = 0; i < 9; i++)
            {
                terrestrialGame.AddFrame(frame);
            }
            Frame Frame = new Frame(1);
            terrestrialGame.AddFrame(Frame);
            Assert.AreEqual(19, terrestrialGame.Score());
        }
        [Test]
        public void TestPlaingGameNoSpareOrStrikesByRolling()
        {
            for (int i = 0; i < 18;i++ )
            {
                terrestrialGame.Roll(1);
            }
            terrestrialGame.Roll(1);
            Assert.AreEqual(19,terrestrialGame.Score());

        }


        [Test]
        public void TestFirstIsSpare()
        {
            Frame firstFrame = new Frame(1,9); 
            Frame secondFrame = new Frame(1,0);            
            terrestrialGame.AddFrame(firstFrame);
            terrestrialGame.AddFrame(secondFrame);
            Frame emptyFrame = new Frame(0,0);
            for (int i = 2; i < 9;i++ )
            {
                terrestrialGame.AddFrame(emptyFrame);    
            }
            Frame Frame = new Frame(0);
            terrestrialGame.AddFrame(Frame);
            Assert.AreEqual(12, terrestrialGame.Score());
        }
        [Test]
        public void TestFirstIsSpareByRolling()
        {
            terrestrialGame.Roll(1);
            terrestrialGame.Roll(9);
            terrestrialGame.Roll(1);
            terrestrialGame.Roll(0);

            for (int i=4;i<18;i++)
            {
                terrestrialGame.Roll(0);
            }
            terrestrialGame.Roll(0);
            Assert.AreEqual(12,terrestrialGame.Score());
        }


        [Test]
        public void TestFirstIsStricke()
        {
            Frame firstFrame = new Frame(10);
            Frame secondFrame = new Frame(1,1);
            terrestrialGame.AddFrame(firstFrame);
            terrestrialGame.AddFrame(secondFrame);
            Frame emptyFrame = new Frame(0,0);
            for (int i = 2; i < 9;i++ )
            {
                terrestrialGame.AddFrame(emptyFrame);
            }
            Frame Frame = new Frame(0);
            terrestrialGame.AddFrame(Frame);
            Assert.AreEqual(14, terrestrialGame.Score());
        }

        [Test]
        public void TestFirstIsStrickeByRolling()
        {
            terrestrialGame.Roll(10);
            terrestrialGame.Roll(1);
            terrestrialGame.Roll(1);
            for (int i=4;i<18;i++)
            {
                terrestrialGame.Roll(0);
            }
            terrestrialGame.Roll(0);
            Assert.AreEqual(14,terrestrialGame.Score());
        }

        [Test]
        public void TestLastRollGetAnotherRollIfThereIsAstrike()
        {            
            Frame Frame = new Frame(10,1);
            Frame emtpyFrame = new Frame(0,0);
            for (int i = 0; i < 9; i++)
            {
                terrestrialGame.AddFrame(emtpyFrame);
            }
            terrestrialGame.AddFrame(Frame);
            Assert.AreEqual(11, terrestrialGame.Score());
        }
        [Test]
        public void TestLastRollGetAnotherRollIfThereIsAstrikeByRolling()
        {
            for (int i=0;i<18;i++)
            {
                terrestrialGame.Roll(0);
            }
            terrestrialGame.Roll(10);
            terrestrialGame.Roll(1);
            Assert.AreEqual(11, terrestrialGame.Score());
        }




        [Test]
        public void TestLastRollWithNoStrike()
        {
            Frame strike = new Frame(10);
            for (int i = 0; i < 9; i++)
            {
                terrestrialGame.AddFrame(strike);
            }
            Frame lastStrike = new Frame(0);
            terrestrialGame.AddFrame(lastStrike);
            Assert.AreEqual(240, terrestrialGame.Score());            
        }
        [Test]
        public void TestLastRollWithNoStrikeByRolling()
        {
            for (int i=0;i<9;i++)
            {
                terrestrialGame.Roll(10);
            }
            terrestrialGame.Roll(0);
            Assert.AreEqual(240, terrestrialGame.Score());
        }


        [Test]
        public void TestAllStrickeandLastRollIsTen()
        {
            Frame strike = new Frame(10);
            for (int i = 0; i < 9; i++)
            {
                terrestrialGame.AddFrame(strike);
            }
            Frame lastStrike = new Frame(10,0);
            terrestrialGame.AddFrame(lastStrike);
            Assert.AreEqual(270, terrestrialGame.Score());
        }
        [Test]
        public void TestAllStrickeandLastRollIsTenByRolling()
        {
            for (int i=0;i<10;i++)
            {
                terrestrialGame.Roll(10);
            }
            terrestrialGame.Roll(0);
            Assert.AreEqual(270, terrestrialGame.Score());
        }


        [Test]
        public void testStrikeAll()
        {
            Frame strike = new Frame(10);
            for (int i = 0; i < 9; i++)
            {
                terrestrialGame.AddFrame(strike);
            }
            Frame lastStrike = new Frame(10,10,1);
            terrestrialGame.AddFrame(lastStrike);
            Assert.AreEqual(291, terrestrialGame.Score());            
        }

        [Test]
        public void testStrikeAllByRolling()
        {
            for (int i=0;i<9;i++)
            {
                terrestrialGame.Roll(10);
            }
            terrestrialGame.Roll(10);
            terrestrialGame.Roll(10);
            terrestrialGame.Roll(1);            
            Assert.AreEqual(291, terrestrialGame.Score());
        }
        [Test]
        public void testPerfectStrike()
        {
            Frame strike = new Frame(10);
            for (int i = 0; i < 9; i++)
            {
                terrestrialGame.AddFrame(strike);
            }
            Frame lastStrike = new Frame(10,10,10);
            terrestrialGame.AddFrame(lastStrike);
            Assert.AreEqual(300, terrestrialGame.Score());
        }
        [Test]
        public void testPerfectStrikeByRolling()
        {
            for (int i=0;i<12;i++)
            {
                terrestrialGame.Roll(10);
            }
            Assert.AreEqual(300, terrestrialGame.Score());
        }


        [Test]
        public void tenthIsStrikeWhileFollowingNot()
        {
            Frame noPoints = new Frame(0,0);
            for (int i = 0; i < 9; i++)
            {
                terrestrialGame.AddFrame(noPoints);
            }
            Frame Frame = new Frame(10,1);
            terrestrialGame.AddFrame(Frame);
            Assert.AreEqual(11, terrestrialGame.Score());
        }
        [Test]
        public void tenthIsStrikeWhileFollowingNotByRolling()
        {
            for (int i=0;i<18;i++)
            {
                terrestrialGame.Roll(0);
            }
            terrestrialGame.Roll(10);
            terrestrialGame.Roll(1);
            
            Assert.AreEqual(11, terrestrialGame.Score());
        }


        [Test]
        public void tenthIsStrikeAndTheFollowingAlso()
        {
            Frame noPoints = new Frame(0,0);
            for (int i = 0; i < 9; i++)
            {
                terrestrialGame.AddFrame(noPoints);
            }
            Frame Frame = new Frame(10,10,1);
            terrestrialGame.AddFrame(Frame);
            Assert.AreEqual(21, terrestrialGame.Score());
        }
        [Test]
        public void tenthIsStrikeAndTheFollowingAlsoByRolling()
        {
            for (int i=0;i<18;i++)
            {
                terrestrialGame.Roll(0);
            }
            terrestrialGame.Roll(10);
            terrestrialGame.Roll(10);
            terrestrialGame.Roll(1);                        
            Assert.AreEqual(21, terrestrialGame.Score());
        }

        [Test]
        public void TestFirstThreeAreStrikes()
        {
            Frame strike = new Frame(10);
            Frame emptyFrame = new Frame(0,0);
            terrestrialGame.AddFrame(strike);
            terrestrialGame.AddFrame(strike);
            terrestrialGame.AddFrame(strike);
            for (int i = 3; i < 9; i++)
            {
                terrestrialGame.AddFrame(emptyFrame);
            }
            Frame Frame = new Frame(0);
            terrestrialGame.AddFrame(Frame);
            Assert.AreEqual(60, terrestrialGame.Score());
        }
        [Test]
        public void TestFirstThreeAreStrikesByRolling()
        {
            terrestrialGame.Roll(10);
            terrestrialGame.Roll(10);
            terrestrialGame.Roll(10);
            for(int i=6;i<19;i++)
            {
                terrestrialGame.Roll(0);
            }                        
            Assert.AreEqual(60, terrestrialGame.Score());
        }


        [Test]
        public void TestFirstTwoAreStrikes()
        {
            Frame frame = new Frame(10);
            Frame emptyFrame = new Frame(0,0);
            terrestrialGame.AddFrame(frame);
            terrestrialGame.AddFrame(frame);
            for (int i = 2; i < 9; i++)
            {
                terrestrialGame.AddFrame(emptyFrame);
            }
            Frame Frame = new Frame(0);
            terrestrialGame.AddFrame(Frame);

            Assert.AreEqual(30, terrestrialGame.Score());
        }
        [Test]
        public void TestFirstTwoAreStrikesByRolling()
        {
            terrestrialGame.Roll(10);
            terrestrialGame.Roll(10);
            for (int i=4;i<18;i++)
            {
                terrestrialGame.Roll(0);
            }

            Assert.AreEqual(30, terrestrialGame.Score());
        }

        [Test]
        public void TestAllStrickeButLast()
        {
            Frame frame = new Frame(10);
            for (int i = 0; i < 9; i++)
            {
                terrestrialGame.AddFrame(frame);
            }
            Frame Frame = new Frame(0);
            terrestrialGame.AddFrame(Frame);

            Assert.AreEqual(240, terrestrialGame.Score());
        }

        [Test]
        public void TestAllStrickeButLastTen()
        {
            Bowling game = BowlingFactory.CreateTerrestrialBowling();
            Frame frame = new Frame(10);
            for (int i = 0; i < 9; i++)
            {
                game.AddFrame(frame);
            }
            Frame Frame = new Frame(10,0);
            game.AddFrame(Frame);

            Assert.AreEqual(270, game.Score());
        }


        [Test]
        public void TestAllStrickeButLastTwo()
        {
            Frame frame = new Frame(10);
            for (int i = 0; i < 9; i++)
            {
                terrestrialGame.AddFrame(frame);
            }
            Frame Frame = new Frame(10,10,1);
            terrestrialGame.AddFrame(Frame);

            Assert.AreEqual(291, terrestrialGame.Score());
        }

        [Test]
        [ExpectedException(ExpectedMessage = "11", MatchType=MessageMatch.Contains)]
        public void SingleRollInFrameCannotExceedTenHits()
        {
            Frame frame = new Frame(11);
            terrestrialGame.AddFrame(frame);            
        }

        [Test]
        [ExpectedException(ExpectedMessage = "[sum of all roll must be less or equals to ten AND (frame with strike has only one roll OR frame with no strike has two rolls)|ocpBowling.Constraint ] in frame 10 0",MatchType = MessageMatch.Contains)]
        public void TestThereIsNoSecondRollInAStrike()
        {
            Frame frame = new Frame(10,0);
            terrestrialGame.AddFrame(frame);
        }

        [Test]
        [ExpectedException(ExpectedMessage = "violated constraint [sum of all roll must be less or equals to ten", MatchType = MessageMatch.Contains)]
        public void TestThereShouldbeASecondRollIfNotStrike()
        {
            Frame frame = new Frame(9);
            terrestrialGame.AddFrame(frame);
        }

        [Test]
        [Ignore]
        public void RollsInFrame()
        {
            terrestrialGame.Roll(10);
            terrestrialGame.Roll(10);
            Assert.AreEqual(2,terrestrialGame.Frames().Count);
        }

        [Test]
        [Ignore]
        public void Rolls()
        {
            terrestrialGame.Roll(1);
            terrestrialGame.Roll(2);
            Assert.AreEqual(1,terrestrialGame.Frames().Count);
        }
        
    }
}