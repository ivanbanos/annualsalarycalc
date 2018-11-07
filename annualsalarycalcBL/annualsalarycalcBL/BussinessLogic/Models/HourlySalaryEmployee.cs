using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace annualsalarycalcBL.BussinessLogic.Models
{
    public class HourlySalaryEmployee : EmployeeDTO
    {
        public new float salary { get { return 120 * base.salary * 12; } }
    }
}