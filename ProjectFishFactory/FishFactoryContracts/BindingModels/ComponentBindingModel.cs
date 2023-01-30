﻿using FishFactoryDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFactoryContracts.BindingModels
{
    public class ComponentBindingModel : IComponentModel
    {
        public int Id { get; set; }
        public string ComponentName { get; set; } = string.Empty;
        public double Cost { get; set; }
    }
}
