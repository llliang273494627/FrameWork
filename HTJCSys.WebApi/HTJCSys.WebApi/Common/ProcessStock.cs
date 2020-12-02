using COM;
using DAL;
using MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTJCSys.WebApi.Common
{
    public class ProcessStock
    {
        internal static bool Invoke(string producttype,string productcode, Dictionary<string, MaterialBomMDL> ht)
        {
            List<MaterialBomMDL> list = ht.Where(m => m.Value.TraceType == "批次追溯" && !string.IsNullOrEmpty(m.Value.Ext2)).Select(m => m.Value).ToList();

            if (list != null)
            {
                //string ids = string.Join(",", list.ToArray());

                //string sql = $"UPDATE BatchNo SET StockNum=StockNum-MaterialNum WHERE TID IN({ids}) AND StockNum>0;";
                //string sql = $"UPDATE BatchNo SET StockNum=StockNum-b.MaterialNum FROM(SELECT * FROM ProductBomInfo WHERE ProductType='{producttype}' AND ProductCode='{productcode}') b WHERE BatchNo.TID IN({ids}) AND StockNum>0;";
                StringBuilder builder = new StringBuilder();
                foreach (var item in list)
                {
                    builder.AppendLine($"UPDATE BatchNo SET StockNum=StockNum-{item.MaterialNum} WHERE TID={item.Ext2} AND StockNum>0;");
                }

                try
                {
                    return CommonDAL.ExecuteSql(builder.ToString(), null);
                }
                catch (Exception ex)
                {
                    CLog.WriteErrLog(ex.Message + "\r\nsql:" + builder.ToString());
                }
            }

            return false;
        }
    }
}