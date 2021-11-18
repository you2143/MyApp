using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyApp.Application.Users.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateEmployeeData()
        {
            const string companyA = "A";
            const string companyB = "B";
            var nowDT = DateTime.Now;

            var data = new List<EmployeeHasDate>();
            var employee = new EmployeeHasDate()
            {
                Company = companyA,
                Id = "1",
                Address = "Address1",
                GroupId = 1,
                Date = nowDT
            };
            data.Add(employee);

            for (var i = 0; i < 3; i++)
            {
                var tmp = new EmployeeHasDate()
                {
                    Company = companyA,
                    Id = "2",
                    Address = "Address2",
                    GroupId = 2,
                    Date = nowDT.AddDays(1)
                };
                data.Add(tmp);
            }

            for (var i = 0; i < 3; i++)
            {
                var tmp = new EmployeeHasDate()
                {
                    Company = companyB,
                    Id = "1",
                    Address = "Address1",
                    GroupId = 1,
                    Date = nowDT
                };
                data.Add(tmp);
            }

            //var aggregateTest = data.Aggregate(
            //    (x, y) =>
            //    {
            //        x.Address += y.Address;
            //        return x;
            //    }
            //);

            var groupData = data.GroupBy(x => new { x.Company, x.Id, x.Date });
            var aggregaetTestx1 = groupData.Select(x => x.Aggregate((y,z) =>
            {
                y.Address += z.Address;
                return y;
            }
            ));

            //var aggregateTest3 = data.GroupBy(x => new { x.Company, x.Id, x.Date }).
            //        Select(y => y.Aggregate(
            //            (z, a) =>
            //            {
            //                z.Address += z.Address;
            //                return z;
            //            }
            //            )
            //        );
            

            Console.WriteLine("OK");
        }
    }
}
