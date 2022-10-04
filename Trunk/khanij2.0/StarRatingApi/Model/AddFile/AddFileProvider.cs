// ***********************************************************************
//  Class Name               : AddFileProvider
//  Desciption               : Add File Starrating Assessment of Lessee 
//  Created By               : Lingaraj Dalai
//  Created On               : 16 April 2021
// ***********************************************************************
using Dapper;
using StarRatingApi.Factory;
using StarRatingApi.Repository;
using StarratingEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;


namespace StarRatingApi.Model.AddFile
{
    public class AddFileProvider: RepositoryBase, IAddFileProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public AddFileProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// View Additioal File Class
        /// </summary>
        /// <param name="objAddFilemaster"></param>
        /// <returns></returns>
        public List<AddFilemaster> ViewAdditionalFile(AddFilemaster objAddFilemaster)
        {
            List<AddFilemaster> ListAssessmentLisMaster = new List<AddFilemaster>();
            try
            {
                var paramList = new
                {
                    AssesmentID = objAddFilemaster.AssesmentID
                };
                var Output = Connection.Query<AddFilemaster>("SP_Get_SR_OtherFile", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (Output.Count() > 0)
                {
                    ListAssessmentLisMaster = Output.ToList();
                }
                return ListAssessmentLisMaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListAssessmentLisMaster = null;
            }
        }
        /// <summary>
        /// Add Additioal File Class
        /// </summary>
        /// <param name="objAddFilemaster"></param>
        /// <returns></returns>
        public MessageEF AddAdditionalFile(AddFilemaster objAddFilemaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters(); var p1 = new DynamicParameters(); var p2 = new DynamicParameters();
                p.Add("OtherID","1");
                p.Add("OtherName", objAddFilemaster.OtherName);
                p.Add("AssesmentID", objAddFilemaster.AssesmentID);
                p.Add("Mode", "1");
                p.Add("OutID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("SP_CRUD_SR_Other_Assesment", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("OutID");

                var InputFileName = Path.GetFileName(objAddFilemaster.FileName);
                var FileType = Path.GetExtension(objAddFilemaster.FileExtension);
                var FDate = DateTime.Now;
                string mFileAdd = "_Other";
                var FileName = FDate.Year + "_" + FDate.Month.ToString("00") + "_" + FDate.Day.ToString("00") + "_" + FDate.Hour + "_" + FDate.Minute + "_" + FDate.Second + "_" + FDate.Millisecond + "_" + objAddFilemaster.AssesmentID + "_" + newID.ToString() + mFileAdd;
                objAddFilemaster.FileName = FileName;
                objAddFilemaster.FileExtension = FileType;
                p1.Add("FileMasterID", "1");
                p1.Add("FileName", objAddFilemaster.FileName);
                p1.Add("FileExtension", objAddFilemaster.FileExtension);
                p1.Add("Mode", "1");
                p1.Add("OutID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("SP_CRUD_SR_FileMaster", p1, commandType: CommandType.StoredProcedure);
                int newID1 = p1.Get<int>("OutID");

                p2.Add("FileMappID", "1");
                p2.Add("FileMasterID", newID1);
                p2.Add("AssesmentID", objAddFilemaster.AssesmentID);
                p2.Add("OtherID", newID);
                p2.Add("Mode", "1");
                p2.Add("OutID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("SP_CRUD_SR_MapFile_Other_Assesment", p2, commandType: CommandType.StoredProcedure);
                int newID2 = p2.Get<int>("OutID");

                string response = newID.ToString();
                string response1 = newID1.ToString();
                string response2 = newID2.ToString();
                if (newID>0 && newID1 > 0 && newID2 > 0)
                {
                    objMessage.Satus = "1";
                    objMessage.Msg = FileName+FileType;
                }
                else if (response == "0" && response1 == "0" && response2 == "0")
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
    }
}
