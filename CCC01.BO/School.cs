using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC01.BO
{
    public class School
    {
        private static int count = 0;
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }

        public School()
        {
            count++;
        }

        public School(string email, string name, string contact) : this()
        {
            Id = count;
            Email = email;
            Name = name;
            Contact = contact;
        }

        public School(int id, string email, string name, string contact):
            this(email, name, contact)
        {
            Id = id;
        }

        public override bool Equals(object obj)
        {
            return obj is School school &&
                   Id == school.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
