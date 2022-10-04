using HomeApp.Models.Utility;
using HomeEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Areas.Website.Models.Graph
{
    public class Mineral : IMineral
    {
        IHttpWebClients _objIHttpWebClients;
        public Mineral(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        public List<MineralGradeModel> ViewMineral(MineralGradeModel mineralGradeModel)
        {
            try
            {
                List<MineralGradeModel> listMineralGradeModel = new List<MineralGradeModel>();
                listMineralGradeModel = JsonConvert.DeserializeObject<List<MineralGradeModel>>(_objIHttpWebClients.PostRequest("MineralGrade/ViewDetails", JsonConvert.SerializeObject(mineralGradeModel)));
                return listMineralGradeModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<MineralGradeModel> ViewMineralCategory(MineralGradeModel mineralGradeModel)
        {
            try
            {
                mineralGradeModel.CHK = 8;
                List<MineralGradeModel> listMineralGradeModel = new List<MineralGradeModel>();
                listMineralGradeModel = JsonConvert.DeserializeObject<List<MineralGradeModel>>(_objIHttpWebClients.PostRequest("MineralGrade/ViewDetails", JsonConvert.SerializeObject(mineralGradeModel)));
                return listMineralGradeModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
