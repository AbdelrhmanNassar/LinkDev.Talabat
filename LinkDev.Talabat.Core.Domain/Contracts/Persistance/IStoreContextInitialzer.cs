﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Domain.Contracts.Persistance
{
    public interface IStoreContextInitialzer
    {
        public Task Seed();

        public Task Inialize();



    }
}
