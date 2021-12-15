using System.Collections.Generic;
using System.Linq;
using CommonLayer.ViewModels;
using DataLayer.Entities;

namespace BusinessLayer.Mapper
{
    public static class DetailMapper
    {
        public static List<DetailViewModel> ToViewModel(this IList<Detail> orders)
        {
            return orders.Select(x => new DetailViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                VinCode = x.VinCode
            }).ToList();
        }
    }
}
