using System;
namespace QTSC_ORM.Data.Models
{
    public class ContractReturn
    {
        public int Id { get; set; }
        public int ContractNo { get; set; }
        public double RentalPrice { get; set; }
        public double ServicePrice { get; set; }
    }
}
