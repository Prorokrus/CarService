using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Helpers;
using CommonLayer.ViewModels;
using Microsoft.Extensions.Logging;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class DetailService : IDetailService
    {
        private readonly ILogger<DetailService> _logger;
        private readonly DetailHelper _detailHelper;

        public DetailService(ILogger<DetailService> logger, DetailHelper detailHelper)
        {
            _logger = logger;
            _detailHelper = detailHelper;
        }


        public async Task<List<DetailViewModel>> GetAllDetails()
        {
            _logger.LogInformation("Getting all base categories");
            try
            {
                return await _detailHelper.GetAll();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }
            return new List<DetailViewModel>();
        }
    }
}