using Application.Repositories;
using Core.Infraestructure.Repositories.Sql;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Sql
{
    internal class AutomovilRepository : BaseRepository<Automovil>,IAutomovilRepository
    {
         public AutomovilRepository(StoreDbContext context) : base(context) { }

        
        public async Task<Automovil?> FindOneByChasisAsync(string numeroChasis)
        {
            
            return await Repository.FirstOrDefaultAsync(a => a.NumeroChasis == numeroChasis);
        }

       

    }

}
