﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Data
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
