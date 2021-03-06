using DriverEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriverAPI.Services
{
    public interface IDriverService
    {
        IEnumerable<Driver> GetDrivers();
        bool AddDriver(Driver Driver);
        Driver GetDriverById(int id);
        bool UpdateDriver(Driver Driver);
        bool RemoveDriver(int id);
    }
}
