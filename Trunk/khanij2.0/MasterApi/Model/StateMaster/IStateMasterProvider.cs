// ***********************************************************************
// Assembly         : Khanij
// Author           : Debaraj Swain
// Created          : 05-Jan-2021
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

namespace MasterApi.Model.StateMaster
{
      public interface IStateMasterProvider: IDisposable, IRepository
    {

        MessageEF AddStateMaster(Statemaster objStatemaster);
        List<Statemaster> ViewStateMaster(Statemaster objStatemaster);
        Statemaster EditStatemaster(Statemaster objStatemaster);
        MessageEF DeleteStatemaster(Statemaster objStatemaster);
        MessageEF UpdateStatemaster(Statemaster objStatemaster);
    }
}
