using Dapper;
using Microsoft.AspNetCore.Mvc;
using SupportApi.Repository;
using SupportEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SupportApi.Factory;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;


namespace SupportApi.Model.Inspection
{

    public class InspectionProvider : RepositoryBase, IInspectionProvider
    {
        public IConfiguration Configuration { get; }
        public InspectionProvider(IConnectionFactory connectionFactory, IConfiguration configuration) : base(connectionFactory)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// Convert Datareader to Dataset
        /// </summary>
        /// <param name="data"></param>
        /// <returns>DataSet</returns>
        public DataSet ConvertDataReaderToDataSet(IDataReader data)
        {
            DataSet ds = new DataSet();
            int i = 0;
            while (!data.IsClosed)
            {
                ds.Tables.Add("Table" + (i + 1));
                ds.EnforceConstraints = false;
                ds.Tables[i].Load(data);
                i++;
            }
            return ds;
        }
        /// <summary>
        /// Get Inspection Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns>InspectionModel class</returns>
        public Result<InspectionModel> GetViewDetails(InspectionModel model)
        {
            Result<InspectionModel> r = new Result<InspectionModel>();
            
            try
            {


                var paramList = new
                {
                    UserID = model.IntUid,
                    insId = model.insId,

                };
                var result = Connection.ExecuteReader("InspectionReports", paramList, commandType: System.Data.CommandType.StoredProcedure);
                var ds = ConvertDataReaderToDataSet(result);
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    model.inspectorId = Convert.ToInt32(ds.Tables[0].Rows[0]["INSPECTORID"]);
                    model.inspectorCode = Convert.ToString(ds.Tables[0].Rows[0]["INSPECTORCODE"]);
                    model.inspectorName = Convert.ToString(ds.Tables[0].Rows[0]["INSPECTORNAME"]);
                    model.District = Convert.ToString(ds.Tables[0].Rows[0]["DISTRICTNAME"]);
                    model.State = Convert.ToString(ds.Tables[0].Rows[0]["STATENAME"]);
                    model.PinCode = Convert.ToString(ds.Tables[0].Rows[0]["PINCODE"]);
                    model.insMobileNo = Convert.ToString(ds.Tables[0].Rows[0]["MOBILENO"]);
                    model.insEmail = Convert.ToString(ds.Tables[0].Rows[0]["EMAILID"]);
                    model.inspectorDesignation = Convert.ToString(ds.Tables[0].Rows[0]["DESIGNATION"]);
                    if (model.insId > 0)
                    {
                        model.insId = Convert.ToInt32(ds.Tables[0].Rows[0]["insId"]);
                        model.insSubject = Convert.ToString(ds.Tables[0].Rows[0]["insSubject"]);
                        model.insDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["insDate"]).ToString("dd/MM/yyyy");
                        model.IdofLesseeLicensee = Convert.ToInt32(ds.Tables[0].Rows[0]["LesseeLicenseeId"]);
                        model.NameofLesseeLicensee = Convert.ToString(ds.Tables[0].Rows[0]["LLName"]);
                        model.LesseeCode = Convert.ToString(ds.Tables[0].Rows[0]["LLCode"]);
                        model.LesseeLicenseePinCode = Convert.ToString(ds.Tables[0].Rows[0]["LLPincode"]);
                        model.LesseeLicenseeDistrict = Convert.ToString(ds.Tables[0].Rows[0]["LLDistrict"]);
                        model.LesseeLicenseeMobile = Convert.ToString(ds.Tables[0].Rows[0]["LLMobileNo"]);
                        model.LesseeLicenseeEmail = Convert.ToString(ds.Tables[0].Rows[0]["LLEmail"]);
                        model.LesseeLicenseeVillage = Convert.ToString(ds.Tables[0].Rows[0]["LLVillageName"]);
                        model.LesseeLicenseeTehsil = Convert.ToString(ds.Tables[0].Rows[0]["LLTeshilName"]);
                        model.LesseeLicenseePanchayat = Convert.ToString(ds.Tables[0].Rows[0]["LLGramPanchayat"]);
                        model.LesseeLicenseePoliceStation = Convert.ToString(ds.Tables[0].Rows[0]["LLPoliceStation"]);
                        model.LesseeLicenseeUserTypeName = Convert.ToString(ds.Tables[0].Rows[0]["LesseeLicenseeUserTypeName"]);
                        model.Inspection_Report_FILE_NAME = Convert.ToString(ds.Tables[0].Rows[0]["INSfileName"]);
                        model.Panchnama_FILE_NAME = Convert.ToString(ds.Tables[0].Rows[0]["Panchnama_FILE_NAME"]);
                        model.Bayan_FILE_NAME = Convert.ToString(ds.Tables[0].Rows[0]["Bayan_FILE_NAME"]);
                        model.Photos_FILE_NAME = Convert.ToString(ds.Tables[0].Rows[0]["Photos_FILE_NAME"]);
                        model.Others_FILE_NAME = Convert.ToString(ds.Tables[0].Rows[0]["Others_FILE_NAME"]);
                        model.Inspection_Report_FILE_NAME = Convert.ToString(ds.Tables[0].Rows[0]["INSfileName"]);
                        model.Panchnama_FILE_NAME = Convert.ToString(ds.Tables[0].Rows[0]["Panchnama_FILE_NAME"]);
                        model.Bayan_FILE_NAME =  Convert.ToString(ds.Tables[0].Rows[0]["Bayan_FILE_NAME"]);
                        model.Photos_FILE_NAME =  Convert.ToString(ds.Tables[0].Rows[0]["Photos_FILE_NAME"]);
                        model.Others_FILE_NAME =  Convert.ToString(ds.Tables[0].Rows[0]["Others_FILE_NAME"]);

                        if (ds.Tables[1] != null)
                        {
                            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                            {
                                InspectoinReportDetailsDataViewModel details = new InspectoinReportDetailsDataViewModel();
                                details.IssuanceOfNoticeId = Convert.ToInt32(ds.Tables[1].Rows[i]["IssuanceOfNoticeId"]); ;
                                details.IsSatisfied = Convert.ToBoolean(ds.Tables[1].Rows[i]["IsSatisfiedVal"]); ;
                                details.Remarks = Convert.ToString(ds.Tables[1].Rows[i]["Remarks"]); ;
                                details.IssuanceOfNoticeText = Convert.ToString(ds.Tables[1].Rows[i]["IssuanceOfNoticeText"]);
                            }
                        }
                    }
                }

                    r.Data = model;
                    r.Status = true;
                    r.Message = new List<string>() { "Successfull!" };

            }
            catch (Exception ex)
            {
                r.Status = false;
                r.Message.Add("Exception Occured! - " + ex.Message.ToString());
                return r;
               // throw ex;
            }
            //finally
            //{
            //    r.Data = null;
            //    r.Status = false;
            //    r.Message = new List<string>() { "Failed!" };
            //}
            return r;

        }
        /// <summary>
        /// Get List of User Type
        /// </summary>
        /// <param name="objGR"></param>
        /// <returns>FillDDlInspection class</returns>
        public  Result<FillDDlInspection> ListOfUType(InspectionModel objGR)
        {
            FillDDlInspection objres = new FillDDlInspection();
            List<InspectionModel> ListIns = new List<InspectionModel>();
            Result<FillDDlInspection> r = new Result<FillDDlInspection>();


            try
            {
                var paramList = new
                {
                    SP_MODE = "GET_INSPECTION_REPORT_USER_TYPE",

                };

                var result = Connection.Query<InspectionModel>("USP_GET_DROPDOWNLIST", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {


                    foreach (InspectionModel dr in result)
                    {
                        ListIns.Add(new InspectionModel()
                        {
                            TEXT = dr.TEXT,
                            VALUE = dr.VALUE.ToString(),


                        });
                    }
                    objres.DDL = ListIns;
                }

                r.Data = objres;
                r.Status = true;
                r.Message = new List<string>() { "Successfull!" };
                //return objres;
            }
            catch (Exception ex)
            {
                r.Status = false;
                r.Message.Add("Exception Occured! - " + ex.Message.ToString());
                return r;
            }
            //finally
            //{
            //    objres = null;
            //    ListIns = null;
            //}
            return r;
        }
        /// <summary>
        /// Get List of issurance of notice Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns>List of NoticeModel class</returns>
        public Result<List<NoticeModel>> Getissuranceofnotice(NoticeModel model)
        {
            List<NoticeModel> List = new List<NoticeModel>();
            Result<List<NoticeModel>> r = new Result<List<NoticeModel>>();
            try
            {
                var paramList = new
                {
                    UserId = model.IntUserID,
                    TypeId = model.RoleTypeId,
                    ModuleId = 2,
                };
                var result = Connection.ExecuteReader("uspGetNoticeTermsAndCondition", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (var i = 0; i < dt.Rows.Count; i++)
                    {
                        model = new NoticeModel();
                        model.IssuanceOfNoticeText = Convert.ToString(dt.Rows[i]["IssuanceOfNoticeText"]);
                        model.IssuanceOfNoticeId = Convert.ToString(dt.Rows[i]["IssuanceOfNoticeId"]);
                        List.Add(model);
                    }
                }
                if(List.Count>0)
                {
                    r.Data = List;
                    r.Status = true;
                    r.Message = new List<string>() { "Successfull!" };
                }
                else
                {
                    r.Data = null;
                    r.Status = false;
                    r.Message = new List<string>() { "Failed!" };
                }
                        
            }
            catch (Exception ex)
            {
                r.Status = false;
                r.Message.Add("Exception Occured! - " + ex.Message.ToString());
                return r;                
            }
            //finally
            //{
            //    List = null;
            //    model = null;
            //}
            return r;
        }
        /// <summary>
        /// Get List of User
        /// </summary>
        /// <param name="objGR"></param>
        /// <returns>FillDDlInspection class</returns>
        public Result<FillDDlInspection> ListOfUser(InspectionModel objGR)
        {
            FillDDlInspection objres = new FillDDlInspection();
            List<InspectionModel> ListIns = new List<InspectionModel>();
            Result<FillDDlInspection> r = new Result<FillDDlInspection>();
            try
            {
                var paramList = new
                {
                    Check = 2,
                    UserId = objGR.IntUid,
                    UserTypeId = objGR.LesseeLicenseeUserTypeId,
                };
                var result = Connection.Query<InspectionModel>("InspectionReports", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    foreach (InspectionModel dr in result)
                    {
                        ListIns.Add(new InspectionModel()
                        {
                            TEXT = dr.LesseLicenseeName,
                            VALUE = dr.USERID.ToString(),


                        });
                    }
                    objres.DDL = ListIns;
                }

                r.Data = objres;
                r.Status = true;
                r.Message = new List<string>() { "Successfull!" };
               
            }
            catch (Exception ex)
            {
                r.Status = false;
                r.Message.Add("Exception Occured! - " + ex.Message.ToString());
                return r;
            }
            //finally
            //{
            //    objres = null;
            //    ListIns = null;
            //    objGR = null;
            //}

            return r;
        }
        /// <summary>
        /// View User Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns>InspectionModel class</returns>
        public Result<InspectionModel> ViewUserDetails(InspectionModel model)
        {
            Result<InspectionModel> r = new Result<InspectionModel>();
            try
            {
                var paramList = new
                {
                    Check = 3,
                    UserID = model.USERID,
                };
                var result = Connection.ExecuteReader("InspectionReports", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (var i = 0; i < dt.Rows.Count; i++)
                    {
                        model.LesseeLicenseeDistrict = Convert.ToString(dt.Rows[i]["DistrictName"]);
                        model.LesseeLicenseeVillage = Convert.ToString(dt.Rows[i]["VillageName"]);
                        model.LesseeLicenseeTehsil = Convert.ToString(dt.Rows[i]["TehsilName"]);
                        model.LesseeLicenseePanchayat = Convert.ToString(dt.Rows[i]["GRAM_PANCHAYAT"]);
                        model.LesseeLicenseePinCode = Convert.ToString(dt.Rows[i]["Pincode"]);
                        model.LesseeLicenseePoliceStation = Convert.ToString(dt.Rows[i]["POLICE_STATION"]);
                        model.LesseeLicenseeMobile = Convert.ToString(dt.Rows[i]["MobileNo"]);
                        model.LesseeLicenseeEmail = Convert.ToString(dt.Rows[i]["EMailId"]);
                    }
                }

                r.Data = model;
                r.Status = true;
                r.Message = new List<string>() { "Successfull!" };

                return r;

            }
            catch (Exception ex)
            {
                r.Status = false;
                r.Message.Add("Exception Occured! - " + ex.Message.ToString());
                return r;
            }
            //finally
            //{
            //    model = null;
            //}
            return r;
        }
        /// <summary>
        /// Add Inspection Data
        /// </summary>
        /// <param name="objER"></param>
        /// <returns>MessageEF class</returns>
        public MessageEF AddInspectionData(InspectionModel objER)
        {
            MessageEF objMessage = new MessageEF();
            string PathInspectionReport = Convert.ToString(Configuration.GetSection("FilePath").GetSection("PathInspectionReport").Value);
            string PathBayan = Convert.ToString(Configuration.GetSection("FilePath").GetSection("PathBayan").Value);
            string PathOthers = Convert.ToString(Configuration.GetSection("FilePath").GetSection("PathOthers").Value);
            string PathPanchnama = Convert.ToString(Configuration.GetSection("FilePath").GetSection("PathPanchnama").Value);
            string PathPhotos = Convert.ToString(Configuration.GetSection("FilePath").GetSection("PathPhotos").Value);
            try
            {


                //InspectionReport

                if (objER.base64InspectionReport != null)
                {
                    string mystr = objER.base64InspectionReport.Replace("base64,", string.Empty);
                    var testb = Convert.FromBase64String(mystr);
                    using var writer = new BinaryWriter(File.OpenWrite(PathInspectionReport + objER.Inspection_Report_FILE_NAME));
                    writer.Write(testb);
                }
                //Panchaname
                if (objER.base64Panchaname != null)
                {
                    string mystr = objER.base64Panchaname.Replace("base64,", string.Empty);
                    var testb = Convert.FromBase64String(mystr);
                    using var writer = new BinaryWriter(File.OpenWrite(PathPanchnama + objER.Panchnama_FILE_NAME));
                    writer.Write(testb);
                }
                //Bayan
                if (objER.base64Bayan != null)
                {
                    string mystr = objER.base64Bayan.Replace("base64,", string.Empty);
                    var testb = Convert.FromBase64String(mystr);
                    using var writer = new BinaryWriter(File.OpenWrite(PathBayan + objER.Bayan_FILE_NAME));
                    writer.Write(testb);
                }
                //Others

                if (objER.base64Others != null)
                {
                    string mystr = objER.base64Others.Replace("base64,", string.Empty);
                    var testb = Convert.FromBase64String(mystr);
                    using var writer = new BinaryWriter(File.OpenWrite(PathOthers + objER.Others_FILE_NAME));
                    writer.Write(testb);
                }
                //Photos
                if (objER.base64Photos != null)
                {
                    string mystr = objER.base64Photos.Replace("base64,", string.Empty);
                    var testb = Convert.FromBase64String(mystr);
                    using var writer = new BinaryWriter(File.OpenWrite(PathPhotos + objER.Photos_FILE_NAME));
                    writer.Write(testb);
                }

                var p = new DynamicParameters();
                p.Add("Check", 1);
                p.Add("Inspection_Report_FILE_PATH", (objER.base64InspectionReport != null) ? PathInspectionReport+objER.Inspection_Report_FILE_NAME : objER.Inspection_Report_FILE_PATH);
                p.Add("Inspection_Report_FILE_NAME", objER.Inspection_Report_FILE_NAME);
                p.Add("Panchnama_FILE_PATH",(objER.base64Panchaname != null) ? PathPanchnama + objER.Panchnama_FILE_NAME : objER.Panchnama_FILE_PATH);
                p.Add("Panchnama_FILE_NAME", objER.Panchnama_FILE_NAME);
                p.Add("Bayan_FILE_PATH", (objER.base64Bayan != null) ? PathBayan + objER.Bayan_FILE_NAME : objER.Bayan_FILE_PATH);
                p.Add("Bayan_FILE_NAME",  objER.Bayan_FILE_NAME); 
                p.Add("Photos_FILE_PATH", (objER.base64Photos != null) ? PathPhotos  + objER.Photos_FILE_NAME : objER.Photos_FILE_PATH);
                p.Add("Photos_FILE_NAME",  objER.Photos_FILE_NAME);
                p.Add("Others_FILE_PATH",(objER.base64Others != null) ? PathOthers + objER.Others_FILE_NAME : objER.Others_FILE_PATH);
                p.Add("Others_FILE_NAME", objER.Others_FILE_NAME);
                p.Add("insSubject", objER.insSubject);
                p.Add("insDate", DateTime.ParseExact(objER.insDate, "dd-MM-yyyy", CultureInfo.InvariantCulture));
                p.Add("InspectorId", objER.inspectorId);
                p.Add("LesseeLicenseeId", objER.IdofLesseeLicensee);
                p.Add("UserLoginID", objER.USERID);
                p.Add("UserId", objER.USERID);
                p.Add("PinCode", objER.PinCode);
                p.Add("UserTypeId", objER.LesseeLicenseeUserTypeId);
                if (objER.LesseeLicenseeUserTypeId == 8)
                {
                    string json = objER.jsonSerialize;
                    DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);
                    p.Add("InspectionTypeTable", dt, DbType.Object);
                }
                string response = Connection.QueryFirst<string>("InspectionReports", p, commandType: CommandType.StoredProcedure);
                objMessage.Satus = response.ToString();
                return objMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objER = null;
                objMessage = null;
            }
           
        }
        /// <summary>
        /// View Inspection Data
        /// </summary>
        /// <param name="model"></param>
        /// <returns>List InspectionModel class</returns>
        public Result<List<InspectionModel>> ViewInspectionData(InspectionModel model)
        {
            Result<List<InspectionModel>> r = new Result<List<InspectionModel>>();
            List<InspectionModel> objInspection = new List<InspectionModel>();
            try
            {
                var paramList = new
                {
                    UserId = model.IntUid,
                    Check = 4,
                    FromDate1 = model.FromDate,
                    ToDate1 = model.ToDate,
                };


                var result = Connection.ExecuteReader("InspectionReports", paramList, commandType: System.Data.CommandType.StoredProcedure);

                DataTable data = new DataTable();
                data.Load(result);
                if (data.Rows.Count > 0)
                {
                    int sn = 1;
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        model = new InspectionModel();
                        model.SRNO = sn;
                        model.insId = Convert.ToInt32(data.Rows[i]["insId"]);
                        model.insSubject = Convert.ToString(data.Rows[i]["insSubject"]);
                        DateTime x = Convert.ToDateTime(data.Rows[i]["insDate"]);
                        model.InspectionDate = x.ToString("dd-MM-yyyy");
                        model.LesseeLicenseeDistrict = Convert.ToString(data.Rows[i]["DISTRICTNAME"]);
                        model.SubmitedDate = Convert.ToDateTime(data.Rows[i]["SubmitedDate"]);
                        model.inspectorName = Convert.ToString(data.Rows[i]["INSPECTORNAME"]);
                        model.LesseeCode = Convert.ToString(data.Rows[i]["LESSEECODE"]);
                        model.LesseeName = Convert.ToString(data.Rows[i]["LESSEENAME"]);
                        model.Inspection_Report_FILE_NAME = Convert.ToString(data.Rows[i]["Inspection_Report_FILE_NAME"]);
                        model.LesseeLicenseeUserTypeName = Convert.ToString(data.Rows[i]["UserType"]);
                        objInspection.Add(model);
                        sn++;


                    }
                }
                if (objInspection.Count > 0)
                {
                    r.Data = objInspection;
                    r.Status = true;
                    r.Message = new List<string>() { "Successfull!" };
                }
                else
                {
                    r.Data = null;
                    r.Status = false;
                    r.Message = new List<string>() { "Failed!" };
                }
          

            }
            catch (Exception ex)
            {
                r.Status = false;
                r.Message.Add("Exception Occured! - " + ex.Message.ToString());
                return r;
            }
            //finally
            //{

            //    objInspection = null;
            //}
            return r;
        }
        /// <summary>
        /// View Inspection Data
        /// </summary>
        /// <param name="model"></param>
        /// <returns>List InspectionModel class</returns>
        public Result<List<InspectionModel>> ViewInspectionDetails(InspectionModel model)
        {
            List<InspectionModel> objInspection = new List<InspectionModel>();
            Result<List<InspectionModel>> r = new Result<List<InspectionModel>>();
            try
            {
                var paramList = new
                {
                    UserId = model.USERID,
                    Check = 9,
                };


                var result = Connection.ExecuteReader("InspectionReports", paramList, commandType: System.Data.CommandType.StoredProcedure);

                DataTable data = new DataTable();
                data.Load(result);
                if (data.Rows.Count > 0)
                {
                    int sn = 1;
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        model = new InspectionModel();
                       // model.SRNO = sn;
                        model.insId = Convert.ToInt32(data.Rows[i]["insId"]);
                        //model.VALUE = Convert.ToString(data.Rows[i]["VALUE"]);
                        //model.SRNO = Convert.ToInt32(data.Rows[i]["SRNO"]);
                        model.inspectorName = Convert.ToString(data.Rows[i]["inspectorName"]);
                        model.PinCode = Convert.ToString(data.Rows[i]["PinCode"]);
                        model.IdofLesseeLicensee = Convert.ToInt32(data.Rows[i]["IdofLesseeLicensee"]);
                        model.insDate = Convert.ToString(data.Rows[i]["insDate"]);

                        objInspection.Add(model);
                        sn++;


                    }
                }
                r.Data = objInspection;
                r.Status = true;
                r.Message = new List<string>() { "Successfull!" };


            }
            catch (Exception ex)
            {
                r.Status = false;
                r.Message.Add("Exception Occured! - " + ex.Message.ToString());
                return r;
            }
            //finally
            //{

            //    objInspection = null;
            //}
            return r;
        }


        //public FileUpload callApi(FileUpload obj)
        //{
        //    try
        //    {
        //        using (var http = new HttpClient())
        //        {
        //            var data = new FileUpload
        //            {
        //                FileName = "",
        //                FilePath = "",
        //                KeyTotalFile = ""
        //            };




        //            //var content = new StringContent(JsonConvert.SerializeObject(data));
        //            //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        //            //var request = http.PostAsync(_options.Value.NSISPythonUrl, content);
        //            //var response = request.Result.Content.ReadAsStringAsync().Result;
        //            //if (response == null)
        //            //{
        //            //    geo.status = "400";
        //            //    geo.message = "Error Occured!!! Please try again after sometime!!!";
        //            //}
        //            //else
        //            //{
        //            //    geo = JsonConvert.DeserializeObject<GeoServerTifResponse>(response);
        //            //}
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return obj;
        //}

    }
}
