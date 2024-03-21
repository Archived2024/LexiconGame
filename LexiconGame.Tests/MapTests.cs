using Castle.Components.DictionaryAdapter.Xml;
using LexiconGame.Extensions;
using LexiconGame.Services;
using Microsoft.Extensions.Configuration;
using Moq;

namespace LexiconGame.Tests
{
    public class MapTests
    {
        //[Fact]
        //public void Constructor_SetCorrectWidth()
        //{
        //    const int expectedWidth = 10;
        //    const int expectedHeight = 10;

        //    var mapServiceMoq = new Mock<IMapService>();
        //    mapServiceMoq.Setup(x => x.GetMap()).Returns((expectedWidth, expectedHeight));

        //    var map = new Map(mapServiceMoq.Object);

        //    Assert.Equal(expectedWidth, map.Width);
        //}


        //[Fact]
        //public void Constructor_SetCorrectWidth()
        //{
        //    const int expectedWidth = 10;

        //    var iconfigMock = new Mock<IConfiguration>();
        //    var getMapSizeMock = new Mock<IGetMapSize>();

        //    getMapSizeMock.Setup(x => x.GetMapSizeFor(iconfigMock.Object, It.IsAny<string>())).Returns(expectedWidth);
        //    ConfigExtensions.Implementation = getMapSizeMock.Object;

        //    var map = new Map(iconfigMock.Object);

        //    Assert.Equal(expectedWidth, map.Width);
        //}
        
        [Fact]
        public void Constructor_SetCorrectWidth()
        {
            const int expectedWidth = 10;

            var iconfigMock = new Mock<IConfiguration>();

            ConfigExtensions.Implementation = (iconfig, key) => expectedWidth;

            var map = new Map(iconfigMock.Object);

            Assert.Equal(expectedWidth, map.Width);
        }
    }
}