using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Mapper;
using CommonLayer.ViewModels;
using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;

namespace BusinessLayer.Helpers
{
    public class DetailHelper
    {
        private readonly IGenericRepository<Detail> _detailRepository;

        public DetailHelper(IGenericRepository<Detail> detailRepository)
        {
            _detailRepository = detailRepository;
        }

        public async Task<List<DetailViewModel>> GetAll()
        {
            var details = await _detailRepository.GetAll(x => true);
            return details.ToViewModel();
        }
    }
}