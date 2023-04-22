using Data.Contracts;
using Entities;
using Entities.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Data
{
    internal class DataContext: IDataContext
    {
        public List<IUser> Users { get; set; }
        
        public DataContext()
        {
            Users = new List<IUser>();
            var reader = ReadUsersFromFile();
            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLineAsync().Result;
                var register = line.Split(',');
                IUser user = register[4] switch
                {
                    "NormalUser" => new NormalUser(),
                    "SuperUser" => new SuperUser(),
                    "Premium" => new PremiumUser(),
                    _ => null,
                };
                user.Name = line.Split(',')[0].ToString();
                user.Email = line.Split(',')[1].ToString();
                user.Phone = line.Split(',')[2].ToString();
                user.Address = line.Split(',')[3].ToString();
                user.Money = decimal.Parse(line.Split(',')[5].ToString());

                Users.Add(user);
            }
            reader.Close();
        }

        public bool IsDuplicated(IUser user)
        {
            
            return Users.Where(x => x.Email == user.Email || x.Phone == user.Phone) != null; 
        }

        public StreamReader ReadUsersFromFile()
        {
            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

            FileStream fileStream = new FileStream(path, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }
    }
}
