// File:    Person.cs
// Author:  Vaxi
// Created: Wednesday, April 1, 2020 9:45:03 PM
// Purpose: Definition of Class Person

using System;

namespace Model.Users
{
    public class Person
    {
        private string name;
        private string surname;
        private int id;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                this.surname = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                this.id = value;
            }
        }

    }
}