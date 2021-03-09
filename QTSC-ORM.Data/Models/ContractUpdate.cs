using System;
namespace QTSC_ORM.Data.Models
{
    public class ContractUpdate
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double RentalPrice { get; set; }
        public double ServicePrice { get; set; }
        public DateTime StartDateRent { get; set; }
        public DateTime StartDateService { get; set; }
    }
}
