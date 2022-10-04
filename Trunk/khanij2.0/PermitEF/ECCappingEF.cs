using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermitEF
{
   public  class ECCappingEF
    {

        public string FinancialYear { get; set; }
        public decimal? OpeningStock { get; set; }
        public int? MineralGradeId { get; set; }
        public string Remarks { get; set; }

        public int ECQuantity { get; set; }
        public int LesseeID { get; set; }

        public int RemainingQuantity { get; set; }
        public int ECCappingID { get; set; }

        public string MineralGrade { get; set; }
        public decimal? GradeWise_OpeningStock { get; set; }
        public int UserID { get; set; }
        public string OpeningStockValue { get; set; }

        public string UserLoginId { get; set; }
        public string Year { get; set; }

        public string AStatus { get; set; }
        public bool IsSelected { get; set; }
        public int Srno { get; set; }

        public int ActiveStatus { get; set; }
        public string UserName { get; set; }

        public string CreatedDate { get; set; }
        public string DistrictName { get; set; }



        public List<ECCappingEF> CurrentYear { get; set; }

        public List<ECCappingEF> AllStockes { get; set; }


        public DataTable OpeningStockTable { get; set; }
    }
}
