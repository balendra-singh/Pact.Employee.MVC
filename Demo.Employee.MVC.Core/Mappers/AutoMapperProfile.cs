using AutoMapper;
using Demo.Employee.MVC.Core.Infrastructure;
using Demo.Employee.MVC.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Employee.MVC.Core.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Db entity to view model mapping
            CreateMap<EmployeeEntity, EmployeeModel>();

            //View model to Db entity model
            CreateMap<EmployeeModel,EmployeeEntity>();
        }
    }
}
