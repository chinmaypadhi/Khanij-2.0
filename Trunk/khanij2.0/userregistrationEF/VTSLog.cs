using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userregistrationEF
{
    public class VTSLog
    {
	  public int? LogId { get; set; }
	  public string VTSApiName { get; set; }
	  public string Result { get; set; }
	  public string CreatedBy { get; set; } 
	  public string RequestedData { get; set; }
	  public string ResponseData { get; set; }
	}
}
