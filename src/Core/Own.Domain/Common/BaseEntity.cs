﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Own.Domain.Common
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}