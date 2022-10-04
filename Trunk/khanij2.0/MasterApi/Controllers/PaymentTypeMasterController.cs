// ***********************************************************************
//  Controller Name          : PaymentTypeMasterController
//  Description              : Add,View,Edit,Update,Delete Payment Type details
//  Created By               : Debaraj Swain
//  Created On               : 08 Jan 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.PaymentTypeMaster;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class PaymentTypeMasterController : ControllerBase
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        public IPaymentTypeMasterProvider _objIIPaymentTypeMasterProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objPaymentTypeMasterProvider"></param>
        public PaymentTypeMasterController(IPaymentTypeMasterProvider objPaymentTypeMasterProvider)
        {
            _objIIPaymentTypeMasterProvider = objPaymentTypeMasterProvider;
        }
        /// <summary>
        /// Add Payment Type details in view
        /// </summary>
        /// <param name="objPaymentTypeMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(PaymenttypeMaster objPaymentTypeMaster)
        {
            return _objIIPaymentTypeMasterProvider.AddPaymentTypeMaster(objPaymentTypeMaster);
        }
        /// <summary>
        /// View Payment Type details in view
        /// </summary>
        /// <param name="objPaymentTypeMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<PaymenttypeMaster> View(PaymenttypeMaster objPaymentTypeMaster)
        {
            return _objIIPaymentTypeMasterProvider.ViewPaymentTypeMaster(objPaymentTypeMaster);
        }
        /// <summary>
        /// Edit Payment Type details in view
        /// </summary>
        /// <param name="objPaymentTypeMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public PaymenttypeMaster Edit(PaymenttypeMaster objPaymentTypeMaster)
        {
            return _objIIPaymentTypeMasterProvider.EditPaymentTypemaster(objPaymentTypeMaster);
        }
        /// <summary>
        /// Delete Payment Type details in view
        /// </summary>
        /// <param name="objPaymentTypeMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(PaymenttypeMaster objPaymentTypeMaster)
        {
            return _objIIPaymentTypeMasterProvider.DeletePaymentTypemaster(objPaymentTypeMaster);
        }
        /// <summary>
        /// Update Payment Type details in view
        /// </summary>
        /// <param name="objPaymentTypeMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(PaymenttypeMaster objPaymentTypeMaster)
        {
            return _objIIPaymentTypeMasterProvider.UpdatePaymentTypemaster(objPaymentTypeMaster);
        }
        [HttpPost]
        public string test()
        {
            return "test";
        }

    }
}
