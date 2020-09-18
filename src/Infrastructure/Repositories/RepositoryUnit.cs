using System.Threading.Tasks;
using Architect.ApplicationCore.Repositories;
using Architect.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace Architect.Infrastructure.Repositories
{
    public class RepositoryUnit : IRepositoryUnit
    {
        public IUserRepository UserRepository => new UserRepository(DbContext);

        protected ArchitectDbContext DbContext;

        public RepositoryUnit(ArchitectDbContext dbContext) => DbContext = dbContext;

        public IDbContextTransaction BeginTransaction() => DbContext.Database.BeginTransaction();
        public async Task<IDbContextTransaction> BeginTransactionAsync() => await DbContext.Database.BeginTransactionAsync();

        public int SaveChanges() => DbContext.SaveChanges();
        public async Task<int> SaveChangesAsync() => await DbContext.SaveChangesAsync();
    }
}
