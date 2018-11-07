using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using annualsalarycalcBL.BussinessLogic.Models;
using IBDLocal.DataAccess;

namespace annualsalarycalcBL.BussinessLogic.Factory
{
    public class HourlySalaryEmployeeFactory : EmployeeFactory
    {
        public DTO create(Data data, int pos)
        {
            EmployeeDTO obj = new HourlySalaryEmployee();
            obj.id = (int)data.getDato(pos).getField("roleId");
            obj.name = (string)data.getDato(pos).getField("roleName");
            obj.salary = (float)data.getDato(pos).getField("hourlySalary");
            return obj;
        }
    }
}