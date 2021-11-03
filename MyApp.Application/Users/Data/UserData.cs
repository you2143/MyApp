using MyApp.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Users.Data
{
    public class UserData
    {
        private readonly string id;
        private string userName;
        private decimal number;

        public UserData(User user)
        {
            this.id = user.Id;
            this.userName = user.UserName;
            this.number = user.Number;
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
    }
}
