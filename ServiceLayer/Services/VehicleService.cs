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
            _logger.LogInformation("Getting all Vehicles");
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
            _logger.LogInformation("Getting all Vehicles");
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

        public async Task<List<VehicleViewModel>> GetAllVehicles(int userId)
        {
            _logger.LogInformation("Getting all Vehicles");

            try
            {
                return await _vehicleHelper.GetAll(userId);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }

            return new List<VehicleViewModel>();
        }

        public async Task AddVehicle(VehicleViewModel model, int userId)
        {
            _logger.LogInformation("Adding new Vehicle");

            try
            {
                await _vehicleHelper.Create(model, userId);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }
        }

        public async Task<VehicleViewModel> GetVehicle(int vehicleId)
        {
            _logger.LogInformation($"Get vehicle with Id: {vehicleId}");

            try
            {
                return await _vehicleHelper.Get(vehicleId);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }

            return new VehicleViewModel();
        }

        public async Task EditVehicle(VehicleViewModel model)
        {
            _logger.LogInformation($"Update vehicle with Id: {model.Id}");

            try
            {
                await _vehicleHelper.Update(model);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }
        }

        public async Task DeleteVehicle(int vehicleId)
        {
            _logger.LogInformation($"Delete vehicle with Id: {vehicleId}");

            try
            {
                await _vehicleHelper.Delete(vehicleId);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }
        }
    }
}