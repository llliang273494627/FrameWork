using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Model.DPCAWH1_DSG101
{
    [SugarTable("vinlist")]
    public class vinlist
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int id { get; set; }
        public int uw5anoseq { get; set; }

        public string vin { get; set; }
        public string uw2anoseq { get; set; }
        
        public string whof { get; set; }
        public bool tested { get; set; }
    }
}
