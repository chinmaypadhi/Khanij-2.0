using EpassApi.Repository;
using System;
using EpassEF;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace EpassApi.Model.ePassConfiguration
{
    public interface IePassConfigurationProvider : IDisposable, IRepository
    {
        Task<List<ePassConfigurationEF>> GetDistrict(ePassConfigurationEF model);
        Task<List<ePassConfigurationEF>> GetUserType(ePassConfigurationEF model);
        Task<List<ePassConfigurationEF>> GetMineralType(ePassConfigurationEF model);
        Task<List<ePassConfigurationEF>> GetUserName(ePassConfigurationEF model);
        Task<List<ePassConfigurationEF>> GetMineralName(ePassConfigurationEF model);
         Task<List<ePassConfigurationEF>> GetTransportationMode(ePassConfigurationEF objePassConfigurationModel);
         Task<List<ePassConfigurationEF>> GetAllowConsignee(ePassConfigurationEF objePassConfigurationModel);
        MessageEF AddEpassConfiguration(ePassConfigurationEF objePassConfigurationModel);
         Task<List<ePassConfigurationEF>> ViewEpassConfiguration(ePassConfigurationEF objePassConfigurationModel);
        ePassConfigurationEF EditViewConfig(ePassConfigurationEF objePassConfigurationModel);
        MessageEF UpdateEpassConfiguration(ePassConfigurationEF obj);
        MessageEF DeleteEpassConfiguration(ePassConfigurationEF objConfig);
    }
}
