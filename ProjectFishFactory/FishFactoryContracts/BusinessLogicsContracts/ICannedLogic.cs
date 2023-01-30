using FishFactoryContracts.BindingModels;
using FishFactoryContracts.SearchModels;
using FishFactoryContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFactoryContracts.BusinessLogicsContracts
{
    public interface ICannedLogic
    {
        List<CannedViewModel>? ReadList(CannedSearchModel? model);
        CannedViewModel? ReadElement(CannedSearchModel model);
        bool Create(CannedBindingModel model);
        bool Update(CannedBindingModel model);
        bool Delete(CannedBindingModel model);
    }
}
