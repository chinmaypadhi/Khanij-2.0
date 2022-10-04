using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PermitApi.Repository;
using PermitEF;

namespace PermitApi.Model.LTP
{
   public interface ILTPProvider : IDisposable, IRepository
    {
        /// <summary>
        /// Get the details of RTP pass Number
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        Task<List<LTPInfo>> GetRTPPassList(LTPInfo objUser);
        /// <summary>
        /// Get the mineral LIst
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        Task<List<LTPInfo>> GetCascadeMineral(LTPInfo objUser);
        /// <summary>
        /// Get the mineral Nature List
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        Task<List<LTPInfo>> GetMineralNatureList(LTPInfo objUser);
        /// <summary>
        /// Get the mineral Grade list
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        Task<List<LTPInfo>> GetMineralGradList(LTPInfo objUser);
        /// <summary>
        /// Bind the dropdown of Railway siding Sourse
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        Task<List<LTPInfo>> GetRailwaySiding(LTPInfo objUser);
        /// <summary>
        /// Bind the dropdown of Railway siding Destination
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        Task<List<LTPInfo>> GetRailwaySidingDestination(LTPInfo objUser);
        /// <summary>
        /// Get all RTP data based on RTP pass number
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        Task<List<LTPInfo>> GetuserDetailsUsingRTP(LTPInfo objUser);
        /// <summary>
        /// Get all RTP data based on LTP permit number
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        Task<List<LTPInfo>> getAddLTPDetails(LTPInfo objUser);
        /// <summary>
        /// Get all RTP data based on user id
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        Task<List<LTPInfo>> getLTPDetails(LTPInfo objUser);

        /// <summary>
        /// Save LTP application
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        /// 
        Task<MessageEF> AddLTPApplication(LTPInfo objUser);
        /// <summary>
        /// Download LTP application
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        /// 
        Task<List<ListofLTP>> DownloadLTP(ListofLTP objUser);
        /// <summary>
        /// Get Pendig LTP List 
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        /// 
        Task<List<ListofLTP>> GetPendigLTPList(ListofLTP objUser);
    }
}
