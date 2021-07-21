using AutoMapper;
using Demo.Employee.MVC.Core.Infrastructure;
using Demo.Employee.MVC.Core.Models;
using Demo.Employee.MVC.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Employee.MVC.Core.Repository.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IMapper mapper;
        private readonly EmployeeDbContext employeeDbContext;

        public EmployeeRepository(IMapper mapper, EmployeeDbContext employeeDbContext)
        {
            this.mapper = mapper;
            this.employeeDbContext = employeeDbContext;
        }

        public WebResponseModel<EmployeeModel> AddEmployee(EmployeeModel employeeModel)
        {

            EmployeeEntity employeeEntity = mapper.Map<EmployeeEntity>(employeeModel);

            employeeDbContext.EmployeeEnties.Add(employeeEntity);
            employeeDbContext.SaveChanges();

            return new WebResponseModel<EmployeeModel>
            {
                ErrorMessage = "Record added",
                ResponseData = mapper.Map<EmployeeModel>(employeeEntity)       //Send the updated model with data from db entites with newly created employee code 
            };
        }
       
        public List<EmployeeModel> GetAllEmployees()
        {
            var employeeRecordList = new List<EmployeeModel>();

            var employeDbRecords = employeeDbContext.EmployeeEnties.AsEnumerable();

            foreach (var employeeRecord in employeDbRecords)
            {
                employeeRecordList.Add(mapper.Map<EmployeeModel>(employeeRecord));
            }

            return employeeRecordList;
        }

        public EmployeeModel GetEmployee(int employeeNumber)
        {
            var employeRecord = employeeDbContext.EmployeeEnties.Where(e => e.EmployeeNumber == employeeNumber).FirstOrDefault();
            if (employeRecord is null)
                return null;

            return mapper.Map<EmployeeModel>(employeRecord);

        }

        public WebResponseModel<EmployeeModel> UpdateEmployee(EmployeeModel updatedEmployeeModel)
        {
            var employeRecordToUpdate = employeeDbContext.EmployeeEnties.Where(e => e.EmployeeNumber == updatedEmployeeModel.EmployeeNumber).FirstOrDefault();
            if (employeRecordToUpdate is null)
                return new WebResponseModel<EmployeeModel>
                {
                    ErrorMessage = "Record not found",
                };

            employeRecordToUpdate.Name =updatedEmployeeModel.Name;
            employeRecordToUpdate.DateOfBirth = updatedEmployeeModel.DateOfBirth;
            employeRecordToUpdate.EmployeeNumber = updatedEmployeeModel.EmployeeNumber;
            employeRecordToUpdate.JobProfileId = updatedEmployeeModel.JobProfileId;
            employeRecordToUpdate.PhoneNumber = updatedEmployeeModel.PhoneNumber;
            employeRecordToUpdate.AddressLine1 = updatedEmployeeModel.AddressLine1;
            employeRecordToUpdate.AddressLine2 = updatedEmployeeModel.AddressLine2;
            employeRecordToUpdate.City = updatedEmployeeModel.City;
            employeRecordToUpdate.PinCode = updatedEmployeeModel.PinCode;
            employeRecordToUpdate.Status = updatedEmployeeModel.Status;

            employeeDbContext.SaveChanges();

            return new WebResponseModel<EmployeeModel>
            {
                ErrorMessage = "Record updated",
                ResponseData = updatedEmployeeModel
            };
        }

        public WebResponseModel<bool> ToggleEmployeeStatus(int employeeNumber)
        {
            var employeRecordToUpdate = employeeDbContext.EmployeeEnties.Where(e => e.EmployeeNumber == employeeNumber).FirstOrDefault();

            if (employeRecordToUpdate is null)
                return new WebResponseModel<bool>
                {
                    ErrorMessage = "Record not found",
                };

            if (employeRecordToUpdate.Status)
                employeRecordToUpdate.Status = false;
            else
                employeRecordToUpdate.Status = true;

            employeeDbContext.SaveChanges();

            return new WebResponseModel<bool>
            {
                ErrorMessage = "Record updated",                
            };
        }

        public bool IsEmployeeNumberPresent(int employeeNumber)
        {
            return employeeDbContext.EmployeeEnties.Where(e => e.EmployeeNumber == employeeNumber).Any();           
        }
    }
}
