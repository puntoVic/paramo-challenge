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

            

            //Normalize email
            var aux = user.Email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            user.Email = string.Join("@", new string[] { aux[0], aux[1] });

            
            try
            {
                var isDuplicated = false;
                foreach (var u in _users)
                {
                    if (u.Email == user.Email
                        ||
                        u.Phone == user.Phone)
                    {
                        isDuplicated = true;
                    }
                    else if (u.Name == user.Name)
                    {
                        if (u.Address == user.Address)
                        {
                            isDuplicated = true;
                            throw new Exception("User is duplicated");
                        }

                    }
                }

                if (!isDuplicated)
                {
                    Debug.WriteLine("User Created");

                    return new Result()
                    {
                        IsSuccess = true,
                        Errors = "User Created"
                    };
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
