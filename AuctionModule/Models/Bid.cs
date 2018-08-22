using System;
using System.ComponentModel.DataAnnotations;

namespace AuctionModule.Models
{
    public class Bid
    {
        public long Id { get; set; }
        public long AuctionId { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; }

        public string UserName { get; set; }
        [Range(1, double.MaxValue)]
        public decimal Amount { get; set; }

        public Bid()
        {
            TimeStamp = DateTime.Now;
        }


    }
}
