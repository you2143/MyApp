using MyApp.Application.Users.Data;
using MyApp.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Users
{
    public class UserApplicationService
    {
        public IEnumerable<UserData> GetAllUserData()
        {
            var data = new List<User>();
            var user = new User("1", "", -1);
            data.Add(user);

            for (var i = 0; i < 10000; i++)
            {
                var tmp = new User(i.ToString(), "あああ" + i, i);
                data.Add(tmp);
            }

            return data.Select(x => new UserData(x));
        }
    }
}
