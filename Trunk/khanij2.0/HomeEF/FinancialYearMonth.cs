using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeEF
{
    public class FinancialYearMonth
    { 
        public int UserId { get; set; }
        public int Srno { get; set; }
        public string Year { get; set; }
        public bool IsSelected { get; set; }
        public int M_Id { get; set; }
        public string Months { get; set; }
    }
}
