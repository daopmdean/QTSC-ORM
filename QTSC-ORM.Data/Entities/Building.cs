using System;
using System.Collections.Generic;

namespace QTSC_ORM.Data.Entities
{
    public class Building
    {
        public int Id { get; set; }
        public int No { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Address { get; set; }
        public ICollection<Floor> Floors { get; set; }
    }
}
