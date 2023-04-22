using Entities.Interfaces;
using System;

namespace Entities
{
    public class NormalUser: IUser
    {

        private string name;
        private string email;
        private string address;
        private string phone;
        private string userType;
        private decimal money;

        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Type { get => userType; set => userType = value; }
        public decimal Money { get => money; set => money = value; }
       
        public void AddGift()
        {
            if (Money > 100)
            {
                var percentage = Convert.ToDecimal(0.12);
                var gif = Money * percentage;
                Money += gif;
            }
            if (Money < 100)
            {
                if (Money > 10)
                {
                    var percentage = Convert.ToDecimal(0.8);
                    var gif = Money * percentage;
                    Money += gif;
                }
            }
        }
    }
}
