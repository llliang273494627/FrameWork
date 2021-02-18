using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace FrameWork.Model.DPCAWH1_DSG101
{
    ///<summary>
    ///控制参数
    ///</summary>
    [SugarTable("T_CtrlParam")]
    public partial class T_CtrlParam
    {
        public T_CtrlParam()
        {


        }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Group { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Description { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Key { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Value { get; set; }

    }
}
