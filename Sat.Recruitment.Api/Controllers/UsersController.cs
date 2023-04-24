using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Entities.Interfaces;
using Common;
using Common.Helpers;
using Business.Contracts;
using Entities.Definitions;

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

        /// <summary>
        /// API to create an user
        /// </summary>
        /// <param name="user">Model tu set user params</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser(UserDefinition user)
        {
            
            var errors = Validator.ValidateUser(user);

            if (errors != "")
                return new Result()
                {
                    IsSuccess = false,
                    Errors = errors
                };

            return await userManager.CreateUser(user);
            
        }

        
    }
    
}
