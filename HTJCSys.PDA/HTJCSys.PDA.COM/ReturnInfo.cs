using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COM
{
    /// <summary>
    /// 返回信息类
    /// </summary>
    public class ReturnInfo
    {
        /// <summary>
        /// 返回信息码
        /// 0:False,Not OK
        /// 1:True,OK
        /// 101:用户不存在
        /// 102:(原始)密码错误
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 返回的信息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public object Data { get; set; }
    }
}
