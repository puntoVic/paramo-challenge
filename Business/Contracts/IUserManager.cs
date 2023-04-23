using Common;
using Entities.Definitions;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IUserManager
    {
        public Task<Result> CreateUser(User user);
    }
}
