using AuctionModule.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AuctionModule.Controllers
{
    public class AuctionsController : Controller
    {
        // GET: Auctions
        public ActionResult Index()
        {
            AuctionContext db = new AuctionContext();
            List<Auction> auctions = db.Auctions.ToList();
            return View(auctions);
        }

        public ActionResult FindingBy(long id)
        {
            AuctionContext db = new AuctionContext();
            var auction = db.Auctions.Find(id);
            return View(auction);
        }
        [HttpGet]
        public ActionResult Auction()
        {
            var categoryList = new SelectList(new[] { "Games", "Mobiles", "Movies", "Drinks", "Fabrics" });
            ViewBag.cate = categoryList;
            return View();
        }
        [HttpPost]
        public ActionResult Auction([Bind(Exclude = "CurrentPrice")]Auction auction)
        {
            //if (string.IsNullOrWhiteSpace(auction.Title))
            //{
            //    ModelState.AddModelError("Title", "Title Must  be Required");
            //}
            //else if (auction.Title.Length < 5 || auction.Title.Length > 200)
            //{
            //    ModelState.AddModelError("Title", "Your Title Must be Greater Then 5 and Less then 200 char");
            //}

            if (ModelState.IsValid)
            {
                AuctionContext db = new AuctionContext();
                using (db)
                {
                    db.Auctions.Add(auction);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpPost]
        public ActionResult Bid(Bid bid)
        {
            AuctionContext db = new AuctionContext();

            var auction = db.Auctions.Find(bid.AuctionId);
            if (auction == null)
            {
                ModelState.AddModelError("AuctionId", "Auction Not Found");
            }
            else if (auction.CurrentPrice >= bid.Amount)
            {
                ModelState.AddModelError("Amount", "Bid Amount Less then the current Amount");
            }
            else
            {
                bid.UserName = User.Identity.Name;
                db.Bids.Add(bid);
                auction.CurrentPrice = bid.Amount;
                db.SaveChanges();
            }
            if (!Request.IsAjaxRequest())
                return RedirectToAction("FindingBy", new { id = bid.AuctionId });

            return Json(new
            {
                CurrentPrice = bid.Amount.ToString("C"),
                BidCount = auction.Bidcount
            });


        }
    }
}
