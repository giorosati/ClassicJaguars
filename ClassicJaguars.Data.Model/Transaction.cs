using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicJaguars.Data.Model
{
    public class Transaction
    {
        [Required]
        public int TransactionId { get; set; }

        //[ForeignKey("ModelId")]
        public int ModelId { get; set; }

        // Track what user added a transaction
        public string UserId { get; set; }

        public virtual Car Car { get; set; }

        public string TransType { get; set; }

        public int SalePrice { get; set; }

        public DateTime? DateSold { get; set; }

        public string SellerName { get; set; }

        public string SellerCountry { get; set; }

        public string BuyerName { get; set; }

        public string BuyerCountry { get; set; }

        public int CarYear { get; set; }

        public string ExtColor { get; set; }

        public string IntColor { get; set; }

        public int CarMiles { get; set; }

        public bool? NumsMatch { get; set; }

        public string Notes { get; set; }
        public DateTime? DateDeleted { get; set; }
    };

    //public enum TransType
    //{
    //    Auction,
    //    Dealer,
    //    Private,
    //    Other
    //};
}