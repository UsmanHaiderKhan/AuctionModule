using System.Data.Entity;

namespace AuctionModule.Models
{
    public class AuctionContext : DbContext
    {
        public AuctionContext() : base("name=constr")
        {

        }
        public DbSet<Auction> Auctions { get; set; }
    }
}
