using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Users
{
    public class User : IEquatable<User>
    {
        private readonly string id;
        private string userName;
        private decimal number;
        public User(string id, string userName, decimal number)
        {
            this.id = id;
            this.userName = userName;
            this.number = number;
        }

        public string Id
        {
            get { return id; }
        }

        public string UserName
        {
            get { return userName; }
        }

        public decimal Number
        {
            get { return number; }
        }

        public void ChangeUserName(string newName)
        {
            if (newName == null) throw new ArgumentNullException(nameof(newName));
            userName = newName;
        }

        public bool Equals(User other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(id, other.id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User)obj);
        }

        public override int GetHashCode()
        {
            return (id != null ? id.GetHashCode() : 0);
        }
    }
}
