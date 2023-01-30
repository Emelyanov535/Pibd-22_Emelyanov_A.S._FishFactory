using FishFactoryDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFactoryContracts.BindingModels
{
    public class CannedBindingModel : ICannedModel
    {
        public int Id { get; set; }
        public string CannedName { get; set; } = string.Empty;
        public double Price { get; set; }
        public Dictionary<int, (IComponentModel, int)> CannedComponents
        {
            get;
            set;
        } = new();
    }
}
