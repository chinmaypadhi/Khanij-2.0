using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Areas.Website.Models.FinancialYear
{
    public class FinancialYearModel : IFinancialYearModel
    {
        public List<string> GetFinancialYear()
        {
            string financialyear = "";
            StreamReader r = new StreamReader("FinancialYear.json");
            string jsonString = r.ReadToEnd();
            var output = JsonConvert.DeserializeObject<List<dynamic>>(jsonString);
            int trailingyear = Convert.ToInt32(output[0].TrailingFYear);
            List<string> fyear = new List<string>();
            for (int i = 0; i < trailingyear; i++)
            {
                if (DateTime.Now >= DateTime.MinValue.AddMonths(3))
                {
                    financialyear = ((DateTime.Now.AddMonths(-3).Year) - i).ToString() + "-";
                    financialyear += ((DateTime.Now.AddMonths(-3).Year) + 1 + (-i)).ToString().Substring(2);
                    fyear.Add(financialyear);
                }
            }
            return fyear;
        }
    }
}
