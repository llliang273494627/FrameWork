using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Model.DPCAWH1_DSG101
{
    [SugarTable("vincoll")]
    public class vincoll
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int id { get; set; }

        public string vin { get; set; }

       

    }
}
