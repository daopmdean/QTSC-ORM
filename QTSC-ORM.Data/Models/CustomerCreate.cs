using System;
namespace QTSC_ORM.Data.Models
{
    public class CustomerCreate
    {
        public string TaxCode { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Country { get; set; }
        public string CompanyType { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string BusinessType { get; set; }
        public double RegisterdCapital { get; set; }
        public double InvestedCapital { get; set; }
        public double CharterCapital { get; set; }
    }
}
