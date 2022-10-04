using Dapper;
using EstablishmentApi.Factory;
using EstablishmentApi.Repository;
using EstablishmentEf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApi.Model.officeLevel
{
    public class OfficeLevelProvider: RepositoryBase,IOfficeLevelProvider
    {
        public OfficeLevelProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public MessageEF AddUpdateDelete(officeLevelEF officeLevel )
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_Status", officeLevel.Status);
                p.Add("P_IntOfficeTypeId", officeLevel.IntOfficeTypeId);
                p.Add("P_VchOfficeTypeName", officeLevel.VchOfficeTypeName);
                p.Add("P_bitSatus", officeLevel.bitSatus);
                p.Add("P_BitdeletedFlage", officeLevel.BitdeletedFlage);
                p.Add("P_intCreatedBy", officeLevel.intCreatedBy);
                p.Add("P_dateCreatedOn", officeLevel.dateCreatedOn);
                p.Add("P_intUpdatedBy", officeLevel.intCreatedBy);
                p.Add("P_dateUpdatedOn", officeLevel.dateCreatedOn);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USp_M_officeLevel_AddUpdate", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");



                string response = newID.ToString();
                if (response == "1")
                {
                    objMessageEF.Satus = "1";

                }
                else if (response == "2")
                {
                    objMessageEF.Satus = "2";

                }
                else
                {
                    objMessageEF.Satus = "3";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessageEF;
        }
        public List<officeLevelEF> GetOfficeLevel(officeLevelEF officeLevel)
        {
            List<officeLevelEF> ListofficeLevelEF = new List<officeLevelEF>();
            try
            {
                var paramList = new
                {
                    P_Status = "V"

                };


                var result = Connection.Query<officeLevelEF>("USp_M_officeLevel_AddUpdate", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListofficeLevelEF = result.ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return ListofficeLevelEF;



        }
        public officeLevelEF EditOfficeLevel(officeLevelEF officeLevel)
        {
            officeLevelEF objofficeLevelEF = new officeLevelEF();
            try
            {
                var paramList = new
                {
                    P_Status = "E",
                    P_IntOfficeTypeId= officeLevel.IntOfficeTypeId 

                };


                var result = Connection.Query<officeLevelEF>("USp_M_officeLevel_AddUpdate", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    objofficeLevelEF = result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

            }
            return objofficeLevelEF;
        }
    }
}
