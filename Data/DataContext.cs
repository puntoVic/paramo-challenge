using Data.Contracts;
using Entities;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class DataContext: IDataContext
    {
        readonly string path = string.Empty;
        readonly FileStream fileStream;
        readonly StreamReader reader;

        public List<IUser> Users { get; set; }

        /// <summary>
        /// DataConntext constructo
        /// </summary>
        /// <param name="pathFile">
        /// the path to find the Data File
        /// </param>
        public DataContext(string pathFile)
        {
            try
            {
                Users = new List<IUser>();
                path = Directory.GetCurrentDirectory() + pathFile;
                fileStream = new FileStream(path, FileMode.Open);
                reader = new StreamReader(fileStream);
                InitUserList();
                reader?.Close();
                fileStream?.Close();
            }
            catch (Exception)
            {
                Users = null;
            }
        }

        /// <summary>
        /// Function to add an user in Data File
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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
        
        private async Task<bool> WriteUsersInFile(IUser user)
        {
            try
            {
                var newUser = typeof(IUser).GetProperties().Select(x => x.GetValue(user).ToString()).ToArray();
                string newLine = string.Join(',', newUser);


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
            
            catch (Exception)
            {
                return false;
            }
        }

        private void InitUserList()
        {
            while (reader?.Peek() >= 0)
            {
                var line = reader.ReadLineAsync().Result;
                var register = line.Split(',');
                IUser user = register[4].ToLower() switch
                {
                    "normal" => new NormalUser(),
                    "superuser" => new SuperUser(),
                    "premium" => new PremiumUser(),
                    _ => null,
                };
                user.Name = line.Split(',')[0].ToString();
                user.Email = line.Split(',')[1].ToString();
                user.Phone = line.Split(',')[2].ToString();
                user.Address = line.Split(',')[3].ToString();
                user.Money = decimal.Parse(line.Split(',')[5].ToString());

                Users.Add(user);
            }
        }
    }
}
