using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace annualsalarycalcBL.BussinessLogic.Models
{
    public class HourlySalaryEmployee : EmployeeDTO
    {

        public override float calculateAnnualSalary()
        {
            return 120 * this.salary * 12;
        }
    }
}