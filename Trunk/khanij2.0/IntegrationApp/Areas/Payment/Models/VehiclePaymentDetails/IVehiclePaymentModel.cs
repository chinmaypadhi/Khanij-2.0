using IntegrationEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationApp.Areas.Payment.Models.VehiclePaymentDetails
{
    public interface IVehiclePaymentModel
    {
        MessageEF GetVehiclePaymentDetails(VehiclePayment vehiclePayment);
        PaymentModel GetVehiclePaymentGateway(VehiclePayment vehiclePayment);
        MessageEF InsertVehiclePaymentRequest(PaymentEF model);
    }
}
