using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDeskEF
{
    public class MenuEF
    {
        public int? MenuId { get; set; }
        public string MenuName { get; set; }
        public string ParentId { get; set; }
        public string Controller { get; set; }
        public string url { get; set; }
        public string Area { get; set; }
        public string ActionName { get; set; }
        public string IsView { get; set; }
        public string IsAdd { get; set; }
        public string IsEdit { get; set; }
        public string IsDelete { get; set; }
        public int? DisplaySrNo { get; set; }
        public string CssClass { get; set; }
        public string MenuLevel { get; set; }
        public string ParentMenuName { get; set; }
        public List<childMenu> childMenuList { get; set; }
        public string GifIcon { get; set; }
        public string divclass { get; set; }
        public string SvgPath { get; set; }
        public string LinkPath { get; set; }
    }
    public class ParentMenu
    {

    }
    public class childMenu
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int ParentId { get; set; }
        public string Controller { get; set; }
        public string url { get; set; }
        public string Area { get; set; }
        public string ActionName { get; set; }
        public string IsView { get; set; }
        public string IsAdd { get; set; }
        public string IsEdit { get; set; }
        public string IsDelete { get; set; }
        public string DisplaySrNo { get; set; }
        public string CssClass { get; set; }
        public string MenuLevel { get; set; }
        public string ParentMenuName { get; set; }
        public string GifIcon { get; set; }
        public string Description { get; set; }
    }
    public class menuonput
    {
        public int UserID { get; set; }
        public int? MMenuId { get; set; }
        public int MineralId { get; set; }
        public string MineralName { get; set; }
    }
}
