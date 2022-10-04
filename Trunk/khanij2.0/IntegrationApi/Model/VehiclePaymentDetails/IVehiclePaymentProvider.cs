using IntegrationApi.Repository;
using IntegrationEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationApi.Model.VehiclePaymentDetails
{ 
    public interface IVehiclePaymentProvider : IDisposable, IRepository
    {
        Task<MessageEF> GetVehiclePaymentDetails(VehiclePayment vehiclePayment);
        Task<PaymentModel> GetVehiclePaymentGateway(VehiclePayment vehiclePayment);
        Task<MessageEF> InsertVehiclePaymentRequest(PaymentEF model);
    }
}
