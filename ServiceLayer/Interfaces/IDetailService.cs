using System.Collections.Generic;
using System.Threading.Tasks;
using CommonLayer.ViewModels;

namespace ServiceLayer.Interfaces
{
    public interface IDetailService
    {
        Task<List<DetailViewModel>> GetAllDetails();
    }
}