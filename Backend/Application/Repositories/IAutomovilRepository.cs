﻿using Core.Application.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IAutomovilRepository : IRepository<Automovil> 
    {
        Task<Domain.Entities.Automovil> FindOneByChasisAsync(string chasis);

    }

}
