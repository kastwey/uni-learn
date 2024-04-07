using Microsoft.EntityFrameworkCore;

using UniLearn.Data.Context;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniLearn.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly UniLearnDbContext _dbContext;

        public UnitOfWork(UniLearnDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Commit()
        {
            return _dbContext.SaveChangesAsync();
        }

        public Task Rollback()
        {
            return Task.CompletedTask; ;
        }
    }
}
