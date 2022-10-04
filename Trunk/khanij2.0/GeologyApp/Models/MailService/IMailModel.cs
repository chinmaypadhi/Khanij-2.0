using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeologyEF;

namespace GeologyApp.Models.MailService
{
    public interface IMailModel
    {
        /// <summary>
        /// Send Mail of Monthly Progress Report
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        MessageEF SendMail_MPR(GeologyMail obj);
        /// <summary>
        /// Send Mail of Field Status Report
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        MessageEF SendMail_FSR(GeologyMail obj);
    }
}
