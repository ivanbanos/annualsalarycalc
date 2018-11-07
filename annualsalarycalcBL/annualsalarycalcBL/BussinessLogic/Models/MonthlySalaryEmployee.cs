using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace annualsalarycalcBL.BussinessLogic.Models
{
    public class MonthlySalaryEmployee : EmployeeDTO
    {

        public override float calculateAnnualSalary()
        {
            return this.salary * 12;
        }
    }
}