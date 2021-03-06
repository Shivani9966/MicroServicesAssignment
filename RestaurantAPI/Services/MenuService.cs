using RestaurantEntities.Entities;
using RestaurantEntities.Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Services
{
    public class MenuService : IMenuService
    {
        private readonly RestaurantContext _dbContext;

        public MenuService(RestaurantContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Menu> GetMenu()
        {
            return _dbContext.Menu.ToList();
        }

        public bool AddMenu(Menu Menu)
        {
            _dbContext.Menu.Add(Menu);
            _dbContext.SaveChanges();
            return true;
        }

        public Menu GetMenuById(int id)
        {
            return _dbContext.Menu.FirstOrDefault(x => x.Id == id);
        }

        public bool UpdateMenu(Menu Menu)
        {
            Menu data = GetMenuById(Menu.Id);
            data.FoodName = Menu.FoodName;
            data.Price = Menu.Price;
            data.Quantity = Menu.Quantity;
            _dbContext.SaveChanges();
            return true;
        }

        public bool RemoveMenu(int id)
        {
            Menu data = _dbContext.Menu.FirstOrDefault(x => x.Id == id);
            _dbContext.Menu.Remove(data);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
