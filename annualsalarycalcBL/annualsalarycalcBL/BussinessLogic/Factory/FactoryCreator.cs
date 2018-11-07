using annualsalarycalcBL.BussinessLogic.Factory.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace annualsalarycalcBL.BussinessLogic.Factory
{
    public class FactoryCreator
    {
        private static FactoryCreator instance;

        private FactoryCreator() { }
        public Factory getFactory(string modelo)
        {
            Factory factory;
            switch (modelo)
            {
                case "MonthlyEmployee":
                    factory = new MonthlySalaryEmployeeFactory();
                    break;
                case "HourlyEmployee":
                    factory = new HourlySalaryEmployeeFactory();
                    break;
                case "Role":
                    factory = new RoleFactory();
                    break;
                default:

                    throw new NonExistingModelException();
            }
            return factory;
        }

        public static FactoryCreator getInstance()
        {
            if (instance == null)
            {
                instance = new FactoryCreator();
            }
            return instance;
        }
    }
}