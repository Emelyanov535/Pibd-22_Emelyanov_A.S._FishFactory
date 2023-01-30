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
    public interface IOrderStorage
    {
        List<OrderViewModel> GetFullList();
        List<OrderViewModel> GetFilteredList(OrderSearchModel model);
        OrderViewModel? GetElement(OrderSearchModel model);
        OrderViewModel? Insert(OrderBindingModel model);
        OrderViewModel? Update(OrderBindingModel model);
        OrderViewModel? Delete(OrderBindingModel model);
    }
}
