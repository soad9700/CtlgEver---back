using System;

namespace CtlgEver.Core.Domains
{
    public class User
    {
        public int Id {get; private set;}
        public string Role {get; private set;}
        public string Name {get; private set;}
        public string Surname {get; private set;}
        public string Email {get; private set;}
        public string Password {get; private set;}
        public byte [] PasswordHash {get; private set;}
        public byte [] PasswordSalt {get; private set;}
        public bool Deleted { get; private set; }
        public bool Activated { get; private set; }
        protected User(){}
        public User(string role, string name, string surname, string email, string password)
        {
            Role = role;
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
        }

    }
}