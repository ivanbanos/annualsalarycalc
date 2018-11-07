using annualsalarycalcBL.BussinessLogic.Models;
using IBDLocal.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace annualsalarycalcBL.BussinessLogic.Factory
{
    public interface EmployeeAdapterFactory : Adapter
    {
        DTO create(Data data, int pos);
    }
}