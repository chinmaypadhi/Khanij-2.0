// ***********************************************************************
//  Interface Name           : IPaymentTypeMasterProvider
//  Description              : Add,View,Edit,Update,Delete Payment Type details
//  Created By               : Debaraj Swain
//  Created On               : 08 Jan 2021
// ***********************************************************************
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.PaymentTypeMaster
{
   public interface IPaymentTypeMasterProvider: IDisposable, IRepository
    {
        /// <summary>
        /// Add Payment Type details in view
        /// </summary>
        /// <param name="objPaymentTypeMaster"></param>
        /// <returns></returns>
        MessageEF AddPaymentTypeMaster(PaymenttypeMaster objPaymentTypemaster);
        /// <summary>
        /// View Payment Type details in view
        /// </summary>
        /// <param name="objPaymentTypeMaster"></param>
        /// <returns></returns>
        List<PaymenttypeMaster> ViewPaymentTypeMaster(PaymenttypeMaster objPaymentTypemaste);
        /// <summary>
        /// Edit Payment Type details in view
        /// </summary>
        /// <param name="objPaymentTypeMaster"></param>
        /// <returns></returns>
        PaymenttypeMaster EditPaymentTypemaster(PaymenttypeMaster objPaymentTypemaste);
        /// <summary>
        /// Delete Payment Type details in view
        /// </summary>
        /// <param name="objPaymentTypeMaster"></param>
        /// <returns></returns>
        MessageEF DeletePaymentTypemaster(PaymenttypeMaster objPaymentTypemaste);
        /// <summary>
        /// Update Payment Type details in view
        /// </summary>
        /// <param name="objPaymentTypeMaster"></param>
        /// <returns></returns>
        MessageEF UpdatePaymentTypemaster(PaymenttypeMaster objPaymentTypemaste);
    }
}
