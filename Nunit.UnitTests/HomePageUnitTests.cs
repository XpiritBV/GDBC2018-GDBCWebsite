
using Moq;
using MvcMusicStore.Controllers;
using MvcMusicStore.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using NUnit.Framework;

namespace MsTest.UnitTests
{
    [TestFixture]
    public class HomePageUnitTests
    {
        [Test]
        public void NUnit_TestHomeController_Index()
        {
            Mock<MusicStoreEntities> MusicStoreEntitiesMoq = CreateMockAlbums();
            var controller = new HomeController(MusicStoreEntitiesMoq.Object);
            var result = controller.Index() as ViewResult;
            //expecting defautl view to be returned.
            Assert.IsTrue(result.ViewName == "");

        }

        private static Mock<MusicStoreEntities> CreateMockAlbums()
        {
            var MusicStoreEntitiesMoq = new Mock<MusicStoreEntities>();
            var albums = new List<Album>
            {
                new Album()
            };
           
            var detail = new OrderDetail
            {
                Quantity = 5
            };

            albums[0].OrderDetails = new List<OrderDetail>();
            albums[0].OrderDetails.Add(detail);
            var set = MusicStoreEntitiesMoq.createFakeDBSet<Album>(albums, null, false);

            MusicStoreEntitiesMoq.Setup(m => m.Albums).Returns(set.Object);
            return MusicStoreEntitiesMoq;
        }


    }
}
