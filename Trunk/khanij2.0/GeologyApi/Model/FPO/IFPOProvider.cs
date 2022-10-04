// ***********************************************************************
//  Interface Name           : IFPOProvider
//  Desciption               : CRUD,Create,Approve,Generate Field Program Order
//  Created By               : Lingaraj Dalai
//  Created On               : 12 Feb 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeologyApi.Repository;
using GeologyEF;

namespace GeologyApi.Model.FPO
{
    public interface IFPOProvider : IDisposable, IRepository
    {
        #region FPO Order
        /// <summary>
        /// To Add Field Program Order Status Details Data in View
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<MessageEF> AddFPOMaster(FPOOrdermaster objFPOMaster);
        /// <summary>
        /// To View Field Program Order Status Details Data in View
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<List<FPOOrdermaster>> ViewFPOMaster(FPOOrdermaster objFPOMaster);
        /// <summary>
        /// To Edit Field Program Order Status Details Data in View
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<FPOOrdermaster> EditFPOMaster(FPOOrdermaster objFPOMaster);
        /// <summary>
        /// To Delete Field Program Order Status Details Data in View
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<MessageEF> DeleteFPOMaster(FPOOrdermaster objFPOMaster);
        /// <summary>
        /// To Update Field Program Order Status Details Data in View
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<MessageEF> UpdateFPOMaster(FPOOrdermaster objFPOMaster);
        /// <summary>
        /// To Bind the Field Season list Details Data in View
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<List<FPOOrdermaster>> GetFieldSeasonList(FPOOrdermaster objFPOMaster);
        #endregion
        #region FPO Creator
        /// <summary>
        /// To Bind the Field Program Order Creator Details Data in View
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<List<FPOOrdermaster>> ViewFPOCreator(FPOOrdermaster objFPOMaster);
        /// <summary>
        /// To Add the Field Program Order Creator Details Data in View
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<MessageEF> AddFPOCreator(FPOOrdermaster objFPOMaster);
        #endregion
        #region FPO Approver
        /// <summary>
        /// To Bind Field Program Order Approver details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<List<FPOOrdermaster>> ViewFPOApprover(FPOOrdermaster objFPOMaster);
        /// <summary>
        /// To Add Field Program Order Approver details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<MessageEF> AddFPOApprover(FPOOrdermaster objFPOMaster);
        #endregion
        #region Generated FPO
        /// <summary>
        /// To View Generated Field Program Order details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<List<FPOOrdermaster>> ViewGeneratedFPO(FPOOrdermaster objFPOMaster);
        #endregion
    }
}
