using System;
using System.Threading.Tasks;
using QTSC_ORM.Data.Entities;

namespace QTSC_ORM.Data.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        void AddRoom(Room room);
        Task<bool> SaveAllAsync();
    }
}
