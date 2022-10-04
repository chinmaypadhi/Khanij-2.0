using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;
using userregistrationEFApi.Repository;

namespace userregistrationEFApi.Model.Vhicle
{
    public interface IVehicleRegistrationProvider : IDisposable, IRepository
    {
        
        Task<MessageEF> AddVehicleRegistration(TransporterModel transporterModel); 
        Task<List<TransporterModel>> ViewVehicleRegistration(TransporterModel transporterModel); 
        Task<TransporterModel> EditVehicleRegistration(TransporterModel transporterModel); 
        Task<MessageEF> DeleteVehicleRegistration(TransporterModel transporterModel); 
        Task<MessageEF> UpdateVehicleRegistration(TransporterModel transporterModel); 
        Task<List<TransporterModel>> ViewVehicleState(TransporterModel transporterModel); 
        Task<List<TransporterModel>> ViewVehicleDistrict(TransporterModel transporterModel); 
        Task<MessageEF> GetOTP(TransporterModel transporterModel); 
        Task<List<TransporterModel>> GetSQuestion(TransporterModel transporterModel); 
        Task<MessageEF> VerifyOTP(TransporterModel transporterModel); 
        Task<TransporterModel> GetRecordForReport(TransporterModel transporterModel); 
        Task<MessageEF> CheckMobileNo(TransporterModel transporterModel); 
        Task<TransporterModel> GetUserNamePassword(TransporterModel transporterModel); 
        Task<Result<TransporterModel>> VehicleRegistrationProfile(TransporterModel transporterModel);
        Task<MessageEF> AddVehicleAmountConfiguration(VehicleAmountConfiguration vehicleAmountConfiguration);
        Task<MessageEF> UpdateVehicleAmountConfiguration(VehicleAmountConfiguration vehicleAmountConfiguration);
        Task<VehicleAmountConfiguration> GetVehicleAmountConfiguration(VehicleAmountConfiguration vehicleAmountConfiguration);
       

    }
}
