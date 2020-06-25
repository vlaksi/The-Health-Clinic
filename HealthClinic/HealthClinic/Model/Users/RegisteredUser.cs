// File:    RegisteredUser.cs
// Author:  Vaxi
// Created: Wednesday, April 1, 2020 9:43:16 PM
// Purpose: Definition of Class RegisteredUser

using System;

namespace Model.Users
{
    public class RegisteredUser : Person
    {
        private String username;
        private String password;


        public String Username
        {
            get
            {
                return username;
            }
            set
            {
                this.username = value;
                OnPropertyChanged("Username");
            }
        }

        public String Password
        {
            get
            {
                return password;
            }
            set
            {
                this.password = value;
                OnPropertyChanged("Password");
            }
        }

    }
}