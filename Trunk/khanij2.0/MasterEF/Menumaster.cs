// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 29-Jan-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace MasterEF
{
    public class Menumaster
    {
        public int? MenuId { get; set; }
        public string MenuName { get; set; }
        public string ParentName { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public bool IsActive { get; set; }
        public int MenuSrNo { get; set; }
        public string Controller { get; set; }
        public string ActionName { get; set; }
        public int? CreatedBy { get; set; }
        public string CssClass { get; set; }
        public int? DisplaySrNo { get; set; }
        public bool Operation { get; set; }
        public string Area { get; set; }
        public string GifIcon { get; set; }
        public string ActiveStatus { get; set; }
        public string  url { get; set; }
        public int? MmenuID { get; set; }
        public string MainMenuName { get; set; }
    }
}
