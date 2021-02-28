using System;
using System.Collections.Generic;

namespace QTSC_ORM.Data.Entities
{
    public class Floor
    {
        public int Id { get; set; }
        public int No { get; set; }
        public int BuildingId { get; set; }
        public Building Building { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
