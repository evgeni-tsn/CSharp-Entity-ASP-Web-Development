using _02.ADO.NET_MiniORM.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ADO.NET_MiniORM.Entities
{
    [Entity(TableName = "Users")]
    class User
    {
        [Id]
        private int id;

        [Column(ColumnName = "Username")]
        private string username;

        [Column(ColumnName = "Password")]
        private string password;

        [Column(ColumnName = "Age")]
        private int age;

        [Column(ColumnName = "Username")]
        private DateTime registrationDate;

        public DateTime RegistrationDate
        {
            get
            {
                return registrationDate;
            }

            set
            {
                registrationDate = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public User(string username, string password, int age, DateTime registrationDate)
        {
            this.Username = username;
            this.Password = password;
            this.Age = age;
            this.RegistrationDate = registrationDate;
        }


    }
}
