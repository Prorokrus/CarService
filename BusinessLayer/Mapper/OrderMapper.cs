using CommonLayer.ViewModels;
using DataLayer.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Mapper
{
    public static class OrderMapper
    {

        public static List<OrderViewModel> ToViewModel(this IList<Order> orders)
        {
            return orders.Select(x => new OrderViewModel
            {
                Id = x.Id,
                Detail = x.Detail,
                ServiceType = x.ServiceType,
                User = x.User,
                Vehicle = x.Vehicle
            }).ToList();
        }
    }
}
