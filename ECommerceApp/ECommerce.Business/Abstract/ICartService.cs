﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Business.Abstract
{
   public interface ICartService
    {
        void InitializeCart(string userId);
    }
}
