using MyApp.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Users.Data
{
    public class EmployeeHasDate
    {
        public string Company { get; set; }

        public string Id { get; set; }

        public DateTime Date { get; set; }

        public string Address { get; set; }

        public decimal GroupId { get; set; }
    }
}
