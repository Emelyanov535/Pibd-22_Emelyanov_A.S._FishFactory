using FishFactoryContracts.BindingModels;
using FishFactoryContracts.ViewModels;
using FishFactoryDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFactoryListImplement.Models
{
    public class Canned : ICannedModel
    {
        public int Id { get; private set; }
        public string CannedName { get; private set; } = string.Empty;
        public double Price { get; private set; }
        public Dictionary<int, (IComponentModel, int)> CannedComponents
        {
            get;
            private set;
        } = new Dictionary<int, (IComponentModel, int)>();
        public static Canned? Create(CannedBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Canned()
            {
            Id = model.Id,
            CannedName = model.CannedName,
            Price = model.Price,
            CannedComponents = model.CannedComponents
            };
        }
        public void Update(CannedBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            CannedName = model.CannedName;
            Price = model.Price;
            CannedComponents = model.CannedComponents;
        }
        public CannedViewModel GetViewModel => new()
        {
            Id = Id,
            CannedName = CannedName,
            Price = Price,
            CannedComponents = CannedComponents
        };
    }
}
