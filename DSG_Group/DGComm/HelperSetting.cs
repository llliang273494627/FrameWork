﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSG_Group.DGComm
{
    public class HelperSetting
    {
        public static string SqlServerCnnStr = ConfigurationManager.ConnectionStrings["SqlServerCnnStr"].ConnectionString;
    }
}
