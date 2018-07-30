using System;

namespace CtlgEver.Core.Domains
{
    public class Sheet
    {
        public int SheetId {get; private set;}
        public string Name {get; private set;}
        public DateTime CreatedAt {get; private set;}
        public DateTime UpdatedAt {get; private set;}
        public User User {get; private set;}

        protected Sheet (){}
        public Sheet (string name)
        {
            Name = name;
            CreatedAt = DateTime.UtcNow;
        }

        public void Update(string name)
        {
            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}