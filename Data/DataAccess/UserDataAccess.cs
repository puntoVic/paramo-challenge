using Common;
using Common.Helpers;
using Data.Contracts;
using Entities.Interfaces;
using System;

namespace Data.DataAccess
{
    internal class UserDataAccess : IUserDataAccess
    {
        private readonly IDataContext dataContext;

        public UserDataAccess(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public IUser CreateUser(IUser user)
        {
            if (dataContext.IsDuplicated(user))
            {
                return null;
            }
            user.Email = EmailValidations.NormalizeEmail(user.Email);
            user.AddGift();
            return user;

        }
    }
}
