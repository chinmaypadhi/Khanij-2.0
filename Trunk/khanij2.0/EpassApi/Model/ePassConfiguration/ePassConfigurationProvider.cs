using Dapper;
using EpassApi.Factory;
using EpassApi.Repository;
using EpassEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApi.Model.ePassConfiguration
{
    public class ePassConfigurationProvider : RepositoryBase,IePassConfigurationProvider
    {
        public ePassConfigurationProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public async Task<List<ePassConfigurationEF>> GetDistrict(ePassConfigurationEF model)
        {
            List<ePassConfigurationEF> outputResult = new List<ePassConfigurationEF>();
            var p = new DynamicParameters();

            p.Add("@StateId", 7);
            p.Add("@ACTION", 'C');


            var Output = await Connection.QueryAsync<ePassConfigurationEF>("USP_FILL_COMMON_DATA", p, commandType: CommandType.StoredProcedure);
            if (Output.Count() > 0)
            {

                outputResult = Output.ToList();
            }
            return outputResult;
        }
        public async Task<List<ePassConfigurationEF>> GetUserType(ePassConfigurationEF model)
        {
            List<ePassConfigurationEF> outputResult = new List<ePassConfigurationEF>();
            var p = new DynamicParameters();

            p.Add("@ACTION", 'J');


            var Output = await Connection.QueryAsync<ePassConfigurationEF>("USP_FILL_COMMON_DATA", p, commandType: CommandType.StoredProcedure);
            if (Output.Count() > 0)
            {

                outputResult = Output.ToList();
            }
            return outputResult;
        }
        public async Task<List<ePassConfigurationEF>> GetMineralType(ePassConfigurationEF model)
        {
            List<ePassConfigurationEF> outputResult = new List<ePassConfigurationEF>();
            var p = new DynamicParameters();

            p.Add("@Chk", '2');


            var Output = await Connection.QueryAsync<ePassConfigurationEF>("Usp_MineralTypeMaster", p, commandType: CommandType.StoredProcedure);
            if (Output.Count() > 0)
            {

                outputResult = Output.ToList();
            }
            return outputResult;
        }
        public async Task<List<ePassConfigurationEF>> GetUserName(ePassConfigurationEF model)
        {
            List<ePassConfigurationEF> outputResult = new List<ePassConfigurationEF>();
            var p = new DynamicParameters();

            p.Add("@ACTION", 'K');
            p.Add("@DistrictId", model.DistrictID);
            p.Add("@UserTypeId", model.UserTypeID);


            var Output = await Connection.QueryAsync<ePassConfigurationEF>("USP_FILL_COMMON_DATA", p, commandType: CommandType.StoredProcedure);
            if (Output.Count() > 0)
            {

                outputResult = Output.ToList();
            }
            return outputResult;
        }
        public async Task<List<ePassConfigurationEF>> GetMineralName(ePassConfigurationEF model)
        {
            List<ePassConfigurationEF> outputResult = new List<ePassConfigurationEF>();
            var p = new DynamicParameters();

            p.Add("@ACTION", 'L');
            p.Add("@MineralTypeId", model.MineralTypeID);
            p.Add("@UserTypeId", model.UserTypeID);
            p.Add("@UserId", model.Userid);


            var Output = await Connection.QueryAsync<ePassConfigurationEF>("USP_FILL_COMMON_DATA", p, commandType: CommandType.StoredProcedure);
            if (Output.Count() > 0)
            {

                outputResult = Output.ToList();
            }
            return outputResult;
        }
        public async Task<List<ePassConfigurationEF>> GetTransportationMode(ePassConfigurationEF objePassConfigurationModel)
        {
            List<ePassConfigurationEF> outputResult = new List<ePassConfigurationEF>();
            var p = new DynamicParameters();

            p.Add("@ACTION", 'M');


            var Output = await Connection.QueryAsync<ePassConfigurationEF>("USP_FILL_COMMON_DATA", p, commandType: CommandType.StoredProcedure);
            if (Output.Count() > 0)
            {

                outputResult = Output.ToList();
            }
            return outputResult;
        }
        public async Task<List<ePassConfigurationEF>> GetAllowConsignee(ePassConfigurationEF objePassConfigurationModel)
        {
            List<ePassConfigurationEF> outputResult = new List<ePassConfigurationEF>();
            var p = new DynamicParameters();

            p.Add("@ACTION", 'N');


            var Output = await Connection.QueryAsync<ePassConfigurationEF>("USP_FILL_COMMON_DATA", p, commandType: CommandType.StoredProcedure);
            if (Output.Count() > 0)
            {

                outputResult = Output.ToList();
            }
            return outputResult;
        }
        public MessageEF AddEpassConfiguration(ePassConfigurationEF obj)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                
                p.Add("@operation", 1);
                   p.Add("@DistrictId" ,obj.DistrictID);
                p.Add("@UserTypeId" ,obj.UserTypeID);
                p.Add("@UserId" ,obj.Userid);
                p.Add("@MineralTypeId" ,obj.MineralTypeID);
                p.Add("@MineralId" ,obj.MineralID);
                p.Add("@TransportationModeId" ,obj.hdnmi);
                p.Add("@AllowConsigneeTypeid" ,obj.AllowConsigneeTypeid);
                p.Add("@RouteID" ,obj.RouteFetchID);
                p.Add("@TripCloseStatus" ,obj.TripCloseID);
                p.Add("@Time" ,obj.Time);
                p.Add("@PassConfigType", obj.PassConfigTypeID);
                p.Add("@CreatedBy" ,obj.CreatedBy);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);



                var result = Connection.Query<string>("uspEpassConfigurationOperation", p, commandType: System.Data.CommandType.StoredProcedure);
                int response = p.Get<int>("Result");
                if (response.ToString() == "1")
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

        #region Update Data
        public MessageEF UpdateEpassConfiguration(ePassConfigurationEF obj)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();

                p.Add("@operation", 2);
                p.Add("@Configid", obj.id);
                p.Add("@DistrictId", obj.DistrictID);
                p.Add("@UserTypeId", obj.UserTypeID);
                p.Add("@UserId", obj.Userid);
                p.Add("@MineralTypeId", obj.MineralTypeID);
                p.Add("@MineralId", obj.MineralID);
                //p.Add("@TransportationModeId", obj.TransportationModeId);
                p.Add("@TransportationModeId", obj.hdnmi);
                p.Add("@AllowConsigneeTypeid", obj.AllowConsigneeTypeid);
                p.Add("@RouteID", obj.RouteFetchID);
                p.Add("@TripCloseStatus", obj.TripCloseID);
                p.Add("@Time", obj.Time);
                p.Add("@CreatedBy", obj.CreatedBy);
                p.Add("@PassConfigType", obj.PassConfigTypeID);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);



                var result = Connection.Query<string>("uspEpassConfigurationOperation", p, commandType: System.Data.CommandType.StoredProcedure);
                int response = p.Get<int>("Result");
                if (response.ToString() == "1")
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
        #endregion

        #region Delete Data
        public MessageEF DeleteEpassConfiguration(ePassConfigurationEF obj)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();

                p.Add("@operation", 3);
                p.Add("@Configid", obj.id);
                p.Add("@CreatedBy", obj.CreatedBy);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);



                var result = Connection.Query<string>("uspEpassConfigurationOperation", p, commandType: System.Data.CommandType.StoredProcedure);
                int response = p.Get<int>("Result");
                if (response.ToString() == "1")
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
        #endregion

        #region View
        public async Task<List<ePassConfigurationEF>> ViewEpassConfiguration(ePassConfigurationEF objePassConfigurationModel)
        {
            List<ePassConfigurationEF> outputResult = new List<ePassConfigurationEF>();
            var p = new DynamicParameters();

            p.Add("@operation", '4');
           

            

            var Output = await Connection.QueryAsync<ePassConfigurationEF>("uspEpassConfigurationOperation", p, commandType: CommandType.StoredProcedure);
            if (Output.Count() > 0)
            {

                outputResult = Output.ToList();
            }
            return outputResult;
        }
        #endregion
        #region View
        public ePassConfigurationEF EditViewConfig(ePassConfigurationEF objePassConfigurationModel)
        {
            ePassConfigurationEF outputResult = new ePassConfigurationEF();
            var p = new DynamicParameters();

            p.Add("@operation", '5');
            p.Add("@Configid", objePassConfigurationModel.id);
            var Output =  Connection.Query<ePassConfigurationEF>("uspEpassConfigurationOperation", p, commandType: CommandType.StoredProcedure);
            if (Output.Count() > 0)
            {

                outputResult = Output.FirstOrDefault();
            }
            return outputResult;
        }
        #endregion
    }
}
