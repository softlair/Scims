﻿using Slair.Core.Model.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Slair.Scims.Model.Abstractions
{
    public interface IEditableModel<T> : IEditableEntity<int, T>
    {

    }
}