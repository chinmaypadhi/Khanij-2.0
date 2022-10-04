// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 25-Jan-2021
//
// ***********************************************************************
using MasterEF;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterApi.Model.Transparncy
{
    public interface ITransparncyProvider
    {
        MessageEF AddTransparncymaster(Transparncymaster objTransparncymaster);
        Task <List<Transparncymaster>> ViewTransparncymaster(Transparncymaster objTransparncymaster);
        Transparncymaster EditTransparncymaster(Transparncymaster objTransparncymaster);
        MessageEF DeleteTransparncymaster(Transparncymaster objTransparncymaster);
        MessageEF UpdateTransparncymaster(Transparncymaster objTransparncymaster);
        List<Transparncymaster> ViewNotice(Transparncymaster objTransparncymaster);
    }
}
