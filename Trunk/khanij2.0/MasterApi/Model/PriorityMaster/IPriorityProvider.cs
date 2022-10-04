// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 15-Jan-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.PriorityMaster
{
    public interface IPriorityProvider: IDisposable, IRepository
    {
        MessageEF AddPriorityMaster(Prioritymaster objPrioritymaster);
        List<Prioritymaster> ViewPriorityMaster(Prioritymaster objPrioritymaster);
        Prioritymaster EditPriorityMaster(Prioritymaster objPrioritymaster);
        MessageEF DeletePriorityMaster(Prioritymaster objPrioritymaster);
        MessageEF UpdatePriorityMaster(Prioritymaster objPrioritymaster);
    }
}
