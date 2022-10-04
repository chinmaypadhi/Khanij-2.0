// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 25-Jan-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using MasterEF;
using System.Collections.Generic;

namespace MasterApp.Areas.Master.Models.Transparncy
{
    public interface ITransparncyModel
    {
        MessageEF Add(Transparncymaster objTransparncyMaster);
        MessageEF Update(Transparncymaster objTransparncyMaster);
        List<Transparncymaster> View(Transparncymaster objTransparncyMaster);
        MessageEF Delete(Transparncymaster objTransparncyMaster);
        Transparncymaster Edit(Transparncymaster objTransparncyMaster);
    }
}
