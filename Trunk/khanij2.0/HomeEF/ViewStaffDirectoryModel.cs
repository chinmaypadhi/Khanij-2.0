// ***********************************************************************
//  Class Name               : ViewStaffDirectoryModel
//  Desciption               : View Staff Directory Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 20 Oct 2021
// ***********************************************************************

namespace HomeEF
{
    public class ViewStaffDirectoryModel
    {
		public int? INT_STAFFDIR_ID { get; set; }
		public string VCH_OFFICE_TYPE { get; set; }
		public string VCH_OFFICER_NAME { get; set; }
		public string VCH_OFFICER_DESIG { get; set; }
		public string VCH_PHONE_NO { get; set; }
		public string VCH_EMAIL { get; set; }
		public string VCH_LOCATION { get; set; }
		public string BIT_STATUS { get; set; }
		public int? INT_CREATED_BY { get; set; }
	}
}
