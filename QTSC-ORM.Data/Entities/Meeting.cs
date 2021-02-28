using System;
namespace QTSC_ORM.Data.Entities
{
    public class Meeting
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
