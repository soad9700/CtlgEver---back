using System;
using System.Collections.Generic;

namespace CtlgEver.Core.Domains
{
    public class User
    {
        public int UserId {get; private set;}
        public string Role {get; private set;}
        public string Name {get; private set;}
        public string Surname {get; private set;}
        public string Email {get; private set;}
        public byte [] PasswordHash {get; private set;}
        public byte [] PasswordSalt {get; private set;}
        public bool Deleted { get; private set; }
        public bool Activated { get; private set; }
        public IEnumerable<Sheet> Sheets {get; private set;}
        protected User(){}
        public User(string name, string surname, string email, string password)
        {
            Role = "user";
            Name = name;
            Surname = surname;
            Email = email;
            CreatePasswordHash(password);
        }
        public void Update(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        private void CreatePasswordHash (string password) {
            using (var hmac = new System.Security.Cryptography.HMACSHA512 ()) {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash (System.Text.Encoding.UTF8.GetBytes (password));
            }
        }

    }
}