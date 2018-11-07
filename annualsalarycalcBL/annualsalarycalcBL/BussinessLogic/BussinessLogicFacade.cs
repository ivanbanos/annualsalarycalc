using annualsalarycalcBL.BussinessLogic.Factory;
using annualsalarycalcBL.BussinessLogic.Models;
using IBDLocal.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace annualsalarycalcBL.BussinessLogic
{
    public class BussinessLogicFacade
    {
        public List<EmployeeDTO> getEmployees() {
            var employees = new List<EmployeeDTO>();

            var data = new DataAccessFacade().executeRequest(1,
                ConfigurationManager.AppSettings["Method"],
                new List<Parameter>(),
                ConfigurationManager.AppSettings["ApiUrl"]);
            var roleAdapter = AdapterCreator.getInstance().getFactory("Role");
            Adapter employeeAdapter;
            for (var i = 0; i < data.Count(); i++)
            {
                var role = (RoleDTO)roleAdapter.create(data, i);
                if (data.getDato(i).getStringField("contractTypeName") == "HourlySalaryEmployee") {
                    employeeAdapter = AdapterCreator.getInstance().getFactory("HourlyEmployee");
                } else {
                    employeeAdapter = AdapterCreator.getInstance().getFactory("MonthlyEmployee");
                }
                var employee = (EmployeeDTO)employeeAdapter.create(data, i);
                employee.role = role;
                employees.Add(employee);
            }
            return employees;
        }

        public EmployeeDTO getEmployee(int id) {
            var employees = getEmployees();
            foreach(var employee in employees)
            {
                if (employee.id == id) {
                    return employee;
                }
            }
            return new NullEmployeeDTO();
        }
    }
}