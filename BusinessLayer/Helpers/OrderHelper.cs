using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Mapper;
using CommonLayer.ViewModels;
using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;

namespace BusinessLayer.Helpers
{
    public class OrderHelper
    {
        private readonly IGenericRepository<Order> _orderRepository;

        public OrderHelper(IGenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderViewModel>> GetAll()
        {
            var orders = await _orderRepository.GetAll(x => true);
            return orders.ToViewModel();
        }
    }
}
