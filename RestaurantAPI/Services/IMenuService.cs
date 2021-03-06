using RestaurantEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Services
{
    public interface IMenuService
    {
        IEnumerable<Menu> GetMenu();
        bool AddMenu(Menu Menu);
        Menu GetMenuById(int id);
        bool UpdateMenu(Menu Menu);
        bool RemoveMenu(int id);
    }
}
