using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using annualsalarycalcBL.BussinessLogic.Models;
using IBDLocal.DataAccess;

namespace annualsalarycalcBL.BussinessLogic.Factory
{
    public class MonthlySalaryEmployeeAdapterFactory : EmployeeAdapterFactory
    {
        public DTO create(Data data, int pos)
        {
            EmployeeDTO obj = new MonthlySalaryEmployee();
            obj.id = data.getDato(pos).getIntField("id");
            obj.name = (string)data.getDato(pos).getField("name");
            obj.salary = data.getDato(pos).getFloatField("monthlySalary");
            return obj;
        }
    }
}