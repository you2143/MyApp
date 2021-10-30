using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Users
{
    public interface IUserRepository
    {
        User Find(string id);
        IEnumerable<User> FindAll();
        void Save(User user);
        void Remove(User user);
    }
}
