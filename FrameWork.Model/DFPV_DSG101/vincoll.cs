﻿using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace FrameWork.Model.DFPV_DSG101
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("vincoll")]
    public class vincoll
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }

        public string vin { get; set; }

        public bool tpms { get; set; }

        public string cartype { get; set; }

    }
}
