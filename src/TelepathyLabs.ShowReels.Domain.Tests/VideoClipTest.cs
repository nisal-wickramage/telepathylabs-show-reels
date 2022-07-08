using System;
using Xunit;

namespace TelepathyLabs.ShowReels.Domain.Tests
{
    public class VideoClipTest
    {
        private const int framesPerSecondForNTSC = 30;
        private const int framesPerSecondForPAL = 25;

        public VideoClipTest()
        {
        }

        // name, description, video standard, video definition start time code end time code should be not null or empty
        // start time code < end time code
        [Fact]
        public void AllConstructorParametersShouldNotBeNullOrWhiteSpace()
        {
            Assert.Throws<ShowReelsException>(() => new VideoClip(
                "Test001",
                "Test 001 description",
                VideoStandard.PAL,
                VideoDefinition.HD,
                new TimeCode(1, 1, 1, 1, framesPerSecondForNTSC),
                null));

            Assert.Throws<ShowReelsException>(() => new VideoClip(
                "Test001",
                "Test 001 description",
                VideoStandard.PAL,
                VideoDefinition.HD,
                null,
                new TimeCode(1, 1, 1, 1, framesPerSecondForNTSC)));

            Assert.Throws<ShowReelsException>(() => new VideoClip(
                "Test001",
                null,
                VideoStandard.PAL,
                VideoDefinition.HD,
                new TimeCode(1, 1, 1, 1, framesPerSecondForNTSC),
                new TimeCode(2, 1, 1, 1, framesPerSecondForNTSC)));

            Assert.Throws<ShowReelsException>(() => new VideoClip(
                null,
                "Test 001 description",
                VideoStandard.PAL,
                VideoDefinition.HD,
                new TimeCode(1, 1, 1, 1, framesPerSecondForNTSC),
                new TimeCode(2, 1, 1, 1, framesPerSecondForNTSC)));

            Assert.True(new VideoClip(
                "Test001",
                "Test 001 description",
                VideoStandard.PAL,
                VideoDefinition.HD,
                new TimeCode(1, 1, 1, 1, framesPerSecondForNTSC),
                new TimeCode(2, 1, 1, 1, framesPerSecondForNTSC)) != null);
        }

        [Fact]
        public void EndTimeCodeShouldBeGreaterThanStartTimeCode()
        {
            Assert.Throws<ShowReelsException>(() => new VideoClip(
                "Test001",
                "Test 001 description",
                VideoStandard.PAL,
                VideoDefinition.HD,
                new TimeCode(2, 1, 1, 1, framesPerSecondForNTSC),
                new TimeCode(1, 1, 1, 1, framesPerSecondForNTSC)));
        }

        [Fact]
        public void StartTimeCodeAndEndTimeCodeShouldHaveSameFramesPerSecond()
        {
            Assert.Throws<ShowReelsException>(() => new VideoClip(
                "Test001",
                "Test 001 description",
                VideoStandard.PAL,
                VideoDefinition.HD,
                new TimeCode(2, 1, 1, 1, framesPerSecondForNTSC),
                new TimeCode(1, 1, 1, 1, framesPerSecondForPAL)));
        }
    }
}

