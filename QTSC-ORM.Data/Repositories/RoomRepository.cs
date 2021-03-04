using System;
using System.Threading.Tasks;
using QTSC_ORM.Data.Entities;
using QTSC_ORM.Data.Repositories.Interfaces;

namespace QTSC_ORM.Data.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DataContext _context;

        public RoomRepository(DataContext context)
        {
            _context = context;
        }

        public void AddRoom(Room room)
        {
            _context.Rooms.Add(room);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
