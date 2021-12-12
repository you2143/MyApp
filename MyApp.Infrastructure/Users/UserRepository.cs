using MyApp.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Users
{
    class UserRepository : RepositoryBase, IUserRepository
    {
        public User Find(string id)
        {
            var sql = @"SELECT * FROM USER WHERE ID = :ID";
            var parameter = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string,object>("iD",id),
            };

            var reader = this.ExecuteReader(sql, parameter);
            if (reader.Read())
            {
                return new User(
                    reader[""] as string,
                    reader[""] as string,
                    0);
            }
            return null;
        }

        public IEnumerable<User> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(User user)
        {
            throw new NotImplementedException();
        }

        public void Save(User user)
        {
            throw new NotImplementedException();
        }
    }
}
