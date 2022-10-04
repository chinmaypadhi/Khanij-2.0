using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportEF
{
    public class AddGlobalLinkModel
    {
        public string INT_TOPMENU_ID { get; set; }
        public string VCH_TOPMENU_ID { get; set; }
        public string INT_MAINMENU_ID { get; set; }
        public string VCH_MAINMENU_ID { get; set; }
        public string INT_FOOTERMENU_ID { get; set; }
        public string VCH_FOOTERMENU_ID { get; set; }
        public string VCH_PAGE_NAME { get; set; }
        public string VCH_TOPMENU_URL { get; set; }
        public string VCH_MAINMENU_URL { get; set; }
        public string VCH_FOOTERMENU_URL { get; set; }
        public int? INT_PAGE_ID { get; set; }
        public int? INT_CREATED_BY { get; set; }
    }
}
