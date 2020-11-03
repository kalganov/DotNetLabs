using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Labs.Entities;

namespace SQL.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntity>> GetAllAsync(CancellationToken ct = default);
    }
}