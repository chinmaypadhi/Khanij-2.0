// ***********************************************************************
// Assembly         : Khanij
// Author           : Debaraj Swain
// Created          : 2-March-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using SupportApi.Repository;
using SupportEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportApi.Model.Grievance
{
    public interface IGrievanceProvider: IDisposable, IRepository
    {
        Result<FillDDl> ListOfState(PublicGrievanceModel objGR);
        Result<FillDDl> ListOfDistrict(PublicGrievanceModel objGR);
        MessageEF AddPublicGrievance(PublicGrievanceModel objER);
        Result<FillDDl> ListOfCType(PublicGrievanceModel objGR);
        Result<PublicGrievanceModel> GetOTPProvider(PublicGrievanceModel objER);
        MessageEF AddGrievance(PublicGrievanceModel objER);
        Result<List<PublicGrievanceModel>> GetCListDD(PublicGrievanceModel model);
        Result<PublicGrievanceModel> GetViewDetails(PublicGrievanceModel model);
        Result<PublicGrievanceModel> GetUserData(PublicGrievanceModel objER);
        Result<MessageEF> VerifyOTP(PublicGrievanceModel objER);
        Result<FillDDl> ListOfUserType(PublicGrievanceModel objGR);
        Result<FillDDl> ListOfUserByType(PublicGrievanceModel objGR);
        Result<FillDDl> ListOfCatComp(PublicGrievanceModel objGR);
        MessageEF Forwordtodd(PublicGrievanceModel objER);
        Result<PublicGrievanceModel> CloseComplain(CloseComplain objER);
        Result<List<PublicGrievanceModel>> GetGCList(PublicGrievanceModel model);
        MessageEF AddDGMGrievance(PublicGrievanceModel objER);
        Result<List<PublicGrievanceModel>> GetCListMI(PublicGrievanceModel model);
        MessageEF MIForwordtodd(ForwardMItoDD objER);
        Task<MessageEF> VerifyOTP1(PublicGrievanceModel GrievanceModel);
        Task<MessageEF> GetOTP1(PublicGrievanceModel GrievanceModel);
        Task<MessageEF> CheckMobileNo1(PublicGrievanceModel GrievanceModel);
    }
    
}
