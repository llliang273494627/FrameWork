﻿using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace FrameWork.Model.DPCAWH1_DSG101
{
    ///<summary>
    ///运行参数
    ///</summary>
    [SugarTable("T_RunParam")]
    public partial class T_RunParam
    {
        public T_RunParam()
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