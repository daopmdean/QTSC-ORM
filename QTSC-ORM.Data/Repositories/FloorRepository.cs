using System;
using System.Threading.Tasks;
using QTSC_ORM.Data.Entities;
using QTSC_ORM.Data.Repositories.Interfaces;

namespace QTSC_ORM.Data.Repositories
{
    public class FloorRepository : IFloorRepository
    {
        private readonly DataContext _context;

        public FloorRepository(DataContext context)
        {
            _context = context;
        }

        public void AddFloor(Floor floor)
        {
            _context.Floors.Add(floor);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
