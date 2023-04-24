using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IDataContext
    {
        public List<IUser> Users { get; set; }
        public Task<bool> CreateUser(IUser user);


    }
}
