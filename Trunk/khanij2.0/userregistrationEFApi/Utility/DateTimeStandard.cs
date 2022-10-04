using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace userregistrationEFApi.Utility
{
    public static class DateTimeStandard
    {
        #region Converting dd/mm/yyyy Format to mm/dd/yyyy

        public static string SetDateFormat(string ddmmyyy)//Converting dd/mm/yyyy Format to mm/dd/yyyy
        {
            string mmddyyy = "";
            if (ddmmyyy != null && ddmmyyy != "")
            {
                if (ddmmyyy.Contains("/"))
                {
                    string dd = ddmmyyy.Split('/')[0];
                    string mm = ddmmyyy.Split('/')[1];
                    string yyyy = ddmmyyy.Split('/')[2];
                    mmddyyy = mm + "/" + dd + "/" + yyyy;
                }
                if (ddmmyyy.Contains("-"))
                {
                    string dd = ddmmyyy.Split('-')[0];
                    string mm = ddmmyyy.Split('-')[1];
                    string yyyy = ddmmyyy.Split('-')[2];
                    mmddyyy = mm + "/" + dd + "/" + yyyy;
                }
            }
            return mmddyyy;
        }
        #endregion
    }
}
