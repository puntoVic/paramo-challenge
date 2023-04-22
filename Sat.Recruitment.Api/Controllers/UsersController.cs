using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Entities.Interfaces;
using Common;
using Sat.Recruitment.Api.Helpers;
using Entities;

namespace Sat.Recruitment.Api.Controllers
{
    

    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {

        private readonly List<IUser> _users = new List<IUser>();
        public UsersController()
        {
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

            
            
            try
            {
                var isDuplicated = false;
                

                if (!isDuplicated)
                {
                    Debug.WriteLine("User Created");
                   
                }
                else
                {
                    Debug.WriteLine("The user is duplicated");

                    return new Result()
                    {
                        IsSuccess = false,
                        Errors = "The user is duplicated"
                    };
                }
            }
            catch
            {
                Debug.WriteLine("The user is duplicated");
                return new Result()
                {
                    IsSuccess = false,
                    Errors = "The user is duplicated"
                };
            }

            return new Result()
            {
                IsSuccess = true,
                Errors = "User Created"
            };
        }

        
    }
    
}
