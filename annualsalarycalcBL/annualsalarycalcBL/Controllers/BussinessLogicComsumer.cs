using annualsalarycalcBL.BussinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace annualsalarycalcBL.Controllers
{
    public class BussinessLogicComsumer
    {
        public BussinessLogicFacade facade { get; set; }

        private static BussinessLogicComsumer instance;

        private BussinessLogicComsumer()
        {
            facade = new BussinessLogicFacade();
        }

        public static BussinessLogicComsumer getInstance()
        {
            if (instance == null)
            {
                instance = new BussinessLogicComsumer();
            }
            return instance;
        }
    }
}