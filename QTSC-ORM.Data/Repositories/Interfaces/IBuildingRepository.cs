using System;
using System.Threading.Tasks;
using QTSC_ORM.Data.Entities;

namespace QTSC_ORM.Data.Repositories.Interfaces
{
    public interface IBuildingRepository
    {
        void AddBuilding(Building building);
        Task<bool> SaveAllAsync();
    }
}
