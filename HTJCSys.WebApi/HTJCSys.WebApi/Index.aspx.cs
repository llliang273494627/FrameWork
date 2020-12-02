using COM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTJCSys.WebApi
{
    public partial class Index : System.Web.UI.Page
    {
        public string VersionInfo;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.VersionInfo = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}