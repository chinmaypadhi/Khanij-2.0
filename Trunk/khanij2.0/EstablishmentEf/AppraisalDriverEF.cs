using System;
using System.Collections.Generic;
using System.Text;

namespace EstablishmentEf
{
    public class AppraisalDriverEF
    {
        public string Action { get; set; }
        public int id                       {get;set;}
        public string VchName               {get;set;}
        public string DtmDaterequirement    {get;set;}
        public string Vchbehavior           {get;set;}
        public string VchPhysicalfitness    {get;set;}
        public string vchAbilitydrive       {get;set;}
        public string VchSafety             {get;set;}
        public string VchBOL                {get;set;}
        public string vchMaintenancevehicle {get;set;}
        public string VchPresent            {get;set;}
        public string Vchpunctual           {get;set;}
        public string VchUniform            {get;set;}
        public string VchCharacter          {get;set;}
        public string VchAppreciation       {get;set;}
        public string VchGrade              {get;set;}
        public int intCreatedBy             {get;set;}
        public DateTime dateCreatedOn         {get;set;}
        public int intUpdatedBy             {get;set;}
        public DateTime dateUpdatedOn { get; set; }

    }
}
