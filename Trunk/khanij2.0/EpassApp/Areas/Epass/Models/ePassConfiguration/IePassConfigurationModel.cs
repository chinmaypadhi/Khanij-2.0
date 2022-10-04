using EpassEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApp.Areas.Epass.Models.ePassConfiguration
{
    public interface IePassConfigurationModel
    {
        /// <summary>
        /// Added by suroj on 7-jul-2021  to fetch Permit No
        /// </summary>
        /// <param name="objOpenModel"></param>
        /// 
        /// <returns></returns>
        /// 
        List<ePassConfigurationEF> GetDistrict(ePassConfigurationEF objConfig);
        List<ePassConfigurationEF> GetUserType(ePassConfigurationEF objConfig);
        List<ePassConfigurationEF> GetMineralType(ePassConfigurationEF objConfig);
        List<ePassConfigurationEF> GetUserName(ePassConfigurationEF objConfig);
        List<ePassConfigurationEF> GetMineralName(ePassConfigurationEF objConfig);
         List<ePassConfigurationEF> GetTransportationMode(ePassConfigurationEF objConfig);
        List<ePassConfigurationEF> GetAllowConsignee(ePassConfigurationEF objConfig);
        MessageEF AddPassConfiguration(ePassConfigurationEF objConfig);
        List<ePassConfigurationEF> View(ePassConfigurationEF objConfig);
        ePassConfigurationEF EditViewConfig(ePassConfigurationEF objConfig);
         MessageEF UpdatePassConfiguration(ePassConfigurationEF objConfig);
        MessageEF DeletePassConfiguration(ePassConfigurationEF objConfig);

    }
}
