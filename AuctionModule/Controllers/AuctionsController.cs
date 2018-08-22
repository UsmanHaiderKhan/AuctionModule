using AuctionModule.Models;
using System.Web.Mvc;

namespace AuctionModule.Controllers
{
    public class AuctionsController : Controller
    {
        // GET: Auctions
        public ActionResult Index()
        {

            return View();
        }


        public ActionResult Auction()
        {
            var categoryList = new SelectList(new[] { "Games", "Mobiles", "Movies", "Drinks", "Fabrics" });
            ViewBag.cate = categoryList;
            return View();
        }
        public ActionResult Auction([Bind(Exclude = "CurrentPrice")]Auction auction)
        {
            if (string.IsNullOrWhiteSpace(auction.Title))
            {
                ModelState.AddModelError("Title", "Title Must  be Required");
            }
            else if (auction.Title.Length < 5 || auction.Title.Length > 200)
            {
                ModelState.AddModelError("Title", "Your Title Must be Greater Then 5 and Less then 200 char");
            }

            if (ModelState.IsValid)
            {

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
