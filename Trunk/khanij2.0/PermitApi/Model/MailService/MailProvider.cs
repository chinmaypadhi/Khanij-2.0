using Dapper;
using PermitApi.Factory;
using PermitApi.Repository;
using PermitEF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PermitApi.Model.MailService
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
        private SmtpClient CreateMailClient()
        {
            SmtpClient client = new SmtpClient();

            // Configure client.

            return client;
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
    }
}
