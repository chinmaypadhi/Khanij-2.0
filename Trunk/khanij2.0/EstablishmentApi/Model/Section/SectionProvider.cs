using Dapper;
using EstablishmentApi.Factory;
using EstablishmentApi.Repository;
using EstablishmentEf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApi.Model.Section
{
    public class SectionProvider : RepositoryBase, ISectionProvider
    {
        public SectionProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public MessageEF AddUpdateDelete(SectionEF Section)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("@P_Status", Section.Status);
                p.Add("@P_IntSectionId", Section.IntSectionId);
                p.Add("@P_VchSectionName", Section.VchSectionName);
                p.Add("@P_bitSatus", Section.bitSatus);
                p.Add("@P_BitdeletedFlage", Section.BitdeletedFlage);
                p.Add("@P_intCreatedBy", Section.intCreatedBy);
                p.Add("@P_dateCreatedOn", Section.dateCreatedOn);
                p.Add("@P_intUpdatedBy", Section.intCreatedBy);
                p.Add("@P_dateUpdatedOn", Section.dateCreatedOn);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USp_M_section_AddUpdate", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                string response = newID.ToString();
                if (response == "1")
                {
                    objMessageEF.Satus = "1";

                }
                else if (response == "2")
                {
                    objMessageEF.Satus = "3";

                }
                else
                {
                    objMessageEF.Satus = "2";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessageEF;
        }
        public List<SectionEF> GetOfficeLevel(SectionEF Section)
        {
            List<SectionEF> ListSectionEF = new List<SectionEF>();
            try
            {
                var paramList = new
                {
                    P_Status = "V"

                };


                var result = Connection.Query<SectionEF>("USp_M_section_AddUpdate", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListSectionEF = result.ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return ListSectionEF;



        }
        public SectionEF EditOfficeLevel(SectionEF Section)
        {
            SectionEF objSectionEF = new SectionEF();
            try
            {
                var paramList = new
                {
                    P_Status = "E",
                    P_IntSectionId = Section.IntSectionId

                };


                var result = Connection.Query<SectionEF>("USp_M_section_AddUpdate", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    objSectionEF = result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

            }
            return objSectionEF;
        }

        #region SectionOfficerTagging
        public async Task<List<SectionDropDown>> BindSection(SectionDropDown objLeaveDropDown)
        {
            List<SectionDropDown> listBindState = new List<SectionDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_chk", objLeaveDropDown.Check);
                var output = await Connection.QueryAsync<SectionDropDown>("uspSectionOfficerTagging_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listBindState = output.ToList();
                }
                return listBindState;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<SectionDropDown>> BindSectionOfficer(SectionDropDown objLeaveDropDown)
        {
            List<SectionDropDown> listBindState = new List<SectionDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_chk", objLeaveDropDown.Check);
                var output = await Connection.QueryAsync<SectionDropDown>("uspSectionOfficerTagging_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listBindState = output.ToList();
                }
                return listBindState;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<SectionDropDown>> BindSectionOfficer2(SectionDropDown objLeaveDropDown)
        {
            List<SectionDropDown> listBindState = new List<SectionDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_chk", objLeaveDropDown.Check);
                var output = await Connection.QueryAsync<SectionDropDown>("uspSectionOfficerTagging_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listBindState = output.ToList();
                }
                return listBindState;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF AddSectionOfficerTagging(SectionOfficerTaggingEF objSection)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("@P_Chk", objSection.Check);
                p.Add("@P_intId", objSection.IntId);
                p.Add("@P_IntSectionId", objSection.IntSectionId);
                p.Add("@P_intSectionOfficerId", objSection.intSectionOfficerId);
                p.Add("@P_intSectionOfficerId2", objSection.intSectionOfficerId2);
                p.Add("@P_bitStatus", objSection.bitStatus);
                p.Add("@P_intCreatedBy", objSection.intCreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspSectionOfficerTagging", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                objMessageEF.Satus = newID.ToString();
                //string response = newID.ToString();
                //if (response == "1")
                //{
                //    objMessageEF.Satus = "1";

                //}
                //else if (response == "2")
                //{
                //    objMessageEF.Satus = "3";

                //}
                //else
                //{
                //    objMessageEF.Satus = "2";
                //}
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessageEF;
        }

        public async Task<List<SectionOfficerTaggingQueryEF>> ViewSectionOfficerTagging(SectionOfficerTaggingQueryEF objSectionOfficer)
        {
            List<SectionOfficerTaggingQueryEF> listBindState = new List<SectionOfficerTaggingQueryEF>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_chk", objSectionOfficer.Check);
                var output = await Connection.QueryAsync<SectionOfficerTaggingQueryEF>("uspSectionOfficerTagging_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listBindState = output.ToList();
                }
                return listBindState;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<SectionOfficerTaggingEF> ViewSectionOfficerTaggingDetails(SectionOfficerTaggingEF objSectionOfficer)
        {
            SectionOfficerTaggingEF listBindState = new SectionOfficerTaggingEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_chk", objSectionOfficer.Check);
                p.Add("@P_intId", objSectionOfficer.IntId);
                var output = await Connection.QueryAsync<SectionOfficerTaggingEF>("uspSectionOfficerTagging_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listBindState = output.FirstOrDefault();
                }
                return listBindState;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF DeleteSectionOfficerTagging(SectionOfficerTaggingEF objSection)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("@P_Chk", objSection.Check);
                p.Add("@P_IntId", objSection.IntId);
                p.Add("@P_intCreatedBy", objSection.intCreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspSectionOfficerTagging", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                
                objMessageEF.Satus = newID.ToString();
                //string response = newID.ToString();
                //if (response == "1")
                //{
                //    objMessageEF.Satus = "1";

                //}
                //else if (response == "2")
                //{
                //    objMessageEF.Satus = "3";

                //}
                //else
                //{
                //    objMessageEF.Satus = "2";
                //}
            }
            catch (Exception ex)
            {

                throw ;
            }
            return objMessageEF;
        }

        #endregion
    }
}
