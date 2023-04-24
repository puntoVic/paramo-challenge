using System;
using System.Collections.Generic;
using System.Net;
using System.Numerics;
using System.Text;
using System.Xml.Linq;

namespace Entities.Interfaces
{
    public interface IUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public decimal Money { get; set; }

        /// <summary>
        /// Function for add gift when user is created
        /// according the amount of money
        /// </summary>
        public void AddGift();

    }
}
