using Business.Contracts;
using Common;
using Data.Contracts;
using Entities;
using Entities.Definitions;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UserManager: IUserManager
    {
        private readonly IUserDataAccess userDataAccess;

        public UserManager(IUserDataAccess userDataAccess)
        {
            this.userDataAccess = userDataAccess;
        }

        public async Task<Result> CreateUser(User user)
        {
            try
            {
                if (user == null)
                {
                    return new Result()
                    {
                        IsSuccess = false,
                        Errors = "The user is invalid"
                    };
                }
                IUser newUser = user.Type.ToLower() switch
                {
                    "normal" => new NormalUser(),
                    "nuperUser" => new SuperUser(),
                    "premium" => new PremiumUser(),
                    _ => null,
                };
                newUser.Name = user.Name;
                newUser.Email = user.Email;
                newUser.Address = user.Address;
                newUser.Phone = user.Phone;
                newUser.Type = user.Type;
                newUser.Money = user.Money;

                if (await userDataAccess.CreateUser(newUser) == null)
                {
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
            catch
            {
                return new Result()
                {
                    IsSuccess = false,
                    Errors = "invalid user"
                };
            }
            
        }
    }
}
