using System;
using System.Collections.Generic;
using System.Text;

namespace EstablishmentEf
{
    public class AppraisalClassIVEF
    {
        public int id                      {get;set;}
        public string vchName              {get;set;}
        public string vchFatherName        {get;set;}
        public string vchHighereducation   {get;set;}
        public string vchPost              {get;set;}
        public string dtmJoiningdate       {get;set;}
        public string vchPaceofwork        {get;set;}
        public string intTimeperiod        {get;set;}
        public string vchbehavior          {get;set;}
        public string vchpunctual          {get;set;}
        public string vchPhysicalcapacity  {get;set;}
        public string VchResponsibility    {get;set;}
        public string VchTransform         {get;set;}
        public string VchGrade             {get;set;}
        public int intCreatedBy            {get;set;}
        public DateTime dateCreatedOn      {get;set;}
        public int intUpdatedBy            {get;set;}
        public DateTime dateUpdatedOn { get; set; }
        public string Status { get; set; }

    }
}
