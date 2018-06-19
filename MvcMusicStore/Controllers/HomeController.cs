using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcMusicStore.Models;


namespace MvcMusicStore.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        IMusicStoreEntities storeDB = null;

        public HomeController()
        {
            storeDB = new MusicStoreEntities();
        }

        public HomeController(IMusicStoreEntities entities)
        {
            storeDB = entities;
        }
        public ActionResult Index()
        {
            // Get most popular albums
            var albums = GetTopSellingAlbums(5);
            
            return View(albums);
        }

       

        private List<Album> GetTopSellingAlbums(int count)
        {
            // Group the order details by album and return
            // the albums with the highest count

            return storeDB.Albums
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();
        }
     
    }
    
}