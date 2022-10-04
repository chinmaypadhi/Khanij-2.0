using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SupportApi.Model.Inspection
{
    public class TestClass
    {
        public void Test()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("insId", typeof(int));
            dt.Columns.Add("IssuanceOfNoticeId", typeof(int));
            dt.Columns.Add("IsSatisfied", typeof(int));
            dt.Columns.Add("Remarks", typeof(string));

        }
    }
}
