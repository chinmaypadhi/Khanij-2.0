// ***********************************************************************
//  Class Name               : MineralProvider
//  Description              : Add,View,Edit,Update,Delete Mineral details
//  Created By               : Akshaya Dalei
//  Created On               : 18 March 2021
// ***********************************************************************
using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.Mineral
{
    public class MineralProvider: RepositoryBase, IMineralProvider 
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public MineralProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Mineral Category Details in view
        /// </summary>
        /// <param name="objMineralCategory"></param>
        /// <returns></returns>
        public MessageEF AddMineral(MineralCategory objMineralCategory)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                object[] objArray = new object[] {
                        "MineralTypeID",objMineralCategory.MineralTypeID,
                        "MineralType"  ,objMineralCategory.MineralType,
                        "CreatedBy"    ,objMineralCategory.CreatedBy,                       
                        "IsActive"     ,objMineralCategory.IsActive,                        
                        "UserLoginId"  ,objMineralCategory.UserLoginId,
                        "Chk",1
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("Result");
                var result = Connection.Query<string>("Usp_MineralTypeMaster", _param, commandType: System.Data.CommandType.StoredProcedure);
                string response = _param.Get<string>("Result");
                if(response=="1")
                {
                    objMessage.Satus = "1";

                }
                else
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// View Mineral Category Details in view
        /// </summary>
        /// <param name="objMineralCategory"></param>
        /// <returns></returns>
        public List<MineralCategory> ViewMineral(MineralCategory objMineralCategory)
        {

            List<MineralCategory> ListMineralCategory = new List<MineralCategory>();

           
            try
            {
                var paramList = new
                {
                    objMineralCategory.MineralType ,
                    Chk = "2",
                    
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<MineralCategory>("Usp_MineralTypeMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListMineralCategory = result.ToList();
                }

                return ListMineralCategory;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListMineralCategory = null;
            }


            
        }
        /// <summary>
        /// Edit Mineral Category Details in view
        /// </summary>
        /// <param name="objMineralCategory"></param>
        /// <returns></returns>
        public MineralCategory EditMineral(MineralCategory objMineralCategory)
        {
            MineralCategory LobjMineralCategory = new MineralCategory();


            try
            {
                var paramList = new
                {
                    MineralTypeID = objMineralCategory.MineralTypeID,
                    Chk = "4",

                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<MineralCategory>("Usp_MineralTypeMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    LobjMineralCategory = result. FirstOrDefault();
                }

                return LobjMineralCategory;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                LobjMineralCategory = null;
            }
        }
        /// <summary>
        /// Delete Mineral Category Details in view
        /// </summary>
        /// <param name="objMineralCategory"></param>
        /// <returns></returns>
        public MessageEF UpdateMineral(MineralCategory objMineralCategory)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                object[] objArray = new object[] {
                        "MineralTypeID",objMineralCategory.MineralTypeID,
                        "MineralType"  ,objMineralCategory.MineralType,                        
                        "ModifiedBy"   ,objMineralCategory.CreatedBy,
                        "IsActive"     ,objMineralCategory.IsActive,
                        "UserLoginId"  ,objMineralCategory.UserLoginId,
                        "Chk",6
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("Result");
                var result = Connection.Query<string>("Usp_MineralTypeMaster", _param, commandType: System.Data.CommandType.StoredProcedure);
                string response = _param.Get<string>("Result");
                if (response == "1")
                {
                    objMessage.Satus = "1";

                }
                else
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Update Mineral Category Details in view
        /// </summary>
        /// <param name="objMineralCategory"></param>
        /// <returns></returns>
        public MessageEF DeleteMineral(MineralCategory objMineralCategory)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                object[] objArray = new object[] {
                        "MineralTypeID",objMineralCategory.MineralTypeID,
                        "ModifiedBy"   ,objMineralCategory.CreatedBy,
                        "UserLoginId"  ,objMineralCategory.UserLoginId,
                        "Chk",5
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("Result");
                var result = Connection.Query<string>("Usp_MineralTypeMaster", _param, commandType: System.Data.CommandType.StoredProcedure);
                string response = _param.Get<string>("Result");
                if (response == "1")
                {
                    objMessage.Satus = "1";

                }
                else
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;

        }
        #region OtherMineral
        /// <summary>
        /// Add Other Mineral Details in view
        /// </summary>
        /// <param name="objOtherMineral"></param>
        /// <returns></returns>
        public MessageEF AddOtherMineral(OtherMineralsmaster objOtherMineral)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("OtherMineralId", objOtherMineral.OtherMineralId);
                p.Add("MineralId", objOtherMineral.MineralId);
                p.Add("Fector1", objOtherMineral.Fector1.ToString());
                //p.Add("Fector2", objOtherMineral.Fector2);
                p.Add("EffectiveFromDate", objOtherMineral.EffectiveFromDate);
                p.Add("UserId", objOtherMineral.UserId);
                p.Add("UserLoginId", objOtherMineral.UserLoginId);
                p.Add("chk", "INSERT");              
                string response = Connection.QueryFirst<string>("OtherMineralsOperation", p, commandType: CommandType.StoredProcedure);
                if (response == "1")
                {
                    objMessage.Satus = "1";

                }
                else if (response == "2")
                {
                    objMessage.Satus = "3";

                }
                else
                {
                    objMessage.Satus = "2";
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// View Other Mineral Details in view
        /// </summary>
        /// <param name="objOtherMineral"></param>
        /// <returns></returns>
        public List<OtherMineralsmaster> ViewOtherMineral(OtherMineralsmaster objOtherMineral)
        {
            List<OtherMineralsmaster> ListOtherMineralmaster = new List<OtherMineralsmaster>();
            try
            {
                var paramList = new
                {
                    objOtherMineral.OtherMineralId,
                    chk = "SELECT",
                };
                var result = Connection.Query<OtherMineralsmaster>("OtherMineralsOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListOtherMineralmaster = result.ToList();
                }

                return ListOtherMineralmaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListOtherMineralmaster = null;
            }



        }
        /// <summary>
        /// Edit Other Mineral Details in view
        /// </summary>
        /// <param name="objOtherMineral"></param>
        /// <returns></returns>
        public OtherMineralsmaster EditOtherMineral(OtherMineralsmaster objOtherMineral)
        {
            OtherMineralsmaster LobjOtherMineralmaster = new OtherMineralsmaster();
            try
            {
                var paramList = new
                {
                    objOtherMineral.OtherMineralId,
                    chk = "SELECT",

                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<OtherMineralsmaster>("OtherMineralsOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    LobjOtherMineralmaster = result.FirstOrDefault();
                }

                return LobjOtherMineralmaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                LobjOtherMineralmaster = null;
            }
        }
        /// <summary>
        /// Delete Other Mineral Details in view
        /// </summary>
        /// <param name="objOtherMineral"></param>
        /// <returns></returns>
        public MessageEF DeleteOtherMineral(OtherMineralsmaster objOtherMineral)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("OtherMineralId", objOtherMineral.OtherMineralId);
                p.Add("chk", "DELETE");
                string response = Connection.QueryFirst<string>("OtherMineralsOperation", p, commandType: CommandType.StoredProcedure);
                if (response == "1")
                {
                    objMessage.Satus = "1";
                }
                else
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Update Other Mineral Details in view
        /// </summary>
        /// <param name="objOtherMineral"></param>
        /// <returns></returns>
        public MessageEF UpdateOtherMineral(OtherMineralsmaster objOtherMineral)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("OtherMineralId", objOtherMineral.OtherMineralId);
                p.Add("MineralId", objOtherMineral.MineralId);
                p.Add("Fector1", objOtherMineral.Fector1);
                //p.Add("Fector2", objOtherMineral.Fector2);
                p.Add("EffectiveFromDate", objOtherMineral.EffectiveFromDate);
                p.Add("UserId", objOtherMineral.UserId);
                p.Add("UserLoginId", objOtherMineral.UserLoginId);
                p.Add("chk", "UPDATE");
                string response = Connection.QueryFirst<string>("OtherMineralsOperation", p, commandType: CommandType.StoredProcedure);
                if (response == "1")
                {
                    objMessage.Satus = "2";

                }
                else if (response == "2")
                {
                    objMessage.Satus = "3";
                }
                else
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;

        }
        /// <summary>
        /// Get Other Mineral List Details in view
        /// </summary>
        /// <param name="objOtherMineral"></param>
        /// <returns></returns>
        public List<OtherMineralsmaster> GetOtherMineralList(OtherMineralsmaster objOtherMineral)
        {
            List<OtherMineralsmaster> ObjOtherMineralList = new List<OtherMineralsmaster>();
            try
            {
                var paramList = new
                {
                    chk = "GET_MINERAL"
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<OtherMineralsmaster>("OtherMineralsOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ObjOtherMineralList = result.ToList();
                }

                return ObjOtherMineralList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Update Publish Status details in view
        /// </summary>
        /// <param name="objOtherMineral"></param>
        /// <returns></returns>
        public MessageEF UpdatePublishStatus(OtherMineralsmaster objOtherMineral)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@OtherMineralId", objOtherMineral.OtherMineralId);
                p.Add("@EffectiveFromDate", objOtherMineral.EffectiveFromDate);
                p.Add("@UserId", objOtherMineral.UserId);
                p.Add("@UserLoginId", objOtherMineral.UserLoginId);
                p.Add("@chk", "PUBLISH");
                string response = Connection.QueryFirst<string>("OtherMineralsOperation", p, commandType: CommandType.StoredProcedure);
                if (response == "1")
                {
                    objMessage.Satus = "1";

                }
                else if (response == "2")
                {
                    objMessage.Satus = "3";
                }
                else
                {
                    objMessage.Satus = "2";
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Download Other Mineral Details in veiw
        /// </summary>
        /// <param name="objOtherMineral"></param>
        /// <returns></returns>
        public OtherMineralsmaster Download_OtherMinerals(OtherMineralsmaster objOtherMineral)
        {
            OtherMineralsmaster ObjOtherMineralList = new OtherMineralsmaster();
            try
            {
                var paramList = new
                {
                    OtherMineralId = objOtherMineral.OtherMineralId,
                    UserId = objOtherMineral.UserId,
                    chk = "SELECT"
                };
                var Output = Connection.Query<OtherMineralsmaster>("OtherMineralsOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjOtherMineralList = Output.FirstOrDefault();
                }
                return ObjOtherMineralList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ObjOtherMineralList = null;
            }         
        }
        #endregion
    }
}
