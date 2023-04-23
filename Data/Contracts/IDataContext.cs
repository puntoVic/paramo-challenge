using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Data.Contracts
{
    public interface IDataContext
    {
        public List<IUser> Users { get; set; }
        public bool IsDuplicated(IUser user);
        public StreamReader ReadUsersFromFile();
        
    }
}
