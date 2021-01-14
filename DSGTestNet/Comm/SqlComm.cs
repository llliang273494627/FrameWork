using DSGTestNet.Helper;
using DSGTestNet.SqlServers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSGTestNet.Comm
{
    public class SqlComm
    {
        public async static Task<string> readState(string key)
        {
            string value = string.Empty;
            switch (key)
            {
                case "test":
                    value= (await Service_runstate.QueryableTest()).ToString();
                    break;
                case "state":
                    value = (await Service_runstate.QueryableState()).ToString();
                    break;
                case "vin":
                    value = (await Service_runstate.QueryableVIN()).ToString();
                    break;
            }
            return value;
        }

        public async static Task<string> getConfigValue(string tableName, string group, string key)
        {
            string value = string.Empty;
            switch (tableName)
            {
                case "T_RunParam":
                    value = await Service_T_RunParam.GetValue(group, key);
                    break;
                case "T_CtrlParam":
                    value = await Service_T_CtrlParam.GetValue(group, key);
                    break;
            }
            return value;
        }

        public async static Task updateState(string key, string value)
        {
            switch (key)
            {
                case "state":
                    if (int.TryParse(value, out int state))
                        await Service_runstate.UpdateableState(state);
                    else
                        HelperLogWrete.Error($"转化为数据类型失败！value={value}");
                    break;
            }
        }
    }
}
