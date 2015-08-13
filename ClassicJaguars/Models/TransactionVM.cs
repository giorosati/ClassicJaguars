using ClassicJaguars.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassicJaguars.Models
{
    public class TransactionVM
    {
        public int TransactionId { get; set; }
        public int ModelID { get; set; }
        public virtual Car Car { get; set; }
        public string TransType { get; set; }
        public int SalePrice { get; set; }
        public DateTime DateSold { get; set; }
        public string SellerName { get; set; }
        public string SellerCountry { get; set; }
        public string BuyerName { get; set; }
        public string BuyerCountry { get; set; }
        public int CarYear { get; set; }
        public string ExtColor { get; set; }
        public string IntColor { get; set; }
        public int CarMiles { get; set; }
        public bool NumsMatch { get; set; }
        public string Notes { get; set; }
        public DateTime? DateDeleted { get; set; }
    };
}