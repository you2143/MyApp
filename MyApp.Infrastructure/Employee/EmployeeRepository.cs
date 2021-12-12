using MyApp.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Employees
{
    public class EmployeeRepository : RepositoryBase, IEmployeeRepository
    {
        public Employee Find(string id)
        {
            var sql = @"SELECT 
                            ID, 
                            NAME, 
                            BIRTHDATE,
                            ADDRESS, 
                            ENCRYPT_BIRTHDATE, 
                            ENCRYPT_ADDRESS 
                        FROM 
                            EMPLOYEE WHERE ID = :ID";
            var parameter = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string,object>("ID",id),
            };

            var reader = this.ExecuteReader(sql, parameter);
            if (reader.Read())
            {
                return new Employee()
                {
                    Id = reader["ID"] as string,
                    Name = reader["NAME"] as string,
                    Birthdate = Convert.ToDateTime(reader["BIRTHDATE"]),
                    Address = reader["ADDRESS"] as string,
                    EncryptBirthdate = reader["ENCRYPT_BIRTHDATE"] as byte[],
                    EncryptAddress = reader["ENCRYPT_ADDRESS"] as byte[]
                };
            }
            return null;
        }

        public IEnumerable<Employee> FindAll()
        {
            var sql = @"SELECT 
                            ID, 
                            NAME, 
                            BIRTHDATE,
                            ADDRESS, 
                            ENCRYPT_BIRTHDATE, 
                            ENCRYPT_ADDRESS
                        FROM 
                            EMPLOYEE";

            var reader = this.ExecuteReader(sql);
            var list = new List<Employee>();
            while (reader.Read())
            {
                var employee = new Employee()
                {
                    Id = reader["ID"] as string,
                    Name = reader["NAME"] as string,
                    Birthdate = Convert.ToDateTime(reader["BIRTHDATE"]),
                    Address = reader["ADDRESS"] as string,
                    EncryptBirthdate = reader["ENCRYPT_BIRTHDATE"] as byte[],
                    EncryptAddress = reader["ENCRYPT_ADDRESS"] as byte[]
                };
                list.Add(employee);
            }
            return list;
        }

        public void Save(Employee employee)
        {
            var sql = @"INSERT INTO EMPLOYEE ( 
                            ID, 
                            NAME, 
                            BIRTHDATE,
                            ADDRESS, 
                            ENCRYPT_BIRTHDATE, 
                            ENCRYPT_ADDRESS 
                        ) VALUES (
                            :ID, 
                            :NAME, 
                            :BIRTHDATE,
                            :ADDRESS, 
                            :ENCRYPT_BIRTHDATE, 
                            :ENCRYPT_ADDRESS 
                        )";
            var parameter = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string,object>("ID",employee.Id),
                new KeyValuePair<string,object>("NAME",employee.Name),
                new KeyValuePair<string,object>("BIRTHDATE",employee.Birthdate),
                new KeyValuePair<string,object>("ADDRESS",employee.Address),
                new KeyValuePair<string,object>("ENCRYPT_BIRTHDATE",employee.EncryptBirthdate),
                new KeyValuePair<string,object>("ENCRYPT_ADDRESS",employee.EncryptAddress),
            };

            this.ExecuteNonQuery(sql, parameter);
        }
    }
}
