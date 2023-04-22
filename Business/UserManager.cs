using Business.Contracts;
using Common;
using Data.Contracts;
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

        public async Task<Result> CreateUser(IUser user)
        {
            if (await userDataAccess.CreateUser(user) == null)
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
    }
}
