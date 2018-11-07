using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace annualsalarycalcBL.BussinessLogic.Models
{
    public class RoleDTO : DTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}