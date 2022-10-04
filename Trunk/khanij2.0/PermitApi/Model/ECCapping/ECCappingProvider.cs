using Dapper;



using PermitEF;
using PermitApi.Factory;
using PermitApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace PermitApi.Model.ECCapping
{
    public class ECCappingProvider : RepositoryBase, IECCappingProvider
    {
        public ECCappingProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        //For Stocks
        public async Task<ECCappingEF> GetAllStocks(ECCappingEF objUser)
        {
            ECCappingEF ObjResult = new ECCappingEF();

            List<ECCappingEF> ObjUserTypeList = new List<ECCappingEF>();
            try
            {
                var paramList = new
                {
                    UserId = objUser.UserID,
                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ECCappingEF>("uspGetECCappingMineralGrade", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    foreach (ECCappingEF dr in result)
                    {
                        ObjUserTypeList.Add(new ECCappingEF()
                        {
                            MineralGrade = dr.MineralGrade,
                            MineralGradeId = dr.MineralGradeId,


                        });
                    }
                    ObjResult.AllStockes = ObjUserTypeList;
                }

            }

            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;

        }




        public async Task<ECCappingEF> GetGradeWiseOpeningStockById(ECCappingEF objUser)
        {
            ECCappingEF ObjResult = new ECCappingEF();

            List<ECCappingEF> ObjUserTypeList = new List<ECCappingEF>();
            try
            {
                var paramList = new
                {
                    CreatedBy = objUser.UserID,
                    chk = 7,
                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ECCappingEF>("ECCappingOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    foreach (ECCappingEF dr in result)
                    {
                        ObjUserTypeList.Add(new ECCappingEF()
                        {
                            MineralGrade = dr.MineralGrade,
                            MineralGradeId = dr.MineralGradeId,
                            OpeningStock = dr.OpeningStock,


                        });
                    }
                    ObjResult.AllStockes = ObjUserTypeList;
                }

            }

            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;

        }



        



        // For Year Start
        public async Task<ECCappingEF> GetECCapingFinancialYears()
        {

            ECCappingEF ObjResult = new ECCappingEF();

            List<ECCappingEF> ObjUserTypeList = new List<ECCappingEF>();
            try
            {
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ECCappingEF>("GetFinancialYearListForECCaping", commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (ECCappingEF dr in result)
                    {
                        ObjUserTypeList.Add(new ECCappingEF()
                        {
                            Srno = Convert.ToInt32(dr.Srno),
                            Year = dr.Year,


                        });
                    }
                    ObjResult.CurrentYear = ObjUserTypeList;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }

        // For Year End


        public async Task<MessageEF> AddAllECcappingStocks(ECCappingEF objUser)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("FinancialYear", objUser.FinancialYear);
                p.Add("OpeningStock", objUser.OpeningStock);
                p.Add("UserId", objUser.UserID);
                p.Add("CreatedBy", objUser.UserID);
                p.Add("UserLoginId", objUser.UserLoginId);
                p.Add("MineralGradeID", objUser.MineralGradeId);
                p.Add("BulkInsert", objUser.OpeningStockTable.AsTableValuedParameter());
              
                p.Add("chk", 2);
                var result = await Connection.ExecuteScalarAsync<string>("ECCappingOperation", p, commandType: CommandType.StoredProcedure);
                if (result != null && !string.IsNullOrEmpty(Convert.ToString(result)))
                {
                    objMessage.Satus = result.ToString();

                    if (objMessage.Satus == "1")
                    {

                        objMessage.Msg = "Request to add opening stock into EC capping has been submitted successfully to concerned district office.";


                    }
                    if (objMessage.Satus == "2")
                    {

                        objMessage.Msg = "Record Already Existed! Please Try Again";


                    }

                }
                else
                {
                    objMessage.Satus = "3";
                    objMessage.Msg = " Something Went Wrong!";
                }
                
                   
            }
            catch (Exception ex)
            {
                objMessage.Satus = "-1";
                throw ex;
            }
            return objMessage;
        }


        public async Task<MessageEF> UpdateAllECcappingStocks(ECCappingEF objUser)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("FinancialYear", objUser.FinancialYear);
                p.Add("OpeningStock", objUser.OpeningStock);
                p.Add("UserId", objUser.UserID);
                p.Add("CreatedBy", objUser.UserID);
                p.Add("UserLoginId", objUser.UserLoginId);
                p.Add("MineralGradeID", objUser.MineralGradeId);
                p.Add("BulkInsert", objUser.OpeningStockTable.AsTableValuedParameter());

                p.Add("chk", 7);
                var result = await Connection.ExecuteScalarAsync<string>("ECCappingOperation", p, commandType: CommandType.StoredProcedure);
                if (result != null && !string.IsNullOrEmpty(Convert.ToString(result)))
                {
                    objMessage.Satus = result.ToString();

                    if (objMessage.Satus == "2")
                    {

                        objMessage.Msg = "Request to Update opening stock into EC capping has been Updated successfully to concerned district office.";


                    }
                    if (objMessage.Satus == "1")
                    {

                        objMessage.Msg = "Record Already Existed! Please Try Again";


                    }

                }
                else
                {
                    objMessage.Satus = "3";
                    objMessage.Msg = " Something Went Wrong!";
                }


            }
            catch (Exception ex)
            {
                objMessage.Satus = "-1";
                throw ex;
            }
            return objMessage;
        }


        public async Task<List<ECCappingEF>>GetAllCappingData(ECCappingEF objUser)
        {
            ECCappingEF ObjResult = new ECCappingEF();

            List<ECCappingEF> ObjUserTypeList = new List<ECCappingEF>();
            try
            {
                var p = new DynamicParameters();

                p.Add("chk", 6);
                p.Add("CreatedBy", objUser.UserID);

                var result = await Connection.QueryAsync<ECCappingEF>("ECCappingOperation", p, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjUserTypeList = result.ToList();
                }

            }

            catch (Exception ex)
            {

                throw ex;
            }
            return ObjUserTypeList;

        }




        public async Task<List<ECCappingEF>> GetAllPreviousYearECDetails(ECCappingEF objUser)
        {
            ECCappingEF ObjResult = new ECCappingEF();

            List<ECCappingEF> ObjUserTypeList = new List<ECCappingEF>();
            try
            {
                var p = new DynamicParameters();

                p.Add("chk", 8);
                if (objUser.LesseeID != 0) 
                {
                    p.Add("CreatedBy", objUser.LesseeID); 
                }


                else 
                {
                    p.Add("CreatedBy", objUser.UserID);
                }                

                var result = await Connection.QueryAsync<ECCappingEF>("ECCappingOperation", p, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjUserTypeList = result.ToList();
                }

            }

            catch (Exception ex)
            {

                throw ex;
            }
            return ObjUserTypeList;

        }










       





        public async Task<List<ECCappingEF>> GetAllApprovalData(ECCappingEF objUser)
        {
            ECCappingEF ObjResult = new ECCappingEF();

            List<ECCappingEF> ObjUserTypeList = new List<ECCappingEF>();
            try
            {
                var p = new DynamicParameters();

                p.Add("chk", 3);
                p.Add("UserId", objUser.UserID);
               // p.Add("UserId", 37);

                var result = await Connection.QueryAsync<ECCappingEF>("ECCappingOperation", p, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjUserTypeList = result.ToList();
                }

            }

            catch (Exception ex)
            {

                throw ex;
            }
            return ObjUserTypeList;

        }






        public async Task<MessageEF> SaveApprovalData(ECCappingEF objUser)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("IsApproved", objUser.ActiveStatus);
                p.Add("Remarks", objUser.Remarks);
                p.Add("UserId", objUser.UserID);
                p.Add("ECCappingID", objUser.ECCappingID);

                p.Add("chk", 4);
                var result = await Connection.ExecuteScalarAsync<string>("ECCappingOperation", p, commandType: CommandType.StoredProcedure);
                if (result != null && !string.IsNullOrEmpty(Convert.ToString(result)))
                {
                    objMessage.Satus = result.ToString();

                    if (objMessage.Satus == "1")
                    {

                        objMessage.Msg = "Request to Update opening stock into EC capping has been Updated successfully to concerned district office.";


                    }
                    if (objMessage.Satus == "0")
                    {

                        objMessage.Msg = "Record Already Existed! Please Try Again";


                    }

                }
                else
                {
                    objMessage.Satus = "2";
                    objMessage.Msg = " Something Went Wrong!";
                }


            }
            catch (Exception ex)
            {
                objMessage.Satus = "-1";
                throw ex;
            }
            return objMessage;
        }












       



    }
}
