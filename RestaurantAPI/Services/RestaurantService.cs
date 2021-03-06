using RestaurantAPI.Models;
using RestaurantEntities.Entities;
using RestaurantEntities.Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly RestaurantContext _dbContext;
        private readonly IMenuService _menuService;

        public RestaurantService(RestaurantContext dbContext, IMenuService menuService)
        {
            _dbContext = dbContext;
            _menuService = menuService;
        }

        public IEnumerable<RestaurantResponseModel> GetRestaurants()
        {
            List<RestaurantResponseModel> restaurantResponses = new List<RestaurantResponseModel>();
            List<Restaurant> restaurants = _dbContext.Restaurant.ToList();
            foreach (var item in restaurants)
            {
                Menu menu = new Menu();
                if (item.MenuId != null)
                {
                    menu = _menuService.GetMenuById(item.MenuId.Value);
                }
                restaurantResponses.Add(new RestaurantResponseModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Location = item.Location,
                    FoodName = menu?.FoodName,
                    Price = menu.Price,
                    Quantity = menu?.Quantity
                });
            }
            return restaurantResponses;
        }

        public bool AddRestaurant(Restaurant Restaurant)
        {
            _dbContext.Restaurant.Add(Restaurant);
            _dbContext.SaveChanges();
            return true;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return _dbContext.Restaurant.FirstOrDefault(x => x.Id == id);
        }

        public bool UpdateRestaurant(Restaurant Restaurant)
        {
            Restaurant data = GetRestaurantById(Restaurant.Id);
            data.Name = Restaurant.Name;
            data.Location = Restaurant.Location;
            data.MenuId = Restaurant.MenuId;
            _dbContext.SaveChanges();
            return true;
        }

        public bool RemoveRestaurant(int id)
        {
            Restaurant data = _dbContext.Restaurant.FirstOrDefault(x => x.Id == id);
            _dbContext.Restaurant.Remove(data);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
