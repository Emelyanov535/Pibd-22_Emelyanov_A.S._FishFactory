using FishFactoryContracts.BindingModels;
using FishFactoryContracts.SearchModels;
using FishFactoryContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFactoryContracts.StoragesContracts
{
    public interface ICannedStorage
    {
        List<CannedViewModel> GetFullList();
        List<CannedViewModel> GetFilteredList(CannedSearchModel model);
        CannedViewModel? GetElement(CannedSearchModel model);
        CannedViewModel? Insert(CannedBindingModel model);
        CannedViewModel? Update(CannedBindingModel model);
        CannedViewModel? Delete(CannedBindingModel model);
    }
}
