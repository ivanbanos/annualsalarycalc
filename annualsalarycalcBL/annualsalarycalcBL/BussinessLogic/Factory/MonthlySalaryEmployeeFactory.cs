using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using annualsalarycalcBL.BussinessLogic.Models;
using IBDLocal.DataAccess;

namespace annualsalarycalcBL.BussinessLogic.Factory
{
    public class MonthlySalaryEmployeeFactory : EmployeeFactory
    {
        public DTO create(Data data, int pos)
        {
            EmployeeDTO obj = new MonthlySalaryEmployee();
            obj.id = (int)data.getDato(pos).getField("roleId");
            obj.name = (string)data.getDato(pos).getField("roleName");
            obj.description = (string)data.getDato(pos).getField("roleDescription");
            return obj;
        }
    }
}