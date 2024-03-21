using LexiconGame.Services;
using Moq;

namespace LexiconGame.Tests
{
    public class MapTests
    {
        [Fact]
        public void Constructor_SetCorrectWidth()
        {
            const int expectedWidth = 10;
            const int expectedHeight = 10;

            var mapServiceMoq = new Mock<IMapService>();
            mapServiceMoq.Setup(x => x.GetMap()).Returns((expectedWidth, expectedHeight));

            var map = new Map(mapServiceMoq.Object);

            Assert.Equal(expectedWidth, map.Width);
        }
    }
}