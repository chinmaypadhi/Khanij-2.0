// ***********************************************************************
//  Interface Name           : IFPOModel
//  Desciption               : CRUD,Create,Approve,Generate Field Program Order
//  Created By               : Lingaraj Dalai
//  Created On               : 12 Feb 2021
// ***********************************************************************
using GeologyEF;
using System.Collections.Generic;

namespace GeologyApp.Models.FPO
{
    public interface IFPOModel
    {
        #region FPO Order
        /// <summary>
        /// To Add Field Program Order Status Details Data in View
        /// </summary>
        /// <param name="objFPOmaster"></param>
        /// <returns></returns>
        MessageEF Add(FPOOrdermaster objFPOmaster);
        /// <summary>
        /// To Update Field Program Order Status Details Data in View
        /// </summary>
        /// <param name="objFPOmaster"></param>
        /// <returns></returns>
        MessageEF Update(FPOOrdermaster objFPOmaster);
        /// <summary>
        /// To View Field Program Order Status Details Data in View
        /// </summary>
        /// <param name="objFPOmaster"></param>
        /// <returns></returns>
        List<FPOOrdermaster> View(FPOOrdermaster objFPOmaster);
        /// <summary>
        /// To Delete Field Program Order Status Details Data in View
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        MessageEF Delete(FPOOrdermaster objFPOmaster);
        /// <summary>
        /// To Edit Field Program Order Status Details Data in View
        /// </summary>
        /// <param name="objFPOmaster"></param>
        /// <returns></returns>
        FPOOrdermaster Edit(FPOOrdermaster objFPOmaster);
        /// <summary>
        /// To Bind the Field Season list Details Data in View
        /// </summary>
        /// <param name="objFPOmaster"></param>
        /// <returns></returns>
        List<FPOOrdermaster> GetFieldSeasonList(FPOOrdermaster fieldseasonResult);
        #endregion
        #region FPO Creator
        /// <summary>
        /// To Bind the Field Program Order Creator Details Data in View
        /// </summary>
        /// <param name="objFPOmaster"></param>
        /// <returns></returns>
        MessageEF AddFPOCreator(FPOOrdermaster objFPOmaster);
        /// <summary>
        /// To Add the Field Program Order Creator Details Data in View
        /// </summary>
        /// <param name="objFPOmaster"></param>
        /// <returns></returns>
        List<FPOOrdermaster> ViewFPOCreator(FPOOrdermaster objFPOmaster);
        #endregion
        #region FPO Approver
        /// <summary>
        /// To Bind Field Program Order Approver details data in view
        /// </summary>
        /// <param name="objFPOmaster"></param>
        /// <returns></returns>
        MessageEF AddFPOApprover(FPOOrdermaster objFPOmaster);
        /// <summary>
        /// To Add Field Program Order Approver details data in view
        /// </summary>
        /// <param name="objFPOmaster"></param>
        /// <returns></returns>
        List<FPOOrdermaster> ViewFPOApprover(FPOOrdermaster objFPOmaster);
        #endregion
        #region Generated FPO
        /// <summary>
        /// To View Generated Field Program Order details data in view
        /// </summary>
        /// <param name="objFPOmaster"></param>
        /// <returns></returns>
        List<FPOOrdermaster> ViewGeneratedFPO(FPOOrdermaster objFPOmaster);
        #endregion
    }
}
