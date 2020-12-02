using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MDL
{
    public class MaterialFieldMDL
    {        
        /// <summary>
        /// 自增编号
        /// </summary>
        private long _tid;
        public long TID
        {
            set { _tid = value; }
            get { return _tid; }
        }
        /// <summary>
        /// 材料编码
        /// </summary>
        private string _materialcode;
        public string MaterialCode
        {
            set { _materialcode = value; }
            get { return _materialcode; }
        }
        /// <summary>
        /// 材料名称
        /// </summary>
        private string _materialname;
        public string MaterialName
        {
            set { _materialname = value; }
            get { return _materialname; }
        }
        /// <summary>
        /// 对应表名
        /// </summary>
        private string _tablename;
        public string TableName
        {
            set { _tablename = value; }
            get { return _tablename; }
        }
        /// <summary>
        /// 对应字段名
        /// </summary>
        private string _fieldname;
        public string FieldName
        {
            set { _fieldname = value; }
            get { return _fieldname; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        private string _desc;
        public string Desc
        {
            set { _desc = value; }
            get { return _desc; }
        }
    }
}
