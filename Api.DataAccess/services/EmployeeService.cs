using System;
using System.Collections.Generic;
using Api.BusinessLogic.contracts;
using Api.DataAccess.Repositories;
using Api.model.EntityModel;

namespace Api.DataAccess.services
{
    public class EmployeeService : IService<Employee>
    {
        private EmployeeRepository empRepository;

        public EmployeeService()
        {
            empRepository = new EmployeeRepository();
        }

      

        public bool Add(Employee entity)
        {
            return empRepository.Add(entity);
        }


        public bool Remove(long id)
        {
            throw new NotImplementedException();
        }

        public Employee Get(long id)
        {
            return empRepository.Get(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return empRepository.GetAll();
        }

 

    

        public bool Remove(Employee entity)
        {
           

            return empRepository.Remove(entity);
        }


      


        public bool Update(Employee entity)
        {
            return empRepository.Update(entity);
        }

      
     



    }
}
