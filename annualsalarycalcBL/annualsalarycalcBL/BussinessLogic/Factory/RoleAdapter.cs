using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using annualsalarycalcBL.BussinessLogic.Models;
using IBDLocal.DataAccess;

namespace annualsalarycalcBL.BussinessLogic.Factory
{
    public class RoleAdapter : Adapter
    {
        public DTO create(Data data, int pos)
        {
            RoleDTO obj = new RoleDTO();
            obj.id = data.getDato(pos).getIntField("roleId");
            obj.name = data.getDato(pos).getStringField("roleName");
            obj.description = data.getDato(pos).getStringField("roleDescription");
            return obj;
        }
    }
}