﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Own.Domain.Common
{
    public abstract class BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
