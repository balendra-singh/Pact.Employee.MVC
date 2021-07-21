using AutoMapper;
using AutoMapper.Configuration;
using Demo.Employee.MVC.Core.Infrastructure;
using Demo.Employee.MVC.Core.Mappers;
using Demo.Employee.MVC.Core.Models;
using Demo.Employee.MVC.Core.Repository.Implementations;
using Demo.Employee.MVC.Core.Repository.Interfaces;
using Demo.Employee.MVC.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Demo.Employee.MVC.Tests
{
    public class EmployeeCRUDTests
    {
        private readonly EmployeeDbContext employeeDbContext;
        private readonly IEmployeeRepository empRepoMoq;
        private readonly IMapper mapperMoq;
        private int empNumberToTest = 210;

        public EmployeeCRUDTests()
        {
            if (mapperMoq is null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapperProfile());
                });

                mapperMoq = mappingConfig.CreateMapper();
            }

            employeeDbContext = new EmployeeDbContext("server=127.0.0.1;Port=3306;User Id=root;database=EmployeeDb;password=root;charset=utf8;Connect Timeout=5");
            empRepoMoq = new EmployeeRepository(mapperMoq, employeeDbContext);
        }

        [Fact]
        public void GetEmployeeById_Should_Be_Equal_To_The_EmployeeNumber()
        {
            EmployeeController emp = new EmployeeController(empRepoMoq);
            var result = emp.GetEmployee(empNumberToTest);
            var resultObject = Assert.IsType<JsonResult>(result);

            dynamic resultData = new JsonResultDynamicWrapper(resultObject);

            Assert.Equal(1, Convert.ToInt32(resultData.EmployeeId));
        }

        [Fact]
        public void UpdateEmployee_Should_Update_Entries_In_Db()
        {

            var employeeModelToTest = new EmployeeModel
            {
                EmployeeId = 1,
                Name = "Updated Name",
                DateOfBirth = DateTime.UtcNow.AddYears(-21),
                EmployeeNumber = 210,
                JobProfileId = (int)JobProfileEnum.Manager,
                PhoneNumber = "9112354687",
                AddressLine1 = "Updated Add 1",
                AddressLine2 = "Updated Add 2",
                City = "Updated City",
                PinCode = "897456",
                Status = true,
            };


            EmployeeController emp = new EmployeeController(empRepoMoq);
            emp.UpdateEmployee(employeeModelToTest);

            var result = emp.GetEmployee(empNumberToTest);
            var resultObject = Assert.IsType<JsonResult>(result);
            dynamic resultData = new JsonResultDynamicWrapper(resultObject);

            Assert.Equal(employeeModelToTest.Name, Convert.ToString(resultData.Name));  //updated employee name shall match
            Assert.True(Convert.ToBoolean(resultData.Status)); //Employee Should be active
            Assert.InRange<DateTime>(Convert.ToDateTime(resultData.DateOfBirth), DateTime.UtcNow.AddYears(-60), DateTime.UtcNow.AddYears(-18));   //employee must be between 18 to 60 years of age
        }

        [Fact]
        public void UpdateEMployeeStatus_Should_Toggle_Status_In_Db()
        {
            EmployeeController emp = new EmployeeController(empRepoMoq);
            //before status update
            var result = emp.GetEmployee(empNumberToTest);
            var resultObject = Assert.IsType<JsonResult>(result);
            dynamic resultData = new JsonResultDynamicWrapper(resultObject);
            bool beforeUpdateStatus = resultData.Status;

            emp.UpdateEmployeeStatus(empNumberToTest);

            //after status update
            result = emp.GetEmployee(empNumberToTest);
            resultObject = Assert.IsType<JsonResult>(result);
            resultData = new JsonResultDynamicWrapper(resultObject);
            bool afterUpdateStatus = resultData.Status;

            Assert.NotEqual<bool>(beforeUpdateStatus, afterUpdateStatus);// should not be equal
        }
    }
}
