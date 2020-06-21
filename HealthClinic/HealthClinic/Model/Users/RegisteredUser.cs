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
        private String[] password;
        private String photo;
        public Residence residence; //TODO: Proveriti da li da pravimo properti za ovo ?, posto se to ne moze izgenerisati u PD, a treba nam properti ?


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

        public String[] Password
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

        public String Photo
        {
            get
            {
                return photo;
            }
            set
            {
                this.photo = value;
                OnPropertyChanged("Photo");
            }
        }

        


    }
}