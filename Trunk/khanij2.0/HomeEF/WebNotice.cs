using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeEF
{
    public class WebNotice
    {
        public string NoticeText { get; set; }
        public string ActiveStatus { get; set; }
        public string IsPublish { get; set; }
        public string NoticeFilePath { get; set; }
        public string NoticeFileName { get; set; }
        public string ImageUrlPath { get; set; }
    }
}
