using System;

namespace CtlgEver.Core.Domains
{
    public class Sheet
    {
        public int Id {get; private set;}
        public string Name {get; private set;}
        public DateTime CreatedAt {get; private set;}
        public DateTime UpdatedAt {get; private set;}
        public User User {get; private set;}
    }
}