using MyApp.Common;
using MyApp.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MyApp.Application.Employees
{    
    public class EmployeeApplication
    {
        private IEmployeeRepository EmployeeRepository;
        public EmployeeApplication(IEmployeeRepository employeeRepository)
        {
            EmployeeRepository = employeeRepository;
        }

        [Logger]
        public Employee GetEmployee(string id)
        {
            var data = this.EmployeeRepository.Find(id);
            var address = new Encrypter().Decrypt(data.EncryptAddress);
            var Bithdate = new Encrypter().Decrypt(data.EncryptBirthdate);
            return data;
        }

        [Logger]
        public IEnumerable<Employee> GetAllEmployee()
        {
            System.Threading.Thread.Sleep(5000);
            var data = this.EmployeeRepository.FindAll();
            return data;
        }

        [Logger]
        public void CreateEmployee(string id)
        {
            using (var transaction = new TransactionScope())
            {
                var employee = new Employee()
                {
                    Id = id,
                    Name = "Name",
                    Address = new String('a' ,16),
                    Birthdate = DateTime.Now
                };

                Console.WriteLine($"Init:");

                employee.EncryptAddress = new Encrypter().Encrypt(employee.Address);
                employee.EncryptBirthdate = new Encrypter().Encrypt(employee.Birthdate.ToString());

                this.EmployeeRepository.Save(employee);

                transaction.Complete();
            }
        }
    }
}
