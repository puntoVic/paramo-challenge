using Business.Contracts;
using Common;
using Common.Helpers;
using Data.Contracts;
using Entities;
using Entities.Definitions;
using Entities.Interfaces;
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

        /// <summary>
        /// Function to manager the user creation and results
        /// </summary>
        public async Task<Result> CreateUser(UserDefinition user)
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
                
                IUser newUser = DefinitionHelper.ToUser(user);
                

                if (userDataAccess.IsDuplicated(newUser))
                {
                    return new Result()
                    {
                        IsSuccess = false,
                        Errors = "The user is duplicated"
                    };
                }

                newUser.Email = EmailValidations.NormalizeEmail(newUser.Email);
                newUser.AddGift();

                if (await userDataAccess.CreateUser(newUser) == null)
                {
                    return new Result()
                    {
                        IsSuccess = false,
                        Errors = "There is an error creating user"
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
                    Errors = "There is an error creating user"
                };
            }
            
        }
    }
}
