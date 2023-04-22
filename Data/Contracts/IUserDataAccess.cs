using Common;
using Entities.Interfaces;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IUserDataAccess
    {
        public Task<IUser> CreateUser(IUser user);
    }
}
