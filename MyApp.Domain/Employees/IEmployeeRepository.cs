using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Employees
{
    public interface IEmployeeRepository
    {
        Employee Find(string id);
        IEnumerable<Employee> FindAll();
        void Save(Employee employee);
    }
}
