using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.MineralSize
{
    public interface IMineralSizeProvider : IDisposable, IRepository
    {
        Task<MessageEF> AddMineralSize(MineralSizeMaster mineralSizeMaster);
        Task<List<MineralSizeMaster>> ViewMineralSize(MineralSizeMaster mineralSizeMaster);
        Task<MineralSizeMaster> EditMineralSize(MineralSizeMaster mineralSizeMaster);
        Task<MessageEF> DeleteMineralSize(MineralSizeMaster mineralSizeMaster);
        Task<MessageEF> UpdateMineralSize(MineralSizeMaster mineralSizeMaster);
    }
}
