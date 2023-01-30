using FishFactoryDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFactoryContracts.ViewModels
{
    public class CannedViewModel : ICannedModel
    {
        public int Id { get; set; }
        [DisplayName("Название изделия")]
        public string CannedName { get; set; } = string.Empty;
        [DisplayName("Цена")]
        public double Price { get; set; }
        public Dictionary<int, (IComponentModel, int)> CannedComponents
        {
            get;
            set;
        } = new();
    }
}
