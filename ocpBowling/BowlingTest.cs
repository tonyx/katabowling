using NUnit.Framework;

namespace ocpBowling
{
    [TestFixture]
    public class BowlingTest
    {
        private Bowling game;
        
        [SetUp]
        public void Init()
        {
            game = KataGameFactory.getTerrestrialBowling();   
        }

        [Test]
        public void TestAllZeroes()
        {
            Frame frame = new Frame(0, 0);
            for (int i = 0; i < 19; i++)
            {
                game.AddFrame(frame);
            }
            game.AddFrame(new LastFrame(0));
            Assert.AreEqual(0, game.Score());
        }

        [Test]
        public void TestPlaingGameNoSpareOrStrikes()
        {
            Frame frame = new Frame(1, 1);
            for (int i = 0; i < 9; i++)
            {
                game.AddFrame(frame);
            }
            game.AddFrame(new LastFrame(1));
            Assert.AreEqual(19, game.Score());
        }

        [Test]
        public void TestFirstIsSpare()
        {
            Frame firstFrame = new Frame(1, 9);
            Frame secondFrame = new Frame(1, 0);
            game.AddFrame(firstFrame);
            game.AddFrame(secondFrame);
            Frame emptyFrame = new Frame(0, 0);
            for (int i = 2; i < 9;i++ )
            {
                game.AddFrame(emptyFrame);    
            }
            game.AddFrame(new LastFrame(0));

            Assert.AreEqual(12, game.Score());
        }

        [Test]
        public void TestFirstIsStricke()
        {
            Frame firstFrame = new Frame(10);
            Frame secondFrame = new Frame(1, 1);
            game.AddFrame(firstFrame);
            game.AddFrame(secondFrame);
            Frame emptyFrame = new Frame(0,0);
            for (int i = 2; i < 9;i++ )
            {
                game.AddFrame(emptyFrame);
            }
            game.AddFrame(new LastFrame(0));

            Assert.AreEqual(14, game.Score());
        }


        [Test]
        public void TestLastRollGetAnotherRollIfThereIsAstrike()
        {
            Frame lastFrame = new LastFrame(10, 1);
            Frame frame = new Frame(0, 0);
            for (int i = 0; i < 9; i++)
            {
                game.AddFrame(frame);
            }
            game.AddFrame(lastFrame);
            Assert.AreEqual(11, game.Score());
        }


        [Test]
        public void TestLastRollWithNoStrike()
        {
            Frame strike = new Frame(10);
            for (int i = 0; i < 9; i++)
            {
                game.AddFrame(strike);
            }
            Frame lastStrike = new LastFrame(0);
            game.AddFrame(lastStrike);

            Assert.AreEqual(240, game.Score());

        }

        [Test]
        public void TestAllStrickeandLastRollIsTen()
        {
            Frame strike = new Frame(10);
            for (int i = 0; i < 9; i++)
            {
                game.AddFrame(strike);
            }
            Frame lastStrike = new LastFrame(10,0);
            game.AddFrame(lastStrike);

            Assert.AreEqual(270, game.Score());

        }


        [Test]
        public void testStrikeAll()
        {
            Frame strike = new Frame(10);
            for (int i = 0; i < 9; i++)
            {
                game.AddFrame(strike);
            }
            Frame lastStrike = new LastFrame(10,10,10);
            game.AddFrame(lastStrike);

            Assert.AreEqual(300, game.Score());
            
        }



        [Test]
        public void testPerfectStrike()
        {
            Frame strike = new Frame(10);
            for (int i = 0; i < 9; i++)
            {
                game.AddFrame(strike);
            }
            Frame lastStrike = new LastFrame(10, 10, 10);
            game.AddFrame(lastStrike);

            Assert.AreEqual(300, game.Score());

        }

        [Test]
        public void tenthIsStrikeWhileFollowingNot()
        {
            Frame noPoints = new Frame(0, 0);
            for (int i = 0; i < 9; i++)
            {
                game.AddFrame(noPoints);
            }
            Frame lastFrame = new LastFrame(10, 1);
            game.AddFrame(lastFrame);
            Assert.AreEqual(11, game.Score());

        }

        [Test]
        public void tenthIsStrikeAndTheFollowingAlso()
        {
            Frame noPoints = new Frame(0, 0);
            for (int i = 0; i < 9; i++)
            {
                game.AddFrame(noPoints);
            }
            Frame lastFrame = new LastFrame(10, 10, 1);
            game.AddFrame(lastFrame);
            Assert.AreEqual(21, game.Score());
        }

        [Test]
        public void TestFirstThreeAreStrikes()
        {
            Frame frame = new Frame(10);
            Frame emptyFrame = new Frame(0, 0);
            game.AddFrame(frame);
            game.AddFrame(frame);
            game.AddFrame(frame);
            for (int i = 3; i < 9; i++)
            {
                game.AddFrame(emptyFrame);
            }
            game.AddFrame(new LastFrame(0));
            Assert.AreEqual(60, game.Score());
        }

        [Test]
        public void TestFirstThooAreStrikes()
        {
            Frame frame = new Frame(10);
            Frame emptyFrame = new Frame(0, 0);
            game.AddFrame(frame);
            game.AddFrame(frame);
            for (int i = 2; i < 9; i++)
            {
                game.AddFrame(emptyFrame);
            }
            game.AddFrame(new LastFrame(0));

            Assert.AreEqual(30, game.Score());
        }

        [Test]
        public void TestAllStrickeButLast()
        {
            Frame frame = new Frame(10);
            Frame emptyFrame = new Frame(0, 0);
            for (int i = 0; i < 9; i++)
            {
                game.AddFrame(frame);
            }
            game.AddFrame(new LastFrame(0));

            Assert.AreEqual(240, game.Score());
        }

        [Test]
        public void TestAllStrickeButLastTen()
        {
            Bowling game = KataGameFactory.getTerrestrialBowling();
            Frame frame = new Frame(10);
            for (int i = 0; i < 9; i++)
            {
                game.AddFrame(frame);
            }
            game.AddFrame(new LastFrame(10,0));

            Assert.AreEqual(270, game.Score());
        }

        [Test]
        public void TestAllStrickeButLastTwo()
        {
            Frame frame = new Frame(10);
            for (int i = 0; i < 9; i++)
            {
                game.AddFrame(frame);
            }
            game.AddFrame(new LastFrame(10, 10,1));

            Assert.AreEqual(291, game.Score());
        }

//        [Test]
//        public void TestFlexibleFrame()
//        {
//            FlexibleFrame frame = new FlexibleFrame(2);
//            frame.Rolls(2);
//            frame.rolls(1, 1);
//        }

    }
}