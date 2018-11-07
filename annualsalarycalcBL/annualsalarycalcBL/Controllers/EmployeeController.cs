using annualsalarycalcBL.BussinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace annualsalarycalcBL.Controllers
{
    public class EmployeeController : ApiController
    {
        
        public List<EmployeeDTO> Get()
        {
            return BussinessLogicComsumer.getInstance().facade.getEmployees();
        }
        
        public EmployeeDTO Get(int id)
        {
            var employee= BussinessLogicComsumer.getInstance().facade.getEmployee(id);
            if (employee.id != 0)
            {
                return employee;
            }
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
    }
}
