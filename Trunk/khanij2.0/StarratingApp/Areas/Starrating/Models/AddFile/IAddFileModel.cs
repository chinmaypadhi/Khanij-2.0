// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 30-Apr-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using StarratingEF;
using System.Collections.Generic;

namespace StarratingApp.Areas.Starrating.Models.AddFile
{
    public interface IAddFileModel
    {
        List<AddFilemaster> View(AddFilemaster objAddFilemaster);
        MessageEF Add(AddFilemaster objAddFilemaster);
    }
}
