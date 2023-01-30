using FishFactoryContracts.BindingModels;
using FishFactoryContracts.BusinessLogicsContracts;
using FishFactoryContracts.SearchModels;
using FishFactoryContracts.StoragesContracts;
using FishFactoryContracts.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFactoryBusinessLogic.BusinessLogics
{
    public class CannedLogic : ICannedLogic
    {
        private readonly ILogger _logger;
        private readonly ICannedStorage _cannedStorage;
        public CannedLogic(ILogger<CannedLogic> logger, ICannedStorage cannedStorage)
        {
            _logger = logger;
            _cannedStorage = cannedStorage;
        }

        public List<CannedViewModel>? ReadList(CannedSearchModel? model)
        {
            _logger.LogInformation("ReadList. CannedName:{CannedName}.Id:{ Id}", model?.CannedName, model?.Id);
            var list = model == null ? _cannedStorage.GetFullList() : _cannedStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }

        public CannedViewModel? ReadElement(CannedSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. CannedName:{CannedName}.Id:{ Id}", model.CannedName, model.Id);
            var element = _cannedStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }

        public bool Create(CannedBindingModel model)
        {
            CheckModel(model);
            if (_cannedStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }

        public bool Delete(CannedBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id:{Id}", model.Id);
            if (_cannedStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }
            return true;
        }

        public bool Update(CannedBindingModel model)
        {
            CheckModel(model);
            if (_cannedStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }

        private void CheckModel(CannedBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.CannedName))
            {
                throw new ArgumentNullException("Нет названия консервы", nameof(model.CannedName));
            }
            if (model.Price <= 0)
            {
                throw new ArgumentNullException("Цена консервы должна быть больше 0", nameof(model.Price));
            }
            _logger.LogInformation("Canned. CannedName:{CannedName}.Cost:{ Cost}. Id: { Id}", model.CannedName, model.Price, model.Id);
            var element = _cannedStorage.GetElement(new CannedSearchModel
            {
                CannedName = model.CannedName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Консерва с таким названием уже есть");
            }
        }
    }
}
