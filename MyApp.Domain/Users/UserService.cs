using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Users
{
    class UserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public bool IsDuplicated(User user)
        {
            var id = user.Id;
            var searched = userRepository.Find(id);

            return searched != null;
        }
    }
}
