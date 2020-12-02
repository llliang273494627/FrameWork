using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace MDL
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    public class UserInfoMDL
    {
        /// <summary>
        /// 自增长编号
        /// </summary>		
        private long _tid;
        public long TID
        {
            get { return _tid; }
            set { _tid = value; }
        }
        /// <summary>
        /// 用户编号
        /// </summary>		
        private string _userid;
        public string UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// 用户姓名
        /// </summary>		
        private string _username;
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        /// <summary>
        /// 性别
        /// </summary>		
        private string _usersex;
        public string UserSex
        {
            get { return _usersex; }
            set { _usersex = value; }
        }
        /// <summary>
        /// 登录密码，MD5加密
        /// </summary>		
        private string _userpwd;
        public string UserPwd
        {
            get { return _userpwd; }
            set { _userpwd = value; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>		
        private string _phonenum;
        public string PhoneNum
        {
            get { return _phonenum; }
            set { _phonenum = value; }
        }
        /// <summary>
        /// 部门信息
        /// </summary>		
        private string _department;
        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }
        /// <summary>
        /// 角色名称，总共分为管理员、工艺员、操作工，由系统超级帐号admin设置权限
        /// </summary>		
        private string _rolename;
        public string RoleName
        {
            get { return _rolename; }
            set { _rolename = value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>		
        private DateTime _createtime;
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }

    }
}

