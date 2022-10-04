
// ***********************************************************************
//  Class Name               : AddPageModel
//  Desciption               : Add,Select,Update,Delete Website Set Permission Details 
//  Created By               : Prakash Chandra Biswal
//  Created On               : 08 Nov 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeEF
{
    public class AddSetPermissionModel
    {
        public int? INT_SETPERMISSION_ID { get; set; }
        public int INT_PROFILE_ID { get; set; }
        public int INT_PAGE_ID { get; set; }
        public int INT_GLINK_ID { get; set; }
        public int INT_PLINK_ID { get; set; }
        public int INT_NOTIFICATION_ID { get; set; }
        public int INT_TENDER_ID { get; set; }
        public int INT_STAFFDIR_ID { get; set; }
        public int INT_TESTIMONIAL_ID { get; set; }
        public int INT_BANNER_ID { get; set; }
        public int INT_GALLERY_ID { get; set; }
        public int INT_USER_ID { get; set; }
        public bool BIT_AUTHOR_RIGHT { get; set; }
        public bool BIT_EDITOR_RIGHT { get; set; }
        public bool BIT_PUBLISHER_RIGHT { get; set; }
        public bool BIT_MANAER_RIGHT { get; set; }
        public bool BIT_STATUS { get; set; }
        public int? INT_CREATED_BY { get; set; }
    }
}
