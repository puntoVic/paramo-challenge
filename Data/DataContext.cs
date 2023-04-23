using Data.Contracts;
using Entities;
using Entities.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class DataContext: IDataContext
    {
        public List<IUser> Users { get; set; }

        readonly string path = string.Empty;

        public DataContext(string pathFile)
        {
            path = Directory.GetCurrentDirectory() + pathFile;
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

        public async Task<bool> CreateUser(IUser user)
        {
            try
            {
                Users.Add(user);
                await WriteUsersInFile(user);
                return true;
            }
            catch { return false; }

        }

        public bool IsDuplicated(IUser user)
        {
            
            return Users.Where(x => x.Email == user.Email || x.Phone == user.Phone) != null; 
        }

        public StreamReader ReadUsersFromFile()
        {
            FileStream fileStream = new FileStream(path, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }

        private async Task<bool> WriteUsersInFile(IUser user)
        {

            try
            {
                var newUser = typeof(IUser).GetProperties().Select(x => x.GetValue(user).ToString()).ToArray();
                string newLine = string.Join(',', newUser);

                FileStream fileStream = new FileStream(path, FileMode.Open);

                StreamReader reader = new StreamReader(fileStream);
                string[] lines = await File.ReadAllLinesAsync(path);
                var linesList = new List<string>(lines)
                {
                    newLine
                };
                lines = linesList.ToArray();

                await File.WriteAllLinesAsync(path, lines);
                reader.Close();
                fileStream.Close();
                return true;
            } 
            
            catch {
                return false;
            }


        }
    }
}
