using System;
using System.Threading.Tasks;
using QTSC_ORM.Data.Entities;
using QTSC_ORM.Data.Repositories.Interfaces;

namespace QTSC_ORM.Data.Repositories
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly DataContext _context;

        public BuildingRepository(DataContext context)
        {
            _context = context;
        }

        public void AddBuilding(Building building)
        {
            _context.Buildings.Add(building);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
