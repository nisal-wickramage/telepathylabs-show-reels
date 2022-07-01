using System;
using Xunit;

namespace TelepathyLabs.ShowReels.Domain.Tests
{
    public class TimeCodeTest
    {
        private const int framesPerSecondForNTSC = 30;
        private const int framesPerSecondForPAL = 25;

        public TimeCodeTest()
        {
        }

        [Fact]
        public void AllParametersShouldBePositive()
        {
            Assert.Throws<Exception>(() => new TimeCode(1, 1, 1, -1, framesPerSecondForPAL));
            Assert.Throws<Exception>(() => new TimeCode(1, 1, -1, 1, framesPerSecondForPAL));
            Assert.Throws<Exception>(() => new TimeCode(1, -1, 1, 1, framesPerSecondForPAL));
            Assert.Throws<Exception>(() => new TimeCode(-1, 1, 1, 1, framesPerSecondForPAL));
        }

        [Fact]
        public void FrameRateShouldBeGreaterThan1()
        {
            Assert.Throws<Exception>(() => new TimeCode(1, 1, 1, 1, 0));
            Assert.Throws<Exception>(() => new TimeCode(1, 1, 1, 1, 1));
        }

        [Fact]
        public void NumberOfFramesShouldBeLessThanFramesPerSecond()
        {
            Assert.Throws<Exception>(() => new TimeCode(1, 1, 1, 30, framesPerSecondForNTSC));
            Assert.True(new TimeCode(1, 1, 1, framesPerSecondForNTSC - 1, framesPerSecondForNTSC) != null);
        }

        [Fact]
        public void TimeCodesWithSameIndividualComponentsShouldBeEqual()
        {
            var timeCode1 = new TimeCode(1, 1, 1, 1, framesPerSecondForNTSC);
            var timeCode2 = new TimeCode(1, 1, 1, 1, framesPerSecondForNTSC);
            var timeCode3 = new TimeCode(2, 1, 1, 1, framesPerSecondForNTSC);

            Assert.True(timeCode1.Equals(timeCode2));
            Assert.False(timeCode1.Equals(timeCode3));
        }

        [Fact]
        public void AddingTwoTimeCodesShouldResultInAdditionOfIndividualComponents()
        {
            var timeCode1 = new TimeCode(1, 1, 1, 1, framesPerSecondForNTSC);
            var timeCode2 = new TimeCode(1, 1, 1, 1, framesPerSecondForNTSC);

            Assert.True(new TimeCode(2, 2, 2, 2, framesPerSecondForNTSC).Equals(timeCode1.Add(timeCode2)));
        }

        [Fact]
        public void AddingTimeCodesWithDifferentFrameRatesShouldFail()
        {
            var timeCode1 = new TimeCode(1, 1, 1, 1, framesPerSecondForNTSC);
            var timeCode2 = new TimeCode(1, 1, 1, 1, framesPerSecondForPAL);

            Assert.Throws<Exception>(() => timeCode1.Add(timeCode2));
        }

        [Fact]
        public void ComparisonOfTwoTimeCodesShouldGiveCorrectHighest()
        {
            var timeCode1 = new TimeCode(1, 1, 1, 1, framesPerSecondForNTSC);
            var timeCode2 = new TimeCode(2, 1, 1, 1, framesPerSecondForNTSC);

            Assert.True(timeCode2 > timeCode1);
            Assert.False(timeCode2 < timeCode1);
        }

        [Fact]
        public void TimecodesWithDifferentFrameRatesShouldFailComparison()
        {
            var timeCode1 = new TimeCode(1, 1, 1, 1, framesPerSecondForPAL);
            var timeCode2 = new TimeCode(2, 1, 1, 1, framesPerSecondForNTSC);

            Assert.Throws<Exception>(() => timeCode1 < timeCode2);
            Assert.Throws<Exception>(() => timeCode2 > timeCode1);
        }
    }
}

