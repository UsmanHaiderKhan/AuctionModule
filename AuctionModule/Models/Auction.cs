using System;
using System.ComponentModel.DataAnnotations;

namespace AuctionModule.Models
{
    public class Auction
    {
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        [Required]
        [DataType(DataType.DateTime)]

        public DateTime StartTime { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }
        [DataType(DataType.Currency)]
        public decimal? CurrentPrice { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal StartPrice { get; set; }

        public string Category { get; set; }


    }
}
