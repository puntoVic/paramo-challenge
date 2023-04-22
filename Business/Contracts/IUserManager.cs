using Common;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Contracts
{
    public interface IUserManager
    {
        public Result CreateUser(IUser user);
    }
}
