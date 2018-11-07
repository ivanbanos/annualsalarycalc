using annualsalarycalcBL.BussinessLogic.Factory.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace annualsalarycalcBL.BussinessLogic.Factory
{
    public class AdapterCreator
    {
        private static AdapterCreator instance;

        private AdapterCreator() { }
        public Adapter getFactory(string modelo)
        {
            Adapter factory;
            switch (modelo)
            {
                case "MonthlyEmployee":
                    factory = new MonthlySalaryEmployeeAdapterFactory();
                    break;
                case "HourlyEmployee":
                    factory = new HourlySalaryEmployeeAdapterFactory();
                    break;
                case "Role":
                    factory = new RoleAdapter();
                    break;
                default:

                    throw new NonExistingModelException();
            }
            return factory;
        }

        public static AdapterCreator getInstance()
        {
            if (instance == null)
            {
                instance = new AdapterCreator();
            }
            return instance;
        }
    }
}