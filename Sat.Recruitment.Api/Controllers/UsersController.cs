using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Entities.Interfaces;
using Common;
using Common.Helpers;
using Business.Contracts;

namespace Sat.Recruitment.Api.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {

        private readonly IUserManager userManager;
        public UsersController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser(IUser user)
        {
            var errors = Validator.ValidateUser(user);

            if (errors != "")
                return new Result()
                {
                    IsSuccess = false,
                    Errors = errors
                };

            return userManager.CreateUser(user);
            
        }

        
    }
    
}
