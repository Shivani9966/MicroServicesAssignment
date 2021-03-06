using RestaurantAPI.Models;
using RestaurantEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Services
{
    public interface IRestaurantService
    {
        IEnumerable<RestaurantResponseModel> GetRestaurants();
        bool AddRestaurant(Restaurant Restaurant);
        Restaurant GetRestaurantById(int id);
        bool UpdateRestaurant(Restaurant Restaurant);
        bool RemoveRestaurant(int id);
    }
}
