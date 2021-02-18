using FrameWork.Model.DPCAWH1_DSG101;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSGTest.Common.SqlServive.Sql_DPCAWH1_DSG101
{
   public  class Servicerunstate : FrameWork.Model.Comm.HelperSqlsugar
    {
        /// <summary>
        /// 初始化状态
        /// </summary>
        /// <returns></returns>
        public static int resetState()
        {
            int id = sqlSugarClient.Queryable<runstate>().Select(it => it.id).First();
            return sqlSugarClient.Updateable<runstate>().SetColumns(it => new runstate()
            {
                test = false,
                dsgrf = null,
                dsglf = null,
                dsgrr = null,
                dsglr = null,
                mdlrf = null,
                mdllf = null,
                mdlrr = null,
                mdllr = null,
                prerf = null,
                prelf = null,
                prerr = null,
                prelr = null,
                temprf = null,
                templf = null,
                temprr = null,
                templr = null,
                batteryrf = null,
                batterylf = null,
                batteryrr = null,
                batterylr = null,
                acspeedrf = null,
                acspeedlf = null,
                acspeedrr = null,
                acspeedlr = null,
                state = 9999
            }).Where(it => it.id == id).ExecuteCommand();
        }
    }
}
