using Dapper;
using IntegrationApi.Factory;
using IntegrationApi.Repository;
using IntegrationEF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace IntegrationApi.Model.MailService
{
    public class MailProvider : RepositoryBase, IMailProvider
    {
        static string LogoPath = "~/Content/images/colors/magenta/header.jpg";
        static string infiLogoPath = "~/images/infi.png";

        static string SMTP_USERNAME = "";
        static string SMTP_FROM_ALIAS = "";
        static string SMTP_PASSWORD = "";
        static string SMTP_PORT = "";
        static string SMTP_SERVER = "";
        static string EnableSsl = "";

        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IConfiguration configuration;

        public MailProvider(IConnectionFactory connectionFactory, IWebHostEnvironment webHostEnvironment, IConfiguration configuration) : base(connectionFactory)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.configuration = configuration;
        }

        #region License
        public MessageEF SendLicenseApplicationAck(LicenseMail licenseMail)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                string body = SendLicenseAck(licenseMail.EMAILADDRESS, licenseMail.LICENSE_APP_CODE, licenseMail.USERNAME, licenseMail.PASSWORD, licenseMail.APPLICANTNAME, licenseMail.application_tyep);
                //  string body = PaymentAppAcceptOrRejectAckMail(model, DateTime.Now);
                SendMailMessage(licenseMail.UserId, licenseMail.EMAIL_SENT, licenseMail.EMAILADDRESS, "Acknowledgement from Khanij Online System", body);
                messageEF.Satus = "success";
            }
            catch (Exception)
            {
                messageEF.Satus = "failed";
            }
            return messageEF;
        }

        private string SendLicenseAck(string EmailId, string ApplicationNumber, string UserName, string Password, string ApplicantName, string ApplicationFor)
        {
            string body = string.Empty;
            try
            {
                var rootpath = Path.Combine(webHostEnvironment.WebRootPath, "Template/LicenseApplicationTemplate.html");
                using (StreamReader reader = new StreamReader(rootpath))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{TransactionId}", ApplicationNumber);
                body = body.Replace("{ApplicantName}", ApplicantName);
                body = body.Replace("{ApplicationFor}", ApplicationFor);
                body = body.Replace("{UserName}", UserName);
                body = body.Replace("{Password}", Password);
                body = body.Replace("{MailedDateTime}", DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss"));
                body = body.Replace("{LogoPath}", LogoPath);
                body = body.Replace("{infiLogoPath}", infiLogoPath);
            }
            catch (Exception)
            {
            }
            return body;
        }

        private string SendPermitPaymentAck(string BulkPermitNo, decimal? ApprovedQty, decimal? TotalPayableAmount, string MineralName, string MineralGradeName
  , string MineralNature, string PaymentStatus, string TransactionId, string ApplicantName, string username)
        {
           var pathToFile = Path.Combine(webHostEnvironment.WebRootPath, "Template/DGMDMOBulkPermitAckEmailTemplate.html");
            string body = string.Empty;
            try
            {
                using (StreamReader reader = new StreamReader(pathToFile))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{TransactionId}", TransactionId);
                body = body.Replace("{PaymentStatus}", PaymentStatus);
                body = body.Replace("{UserName}", ApplicantName);
                body = body.Replace("{BulkPermitId}", BulkPermitNo.ToString());
                body = body.Replace("{ApprovedQty}", ApprovedQty.ToString());
                body = body.Replace("{TotalPayableAmount}", TotalPayableAmount.ToString());
                body = body.Replace("{MineralName}", MineralName.ToString());
                body = body.Replace("{MineralNature}", MineralNature.ToString());
                body = body.Replace("{Grade}", MineralGradeName.ToString());
                body = body.Replace("{ApprovedBy}", username);
                body = body.Replace("{MailedDateTime}", DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss"));
                body = body.Replace("{LogoPath}", LogoPath);
                body = body.Replace("{infiLogoPath}", infiLogoPath);
            }
            catch (Exception)
            {
            }
            return body;
        }

        public MessageEF SendPermitPaymentAck(PaymentEF obj)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                string body = SendPermitPaymentAck(obj.BulkPermitNo, obj.ApprovedQty, obj.TotalPayableAmount, obj.CardID, obj.IsKey, obj.IsIv, obj.Txn_Status, obj.TransactionalId, obj.ApplicantName,obj.UTR_Number);
                //  string body = PaymentAppAcceptOrRejectAckMail(model, DateTime.Now);
                SendMailMessage(obj.UserId,obj.Email,obj.EMailId, "Acknowledgement from Khanij Online System", body);
                messageEF.Satus = "success";
            }
            catch (Exception)
            {
                messageEF.Satus = "failed";
            }
            return messageEF;
        }
        #endregion

        #region Vehicle Owner
        public MessageEF SendMail(TransporterMail obj)
        {
            MessageEF messageEF = new MessageEF();
            try
            {

                string body = PopulateFPMailBody(obj.UserName, obj.Password, obj.UserId, DateTime.Now, obj.UserCode, obj.TransporterName);
                SendMailMessage(obj.UserId, obj.EMAIL_SENT, obj.EmailId, "Registration with Khanij Online System", body);
                messageEF.Satus = "success";
            }
            catch (Exception)
            {
            }
            return messageEF;
        }

        private string PopulateFPMailBody(string UserName, string Password, int? UserRegNumber, DateTime datetime, string UserCode, string ApplicantName)
        {
            string body = string.Empty;
            try
            {
                var rootpath = Path.Combine(webHostEnvironment.WebRootPath, "Template/EmailTemplate.html");
                using (StreamReader reader = new StreamReader(rootpath))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{ApplicantName}", ApplicantName);
                body = body.Replace("{UserName}", UserName);
                body = body.Replace("{Password}", Password);
                body = body.Replace("{UserRegNumber}", UserName);
                body = body.Replace("{CreatedDate}", datetime.ToString());
                body = body.Replace("{LogoPath}", LogoPath);
                body = body.Replace("{infiLogoPath}", infiLogoPath);

            }
            catch (Exception)
            {
            }
            return body;
        }

        public MessageEF SendMail_EUP(TransporterMail obj)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                string body = "";
                if (string.Equals(obj.Type, "REJECT"))
                {
                    body = "End User Registration, " + Environment.NewLine + Environment.NewLine + "Your End User registration in Khanij Online with Registration Number " + obj.RegistrationNo + " has been rejected.";
                }
                else if (string.Equals(obj.Type, "REGISTRATION"))
                {
                    body = "End User Registration, " + Environment.NewLine + Environment.NewLine + "You have successfully applied for Registration with Khanij Online Portal. Your Registration Number is " + obj.RegistrationNo + " Dated " + System.DateTime.Now + Environment.NewLine + Environment.NewLine +
                                                                     "Approval of your Application is Pending.";
                }
                else if (string.Equals(obj.Type, "REJECT_2"))
                {
                    body = "End User Updation, " + Environment.NewLine + Environment.NewLine + "Your End User updation request in Khanij Online with User Name " + obj.UserName + " has been rejected.";
                }
                else if (string.Equals(obj.Type, "APPROVED_2"))
                {
                    body = "End User Updation, " + Environment.NewLine + Environment.NewLine + "Your End User updation request in Khanij Online with User Name " + obj.UserName + " has been approved.";
                }
                else if (string.Equals(obj.Type, "OTP"))
                {
                    body = "End User Registration, " + Environment.NewLine + Environment.NewLine + "Your OTP : " + obj.MobileNo + "";
                }
                else if (string.Equals(obj.Type, "OTPGrivance"))
                {
                    body = "Outside portal Grivience , " + Environment.NewLine + Environment.NewLine + "Your OTP : " + obj.RegistrationNo + "";
                }

                SendMailMessage(obj.UserId, obj.EMAIL_SENT, obj.EmailId, "Registration with Khanij Online System", body);
                messageEF.Satus = "success";
            }
            catch (Exception)
            {
                messageEF.Satus = "success";
            }
            return messageEF;
        }
        #endregion

        #region Add Vehicle Acknowledgement
        public MessageEF SendMail_AddVehiclesAck(TransporterMail obj)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                string body = FinalAddVehiclesAckMailBody(obj, DateTime.Now);
                SendMailMessage(obj.UserId, obj.EMAIL_SENT, obj.EmailId, "Acknowledgement from Khanij Online System", body);
                messageEF.Satus = "success";
            }
            catch (Exception ex)
            {
                messageEF.Satus = "failed";
            }
            return messageEF;
        }

        private string FinalAddVehiclesAckMailBody(TransporterMail obj, DateTime? IsMailedDateTime)
        {
            string body = string.Empty;
            try
            {
                var rootpath = Path.Combine(webHostEnvironment.WebRootPath, "Template/AddVehiclesAckMailTemplate.html");
                using (StreamReader reader = new StreamReader(rootpath))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{TotalPayment}", obj.TotalVehiclesPayment.ToString());
                body = body.Replace("{MailedDateTime}", Convert.ToString(System.DateTime.Now));
                body = body.Replace("{VehicleCount}", obj.VehicleCount.ToString());
                body = body.Replace("{UserName}", obj.TransporterName);


            }
            catch (Exception)
            {
            }
            return body;
        }
        #endregion

        #region Send Tailing Dam Mail
        public MessageEF SendTailingDamMail(UserMasterModel userMasterModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            { 
                string body = PopulateTailingDamMailBody(userMasterModel.UserName, userMasterModel.Password, userMasterModel.UserId, DateTime.Now, userMasterModel.UserCode, userMasterModel.ApplicantName, userMasterModel.DistrictName);
                SendMailMessage(userMasterModel.UserId, userMasterModel.EMAIL_SENT, userMasterModel.EMailId, "Registration with Khanij Online System", body);
                messageEF.Satus = "success";
            }
            catch (Exception)
            {
                messageEF.Satus = "failed";
            }
            return messageEF;
        }

        private string PopulateTailingDamMailBody(string UserName, string Password, int? UserRegNumber, DateTime datetime, string UserCode, string ApplicantName, string DistrictName)
        {
            string body = string.Empty;
            try
            {
                var rootpath = Path.Combine(webHostEnvironment.WebRootPath, "Template/AwaitedPaymentEmailTemplate.html");
                using (StreamReader reader = new StreamReader(rootpath))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{ApplicantName}", ApplicantName);
                body = body.Replace("{DistrictName}", DistrictName);
                body = body.Replace("{UserName}", UserName);
                body = body.Replace("{UserRegNumber}", UserName);
                body = body.Replace("{CreatedDate}", datetime.ToString());
                body = body.Replace("{LogoPath}", LogoPath);
                body = body.Replace("{infiLogoPath}", infiLogoPath);

            }
            catch (Exception)
            {
            }
            return body;
        }
        #endregion

        #region Send Registration payment awaited email
        public MessageEF SendPaymentAwaitedMail(TransporterMail obj)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                string body = PopulatePAMailBody(obj.TransporterName, obj.CLNT_TXN_REF);
                SendMailMessage(obj.UserId, obj.EMAIL_SENT, obj.EmailId, "Registration with Khanij Online System", body);
                messageEF.Satus = "success";
            }
            catch (Exception)
            {
                messageEF.Satus = "failed";
            }
            return messageEF;
        }

        private string PopulatePAMailBody(string UserName, string trxnnumber)
        {
            string body = string.Empty;
            try
            {
                var rootpath = Path.Combine(webHostEnvironment.WebRootPath, "Template/AwaitedPaymentEmailTemplate.html");
                using (StreamReader reader = new StreamReader(rootpath))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{UserName}", UserName);
                body = body.Replace("{TransactionReffId}", trxnnumber);
                body = body.Replace("{LogoPath}", LogoPath);
                body = body.Replace("{infiLogoPath}", infiLogoPath);

            }
            catch (Exception)
            {
            }
            return body;
        }
        #endregion

        #region e-Permit Payment Acknowledgement Receipt
        public MessageEF SendNonPermitPaymentMail(LicensePaymentMail licensePaymentMail)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                string body = SendNonPermitPaymentMail_HTML(licensePaymentMail.PaymentReceiptID, licensePaymentMail.EmailID,
                    licensePaymentMail.ApplicantName, licensePaymentMail.PaymentType, licensePaymentMail.PayableAmount);
                SendMailMessage(licensePaymentMail.UserId, licensePaymentMail.EMAIL_SENT, licensePaymentMail.EmailID, "Acknowledgement from Khanij Online System", body);
                messageEF.Satus = "success";
            }
            catch (Exception)
            {
                messageEF.Satus = "failed";
            }
            return messageEF;
        }

        private string SendNonPermitPaymentMail_HTML(string PaymentReceiptID, string EmailID, string ApplicantName,
            string PaymentType, string PayableAmount)
        {
            string body = string.Empty;
            try
            {
                var rootpath = Path.Combine(webHostEnvironment.WebRootPath, "Template/NonPermitPayment.html");
                using (StreamReader reader = new StreamReader(rootpath))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{UserName}", ApplicantName);
                body = body.Replace("{PaymentType}", PaymentType);
                body = body.Replace("{PaymentID}", PaymentReceiptID);
                body = body.Replace("{MailedDateTime}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                body = body.Replace("{PayableAmount}", PayableAmount);
            }
            catch (Exception)
            {
            }
            return body;
        }

        public MessageEF SendLicenseApprovedAck(LicenseMail obj)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                string body = SendLicenseAppAck(obj.EMAILADDRESS, obj.LICENSE_APP_CODE, obj.USERNAME, obj.PASSWORD, obj.APPLICANTNAME, obj.application_tyep);
                SendMailMessage(obj.UserId, obj.EMAIL_SENT, obj.EMAILADDRESS, "Acknowledgement from Khanij Online System", body);
                messageEF.Satus = "success";
            }
            catch (Exception)
            {
                messageEF.Satus = "success";
            }
            return messageEF;
        }

        private string SendLicenseAppAck(string EmailId, string ApplicationNumber, string UserName, string Password, string ApplicantName, string ApplicationFor)
        {
            string body = string.Empty;
            try
            {
                var rootpath = Path.Combine(webHostEnvironment.WebRootPath, "Template/LicenseApprovedEmail.html");
                using (StreamReader reader = new StreamReader(rootpath))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{TransactionId}", ApplicationNumber);
                body = body.Replace("{ApplicantName}", ApplicantName);
                body = body.Replace("{ApplicationFor}", ApplicationFor);
                body = body.Replace("{UserName}", UserName);
                body = body.Replace("{Password}", Password);
                body = body.Replace("{MailedDateTime}", DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss"));
                body = body.Replace("{LogoPath}", LogoPath);
                body = body.Replace("{infiLogoPath}", infiLogoPath);
            }
            catch (Exception)
            {
            }
            return body;
        }
        #endregion

        #region Forgot Password
        /// <summary> 
        /// Forgot Password Mail
        /// </summary>
        /// <param name="forgotPassword"></param>
        /// <returns></returns>

        public MessageEF ForgotPasswordMail(ForgotPassword forgotPassword)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                string body = ForgotPasswordMailTemplate(forgotPassword.UserName, forgotPassword.OTP, forgotPassword.PasswordChange);
                SendMailMessage(forgotPassword.UserId, forgotPassword.EMAIL_SENT, forgotPassword.EmailId, "Acknowledgement from Khanij Online System", body);
                messageEF.Satus = "success";
            }
            catch (Exception)
            {
                messageEF.Satus = "Failed";
            }
            return messageEF;
        }

        /// <summary>
        /// Forgot Password Template
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="OTP"></param>
        /// <param name="PasswordChange"></param>
        /// <returns></returns>

        private string ForgotPasswordMailTemplate(string UserName, string OTP, string PasswordChange)
        {
            string body = string.Empty;
            try
            {
                var rootpath = Path.Combine(webHostEnvironment.WebRootPath, "Template/ForgotPassword/ForgotPassword_Mail.html");
                using (StreamReader reader = new StreamReader(rootpath))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{PasswordChange}", PasswordChange);
                body = body.Replace("{UserName}", UserName);
                body = body.Replace("{OTPCode}", OTP.ToString());
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return body;
        }

        /// <summary>
        /// Send Mail
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="EMAIL_SENT"></param>
        /// <param name="To"></param>
        /// <param name="Subject"></param>
        /// <param name="Body"></param>
        /// <returns></returns>

        public async Task SendMailMessage(int? UserId, string EMAIL_SENT, string To, string Subject, string Body)
        {

            bool isMail = true;

            if (UserId > 0 && EMAIL_SENT == "0")
            {
                isMail = false;
            }

            if (isMail == true)
            {
                try
                {

                    MailMessage mail = new MailMessage();
                    string _emailId = To;
                    string _message = Body;

                    mail.To.Add(_emailId);
                    mail.From = new MailAddress(configuration.GetSection("MailConfiguration").GetValue<string>("smtpEmail"),
                        configuration.GetSection("MailConfiguration").GetValue<string>("smtpAliase"));

                    mail.Subject = Subject;
                    mail.SubjectEncoding = System.Text.Encoding.UTF8;
                    mail.Body = _message;
                    mail.BodyEncoding = System.Text.Encoding.UTF8;
                    mail.IsBodyHtml = true;
                    mail.Priority = System.Net.Mail.MailPriority.High;



                    using (SmtpClient client = CreateMailClient())
                    {


                        client.Port = Convert.ToInt32(configuration.GetSection("MailConfiguration").GetValue<int>("smtpPort"));
                        client.Host = Convert.ToString(configuration.GetSection("MailConfiguration").GetValue<string>("smtpHost"));
                        client.Credentials = new System.Net.NetworkCredential(configuration.GetSection("MailConfiguration").GetValue<string>("smtpLoginId").ToString(),
                            configuration.GetSection("MailConfiguration").GetValue<string>("smtpPassword"));
                        client.EnableSsl = Convert.ToBoolean(configuration.GetSection("MailConfiguration").GetValue<bool>("SSLRequire"));
                        client.Send(mail);

                    }
                }
                catch (Exception ex)
                {
                    var paramList = new
                    {
                        Area = "MailService.cs",
                        Controller = "MailService.cs",
                        Action = "MailService.cs",
                        ReturnType = ex.InnerException.Message,
                        ErrorMessage = ex.Message,
                        StackTrace = ex.StackTrace,
                        UserId = UserId,
                        UserLoginID = UserId
                    };
                    var result = Connection.Execute("ReportErrorLog", paramList, commandType: System.Data.CommandType.StoredProcedure);

                }

            }
        }

        /// <summary>
        /// Create Mail Client
        /// </summary>
        /// <returns></returns>

        private SmtpClient CreateMailClient()
        {
            SmtpClient client = new SmtpClient();

            // Configure client.

            return client;
        }

        
        #endregion
    }
}
