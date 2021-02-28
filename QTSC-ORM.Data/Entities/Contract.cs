using System;
namespace QTSC_ORM.Data.Entities
{
    public class Contract
    {
        public int Id { get; set; }
        public int ContractNo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Square { get; set; }
        public double RentalPrice { get; set; }
        public double ServicePrice { get; set; }
        public DateTime StartDateRent { get; set; }
        public DateTime StartDateService { get; set; }
        public string Status { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
