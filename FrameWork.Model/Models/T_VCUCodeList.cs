using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace FrameWork.Model.Models
{
    [SugarTable("T_VCUCodeList")]
    public class T_VCUCodeList
    {
        /// <summary>
        /// 序号
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int id { get; set; }

        /// <summary>
        /// 波特率
        /// </summary>
        public string baud { get; set; }

        /// <summary>
        /// 接收地址
        /// </summary>
        public string sendaddress { get; set; }

        /// <summary>
        /// 响应地址
        /// </summary>
        public string responseaddress { get; set; }

    }
}
