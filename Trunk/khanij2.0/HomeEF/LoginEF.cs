// ***********************************************************************
// Assembly         : Khanij
// Author           : Kumar jeevan jyoti
// Created          : 28-dec-2020
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeEF
{
   public  class LoginEF
    {
        public int UserTypeId { get; set; }
        public string UserType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public int UserID { get; set; }
        public string MobileNo { get; set; }
        public string Remoteid { get; set; }
        public string Localip { get; set; }
        public string Browserinfo { get; set; }
    }
}
