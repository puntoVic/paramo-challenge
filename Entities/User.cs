using System;

namespace Entities
{
    public class User
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
        public string UserType { get => userType; set => userType = value; }
        public decimal Money { get => money; set => money = value; }
    }
}
