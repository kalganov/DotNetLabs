using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Labs;
using Labs.Entities;
using Microsoft.EntityFrameworkCore;

namespace SQL.Repositories.Impl
{
    public class UserRepository : IUserRepository
    {
        private ExampleContext ExampleContext { get; }

        public UserRepository(ExampleContext exampleContext)
        {
            ExampleContext = exampleContext;
        }

        public async Task<IEnumerable<UserEntity>> GetAllAsync(CancellationToken ct = default)
        {
            return await this.ExampleContext.Users
                .OrderBy(x => x.FirstName)
                .ToListAsync(ct);
        }
    }
}