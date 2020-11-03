using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Labs.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SQL.Repositories;

namespace Labs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private ILogger<UserController> Logger { get; }
        private IUserRepository UserRepository { get; }

        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            Logger = logger;
            UserRepository = userRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<UserEntity>> Get(CancellationToken ct = default)
        {
            this.Logger.LogDebug($"{nameof(UserController)}.{nameof(Get)} executed");
            
            return await this.UserRepository.GetAllAsync(ct);
        }
    }
}