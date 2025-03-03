﻿using Entities;
using Entities.Definitions;
using Entities.Interfaces;

namespace Common.Helpers
{
    public static class Validator
    {
        /// <summary>
        /// Function to validate the user sent in API
        /// </summary>
        public static string ValidateUser(UserDefinition user)
        {
            string errors = string.Empty;
            if (user.Name == null)
                //Validate if Name is null
                errors = "The name is required";
            if (user.Email == null)
                //Validate if Email is null
                errors += " The email is required";
            if (user.Address == null)
                //Validate if Address is null
                errors += " The address is required";
            if (user.Phone == null)
                //Validate if Phone is null
                errors += " The phone is required";
            return errors;
        }

    }
}
