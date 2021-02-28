using System;
namespace QTSC_ORM.Data.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int No { get; set; }
        public double Square { get; set; }
        public Floor Floor { get; set; }
    }
}
