using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace annualsalarycalcBL.BussinessLogic.Models
{
    public abstract class EmployeeDTO : DTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public float salary { get; set; }
        public RoleDTO role { get; set; }
    }
}