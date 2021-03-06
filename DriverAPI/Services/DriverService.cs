using DriverEntities.Entities;
using DriverEntities.Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriverAPI.Services
{
    public class DriverService : IDriverService
    {
        private readonly DriverContext _dbContext;

        public DriverService(DriverContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Driver> GetDrivers()
        {
            return _dbContext.Driver.ToList();
        }

        public bool AddDriver(Driver Driver)
        {
            _dbContext.Driver.Add(Driver);
            _dbContext.SaveChanges();
            return true;
        }

        public Driver GetDriverById(int id)
        {
            return _dbContext.Driver.FirstOrDefault(x => x.Id == id);
        }

        public bool UpdateDriver(Driver Driver)
        {
            Driver data = GetDriverById(Driver.Id);
            data.FirstName = Driver.FirstName;
            data.LastName = Driver.LastName;
            data.Mobile = Driver.Mobile;
            _dbContext.SaveChanges();
            return true;
        }

        public bool RemoveDriver(int id)
        {
            Driver data = _dbContext.Driver.FirstOrDefault(x => x.Id == id);
            _dbContext.Driver.Remove(data);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
