using AutoMapper;
using EMPLOYEES.DAL.DataModel;
using EMPLOYEES.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMPLOYEES.Repository
{
    public class RepositoryMappingService : IRepositoryMappingService
    {
        public Mapper mapper;

        public RepositoryMappingService()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<EmployeesIbenke, EmployeesDomain>(); //smjer baza - GUI, npr. za prikazivanje zaposlenika
                    cfg.CreateMap<EmployeesDomain, EmployeesIbenke>(); //smjer GUI - baza, npr. za dodavanje zaposlenika
                });
            mapper = new Mapper(config);
        }
        public TDestination Map<TDestination>(object source)
        {
            return mapper.Map<TDestination>(source);
        }
    }
}
