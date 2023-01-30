using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFactoryDataModels.Models
{
    public interface ICannedModel : IId
    {
        string CannedName { get; }
        double Price { get; }
        Dictionary<int, (IComponentModel, int)> CannedComponents { get; }
    }
}
