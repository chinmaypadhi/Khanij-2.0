using System;
using System.Collections.Generic;
using System.Text;

namespace EstablishmentEf
{
    public class AecConfigEF
    {
        public int intConfiguretionId   {get;set;}
        public int IntDepartment        {get;set;}
        public int IntDesignation       {get;set;}
        public int IntUser              {get;set;}
        public int intReAuDepartment    {get;set;}
        public int intReAuDesignation   {get;set;}
        public int intReAuUserId        {get;set;}
        public int intRevAuDepartment   {get;set;}
        public int intRevAuDesignation  {get;set;}
        public int intRevAuUser         {get;set;}
        public int intAccAuDepartment   {get;set;}
        public int intAccAuDesignation  {get;set;}
        public int intAccAuUser         {get;set;}
        public bool bitDeletedFlage     {get;set;}
        public int intCreatedBy         {get;set;}
        public DateTime  dateCreatedOn  {get;set;}
        public int intUpdatedBy         {get;set;}
        public DateTime dateUpdatedOn   { get; set; }
        public string Action            { get; set; }

    }
}
