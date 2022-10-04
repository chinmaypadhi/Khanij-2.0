using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PermitEF;

namespace PermitApp.Areas.Permit.Models.LTP
{
   public interface ILTPModel
    {
        /// <summary>
        /// Get the details of RTP pass Number
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        List<LTPInfo> GetRTPPassList(LTPInfo objUser);
        /// <summary>
        /// Get the mineral LIst
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        List<LTPInfo> GetCascadeMineral(LTPInfo objUser);
        /// <summary>
        /// Get the mineral Nature List
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        List<LTPInfo> GetMineralNatureList(LTPInfo objUser);
        /// <summary>
        /// Get the mineral Grade list
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        List<LTPInfo> GetMineralGradList(LTPInfo objUser);
        /// <summary>
        /// Bind the dropdown of Railway siding Sourse
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        List<LTPInfo> GetRailwaySiding(LTPInfo objUser);
        /// <summary>
        /// Bind the dropdown of Railway siding Destination
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        List<LTPInfo> GetRailwaySidingDestination(LTPInfo objUser);
        /// <summary>
        /// Get all RTP data
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        List<LTPInfo> GetuserDetailsUsingRTP(LTPInfo objUser);
        /// <summary>
        /// Get all RTP data based on LTP permit number
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        List<LTPInfo> getAddLTPDetails(LTPInfo objUser);
        /// <summary>
        /// Get all RTP data based on user id
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        List<LTPInfo> getLTPDetails(LTPInfo objUser);
        /// <summary>
        /// Save LTP application
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        MessageEF AddLTPApplication(LTPInfo objUser);
        /// <summary>
        /// Download LTP application
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        /// 
        List<ListofLTP> DownloadLTP(ListofLTP objUser);
        /// <summary>
        /// Get Pendig LTP List 
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        /// 
        List<ListofLTP> GetPendigLTPList(ListofLTP objUser);
    }
}
