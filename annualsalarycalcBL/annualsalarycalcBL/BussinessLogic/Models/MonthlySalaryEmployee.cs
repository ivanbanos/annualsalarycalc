using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace annualsalarycalcBL.BussinessLogic.Models
{
    public class MonthlySalaryEmployee : EmployeeDTO
    {

        public new float salary { get { return base.salary * 12; } }
    }
}