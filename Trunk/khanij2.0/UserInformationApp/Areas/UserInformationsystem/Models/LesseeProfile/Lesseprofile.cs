using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using UserInformationEF;

namespace UserInformationApp.Models.LesseeProfile
{
    public class Lesseprofile : ILesseprofile
    {
        public List<LeaseApplicationModel> GetCompMasterData(LeaseApplicationModel objPaymentTypemaster)
        {
            List<LeaseApplicationModel> objticket = new List<LeaseApplicationModel>();
            try
            {

                objticket = JsonConvert.DeserializeObject<List<LeaseApplicationModel>>(UserInformationApp.Models.Utility.HttpWebClients.PostRequest("Lesseeprofile/GetCompMasterData", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objticket;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF Add(LeaseApplicationModel objPaymentTypemaster)
        {
            string _result = "";
            try
            {
                MessageEF objMessageEF = new MessageEF();

                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(UserInformationApp.Models.Utility.HttpWebClients.PostRequest("Lesseeprofile/Add", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public LeaseApplicationModel GetlesseEditdata (LeaseApplicationModel objPaymentTypemaster)
        {

            PreferredBidder objpreferred = new PreferredBidder();
            try
            {

                objPaymentTypemaster = JsonConvert.DeserializeObject<LeaseApplicationModel>(UserInformationApp.Models.Utility.HttpWebClients.PostRequest("Lesseeprofile/GetlesseEditdata", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objPaymentTypemaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
