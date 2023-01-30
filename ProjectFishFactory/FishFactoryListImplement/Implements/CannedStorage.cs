using FishFactoryContracts.BindingModels;
using FishFactoryContracts.SearchModels;
using FishFactoryContracts.StoragesContracts;
using FishFactoryContracts.ViewModels;
using FishFactoryListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFactoryListImplement.Implements
{
    public class CannedStorage : ICannedStorage
    {
        private readonly DataListSingleton _source;
        public CannedStorage()
        {
            _source = DataListSingleton.GetInstance();
        }
        public CannedViewModel? Delete(CannedBindingModel model)
        {
            for (int i = 0; i < _source.Canneds.Count; ++i)
            {
                if (_source.Canneds[i].Id == model.Id)
                {
                    var element = _source.Canneds[i];
                    _source.Canneds.RemoveAt(i);
                    return element.GetViewModel;
                }
            }
            return null;
        }

        public CannedViewModel? GetElement(CannedSearchModel model)
        {
            if (string.IsNullOrEmpty(model.CannedName) && !model.Id.HasValue)
            {
                return null;
            }

            foreach (var canned in _source.Canneds)
            {
                if (!string.IsNullOrEmpty(model.CannedName) &&
               canned.CannedName == model.CannedName ||
                model.Id.HasValue && canned.Id == model.Id)
                {
                    return canned.GetViewModel;
                }
            }
            return null;
        }

        public List<CannedViewModel> GetFilteredList(CannedSearchModel model)
        {
            var result = new List<CannedViewModel>();
            if (string.IsNullOrEmpty(model.CannedName))
            {
                return result;
            }
            foreach (var canned in _source.Canneds)
            {
                if (canned.CannedName.Contains(model.CannedName))
                {
                    result.Add(canned.GetViewModel);
                }
            }
            return result;
        }

        public List<CannedViewModel> GetFullList()
        {
            var result = new List<CannedViewModel>();
            foreach (var canned in _source.Canneds)
            {
                result.Add(canned.GetViewModel);
            }
            return result;
        }

        public CannedViewModel? Insert(CannedBindingModel model)
        {
            model.Id = 1;
            foreach (var canned in _source.Canneds)
            {
                if (model.Id <= canned.Id)
                {
                    model.Id = canned.Id + 1;
                }
            }
            var newCanned = Canned.Create(model);
            if (newCanned == null)
            {
                return null;
            }
            _source.Canneds.Add(newCanned);
            return newCanned.GetViewModel;
        }

        public CannedViewModel? Update(CannedBindingModel model)
        {
            foreach (var canned in _source.Canneds)
            {
                if (canned.Id == model.Id)
                {
                    canned.Update(model);
                    return canned.GetViewModel;
                }
            }
            return null;
        }
    }
}
