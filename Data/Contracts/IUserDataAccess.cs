using Common;
using Entities.Interfaces;


namespace Data.Contracts
{
    public interface IUserDataAccess
    {
        public IUser CreateUser(IUser user);
    }
}
