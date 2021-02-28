using System;
namespace QTSC_ORM.Data.Entities
{
    public class Deputy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
