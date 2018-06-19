
using Moq;
using MvcMusicStore.Controllers;
using MvcMusicStore.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using NUnit.Framework;

namespace MsTest.UnitTests
{
    [TestFixture]
    public class StorePageUnitTest
    {
        [Test]
        public void NUnit_StoreController_Index()
        {

            Mock<MusicStoreEntities> MusicStoreEntitiesMoq = CreateMockGenres();
            var controller = new StoreController(MusicStoreEntitiesMoq.Object);
            var result = controller.Index() as ViewResult;
            //expecting defautl view to be returned.
            Assert.IsTrue(result.ViewName == "");
        }


        [Test]
        public void NUnit_TestStoreController_Browse()
        {
            Mock<MusicStoreEntities> MusicStoreEntitiesMoq = CreateMockGenres();
            var controller = new StoreController(MusicStoreEntitiesMoq.Object);
            var result = controller.Browse("Test") as ViewResult;
            //expecting defautl view to be returned.
            var viewDataType = result.ViewData.Model.GetType();
            Assert.IsTrue(viewDataType == typeof(MvcMusicStore.Models.Genre));
        }

        private Mock<MusicStoreEntities> CreateMockGenres()
        {
            var MusicStoreEntitiesMoq = new Mock<MusicStoreEntities>();
            var genres = new List<Genre>
            {
                new Genre(){Name ="Test"}
            };

            var albums = new List<Album>
            {
                new Album()
            };

            var detail = new OrderDetail
            {
                Quantity = 5
            };

            genres[0].Albums = albums;
            albums[0].OrderDetails = new List<OrderDetail>();
            albums[0].OrderDetails.Add(detail);
            var set = MusicStoreEntitiesMoq.createFakeDBSet<Genre>(genres, null, false);

            MusicStoreEntitiesMoq.Setup(m => m.Genres).Returns(set.Object);
            return MusicStoreEntitiesMoq;

        }
    }
}
