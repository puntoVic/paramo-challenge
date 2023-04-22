using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class PremiumUser : IUser
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
        public decimal Money { get => money; set => money = value; }

        public void AddGift()
        {
            if (Money > 100)
            {
                var gif = Money * 2;
                Money += gif;
            }
        }
    }
}
