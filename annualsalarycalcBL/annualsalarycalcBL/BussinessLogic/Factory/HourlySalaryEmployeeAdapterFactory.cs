using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using annualsalarycalcBL.BussinessLogic.Models;
using IBDLocal.DataAccess;

namespace annualsalarycalcBL.BussinessLogic.Factory
{
    public class HourlySalaryEmployeeAdapterFactory : EmployeeAdapterFactory
    {
        public DTO create(Data data, int pos)
        {
            EmployeeDTO obj = new HourlySalaryEmployee();
            obj.id = data.getDato(pos).getIntField("id");
            obj.name = (string)data.getDato(pos).getField("name");
            obj.salary = data.getDato(pos).getFloatField("hourlySalary");
            return obj;
        }
    }
}