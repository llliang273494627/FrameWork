using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace FrameWork.Model.DFPV_DSG101
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("cartype_tpms")]
    public class cartype_tpms
    {
        public cartype_tpms()
        {


        }

        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; } = 0;

        /// <summary>
        /// 匹配的字母
        /// </summary>
        public string MatchLetter { get; set; }

        /// <summary>
        /// 车型
        /// </summary>
        public string CarType { get; set; }

        /// <summary>
        /// 是否带胎压
        /// </summary>
        public bool ifTPMS { get; set; }

        /// <summary>
        /// 起始位置
        /// </summary>
        public int CodeStartIndex { get; set; }

        /// <summary>
        /// 长度
        /// </summary>
        public int CodeLen { get; set; }

    }
}
