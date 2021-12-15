using System.Collections.Generic;
using System.Threading.Tasks;
using CommonLayer.ViewModels;

namespace ServiceLayer.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderViewModel>> GetAllOrders();
    }
}