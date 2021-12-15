using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Helpers;
using CommonLayer.ViewModels;
using Microsoft.Extensions.Logging;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly OrderHelper _orderHelper;

        public OrderService(ILogger<OrderService> logger, OrderHelper orderHelper)
        {
            _logger = logger;
            _orderHelper = orderHelper;
        }

        public async Task<List<OrderViewModel>> GetAllOrders()
        {
            _logger.LogInformation("Getting all orders");
            try
            {
                return await _orderHelper.GetAll();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }
            return new List<OrderViewModel>();
        }
    }
}
