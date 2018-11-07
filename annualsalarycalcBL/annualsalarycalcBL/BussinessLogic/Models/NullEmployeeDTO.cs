using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace annualsalarycalcBL.BussinessLogic.Models
{
    public class NullEmployeeDTO : EmployeeDTO
    {
        public NullEmployeeDTO() {
            this.id = 0;
        }
    }
}