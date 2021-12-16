using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Helpers;
using CommonLayer.ViewModels;
using DataLayer.Entities;
using Microsoft.Extensions.Logging;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly ILogger<VehicleService> _logger;
        private readonly VehicleHelper _vehicleHelper;

        public VehicleService(ILogger<VehicleService> logger, VehicleHelper vehicleHelper)
        {
            _logger = logger;
            _vehicleHelper = vehicleHelper;
        }

        public async Task<List<VehicleViewModel>> GetAllVehicles()
        {
            _logger.LogInformation("Getting all users");
            try
            {
                return await _vehicleHelper.GetAll();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }
            return new List<VehicleViewModel>();
        }

        public async Task<List<Vehicle>> GetAllVehicles(User user)
        {
            _logger.LogInformation("Getting all users");
            try
            {
                return await _vehicleHelper.GetAll(user);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }
            return new List<Vehicle>();
        }
    }
}