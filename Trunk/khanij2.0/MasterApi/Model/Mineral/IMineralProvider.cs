// ***********************************************************************
//  Interface Name           : IMineralProvider
//  Description              : Add,View,Edit,Update,Delete Mineral details
//  Created By               : Akshaya Dalei
//  Created On               : 18 March 2021
// ***********************************************************************

using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.Mineral
{
    public interface IMineralProvider: IDisposable, IRepository
    {
        /// <summary>
        /// Add Mineral Category Details in view
        /// </summary>
        /// <param name="objMineralCategory"></param>
        /// <returns></returns>
        MessageEF AddMineral(MineralCategory objMineralCategory);
        /// <summary>
        /// View Mineral Category Details in view
        /// </summary>
        /// <param name="objMineralCategory"></param>
        /// <returns></returns>
        List<MineralCategory> ViewMineral(MineralCategory objMineralCategory);
        /// <summary>
        /// Edit Mineral Category Details in view
        /// </summary>
        /// <param name="objMineralCategory"></param>
        /// <returns></returns>
        MineralCategory EditMineral(MineralCategory objMineralCategory);
        /// <summary>
        /// Delete Mineral Category Details in view
        /// </summary>
        /// <param name="objMineralCategory"></param>
        /// <returns></returns>
        MessageEF DeleteMineral(MineralCategory objMineralCategory);
        /// <summary>
        /// Update Mineral Category Details in view
        /// </summary>
        /// <param name="objMineralCategory"></param>
        /// <returns></returns>
        MessageEF UpdateMineral(MineralCategory objMineralCategory);
        #region OtherMineral
        /// <summary>
        /// Add Other Mineral Details in view
        /// </summary>
        /// <param name="objOtherMineral"></param>
        /// <returns></returns>
        MessageEF AddOtherMineral(OtherMineralsmaster objOtherMineral);
        /// <summary>
        /// View Other Mineral Details in view
        /// </summary>
        /// <param name="objOtherMineral"></param>
        /// <returns></returns>
        List<OtherMineralsmaster> ViewOtherMineral(OtherMineralsmaster objOtherMineral);
        /// <summary>
        /// Edit Other Mineral Details in view
        /// </summary>
        /// <param name="objOtherMineral"></param>
        /// <returns></returns>
        OtherMineralsmaster EditOtherMineral(OtherMineralsmaster objOtherMineral);
        /// <summary>
        /// Delete Other Mineral Details in view
        /// </summary>
        /// <param name="objOtherMineral"></param>
        /// <returns></returns>
        MessageEF DeleteOtherMineral(OtherMineralsmaster objOtherMineral);
        /// <summary>
        /// Update Other Mineral Details in view
        /// </summary>
        /// <param name="objOtherMineral"></param>
        /// <returns></returns>
        MessageEF UpdateOtherMineral(OtherMineralsmaster objOtherMineral);
        /// <summary>
        /// Get Other Mineral List Details in view
        /// </summary>
        /// <param name="objOtherMineral"></param>
        /// <returns></returns>
        List<OtherMineralsmaster> GetOtherMineralList(OtherMineralsmaster objOtherMineral);
        /// <summary>
        /// Update Publish Status details in view
        /// </summary>
        /// <param name="objOtherMineral"></param>
        /// <returns></returns>
        MessageEF UpdatePublishStatus(OtherMineralsmaster objOtherMineral);
        /// <summary>
        /// Download Other Mineral Details in veiw
        /// </summary>
        /// <param name="objOtherMineral"></param>
        /// <returns></returns>
        OtherMineralsmaster Download_OtherMinerals(OtherMineralsmaster objOtherMineral);
        #endregion
    }
}
