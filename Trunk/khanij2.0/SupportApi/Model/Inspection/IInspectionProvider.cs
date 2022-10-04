// ***********************************************************************
// Assembly         : Khanij
// Author           : Debaraj Swain
// Created          : 4-April-2021
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

namespace SupportApi.Model.Inspection
{
   public interface IInspectionProvider : IDisposable, IRepository
    {
         Result<InspectionModel> GetViewDetails(InspectionModel model);
        Result<FillDDlInspection> ListOfUType(InspectionModel objGR);
        Result<List<NoticeModel>> Getissuranceofnotice(NoticeModel model);
        Result<FillDDlInspection> ListOfUser(InspectionModel objGR);
        Result<InspectionModel> ViewUserDetails(InspectionModel model);
        MessageEF AddInspectionData(InspectionModel objER);
        Result<List<InspectionModel>> ViewInspectionData(InspectionModel model);
        Result<List<InspectionModel>> ViewInspectionDetails(InspectionModel model);
    }
}
