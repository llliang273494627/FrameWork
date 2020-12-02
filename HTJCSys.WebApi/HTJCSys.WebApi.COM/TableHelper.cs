using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml;

namespace COM
{
    public class TableHelper
    {
        #region 将DataTable转换位List<object>列表
        /// <summary>
        /// 将DataTable转换位List(object)列表
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<object> TableToObj(DataTable table)
        {
            try
            {
                List<object> list = new List<object>();
                foreach (DataRow row in table.Rows)
                {
                    Dictionary<string, object> dict = new Dictionary<string, object>();
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        string name = table.Columns[i].ColumnName;
                        object value = row.ItemArray[i];
                        if (typeof(DateTime) == value.GetType() && value != null)
                        {
                            value = DateTime.Parse(row.ItemArray[i].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                        }
                        dict.Add(name, value);
                    }
                    list.Add(dict);
                }
                return list;
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
                return null;
            }
        } 
        #endregion

        #region Json 字符串 转换为 DataTable数据集合
        ///// <summary>
        ///// Json 字符串 转换为 DataTable数据集合
        ///// </summary>
        ///// <param name="json"></param>
        ///// <returns></returns>
        //public static DataTable ToDataTable(string json)
        //{
        //    DataTable dataTable = new DataTable();  //实例化
        //    DataTable result;
        //    try
        //    {
        //        JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
        //        javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //取得最大数值
        //        ArrayList arrayList = javaScriptSerializer.Deserialize<ArrayList>(json);
        //        if (arrayList.Count > 0)
        //        {
        //            foreach (Dictionary<string, object> dictionary in arrayList)
        //            {
        //                if (dictionary.Keys.Count<string>() == 0)
        //                {
        //                    result = dataTable;
        //                    return result;
        //                }
        //                if (dataTable.Columns.Count == 0)
        //                {
        //                    foreach (string current in dictionary.Keys)
        //                    {
        //                        dataTable.Columns.Add(current, dictionary[current].GetType());
        //                    }
        //                }
        //                DataRow dataRow = dataTable.NewRow();
        //                foreach (string current in dictionary.Keys)
        //                {
        //                    dataRow[current] = dictionary[current];
        //                }

        //                dataTable.Rows.Add(dataRow); //循环添加行到DataTable中
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //    }
        //    result = dataTable;
        //    return result;
        //}
        #endregion

        #region Json 字符串 转换为 DataTable数据集合
        /// <summary>
        /// Json 字符串 转换为 DataTable数据集合
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static DataTable ToDataTable(string json)
        {
            DataTable dataTable = new DataTable();  //实例化
            DataTable result;
            try
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //取得最大数值
                ArrayList arrayList = javaScriptSerializer.Deserialize<ArrayList>(json);
                if (arrayList.Count > 0)
                {
                    foreach (Dictionary<string, object> dictionary in arrayList)
                    {
                        if (dictionary.Keys.Count<string>() == 0)
                        {
                            result = dataTable;
                            return result;
                        }
                        if (dataTable.Columns.Count == 0)
                        {
                            foreach (string current in dictionary.Keys)
                            {
                                dataTable.Columns.Add(current, dictionary[current].GetType());
                            }
                        }
                        //DataRow dataRow = dataTable.NewRow();
                        //DataRow [] Rows = new DataRow[]{};
                        DataRow dataRow = dataTable.NewRow(); 
                        ArrayList list = null;
                        foreach (string Parent in dictionary.Keys)
                        {
                            if (dataTable.Columns.Contains(Parent))
                            {
                                dataRow[Parent] = dictionary[Parent];
                            }
                            else
                            {
                                list = dictionary[Parent] as ArrayList;
                            }
                        }
                        dataTable.Rows.Add(dataRow); //循环添加行到DataTable中
                        if (list!=null && list.Count>0)
                        {
                            foreach (Dictionary<string, object> ListItem in list)
                            {
                                DataRow newrow = dataTable.NewRow();
                                foreach (string Child in ListItem.Keys)
                                {
                                    newrow[Child] = ListItem[Child];
                                }
                                dataTable.Rows.Add(newrow);
                            }
                            list = null;
                        }
                    }
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region 将 Datatable 转换为 XML
        /// <summary>
        /// 将 Datatable 转换为 XML
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static string ConvertDataTableToXml(DataTable table)
        {
            XmlTextWriter writer = null;
            try
            {
                MemoryStream stream = null;
                stream = new MemoryStream();
                writer = new XmlTextWriter(stream, Encoding.Default);
                table.WriteXml(writer);
                int count = (int)stream.Length;
                byte[] arr = new byte[count];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(arr, 0, count);
                UTF8Encoding utf = new UTF8Encoding();
                return utf.GetString(arr).Trim();
            }
            catch
            {
                return String.Empty;
            }
            finally
            {
                if (writer != null) writer.Close();
            }
        } 
        #endregion

        #region 将 XML 转换为 DataSet
        /// <summary>
        /// 将 XML 转换为 DataSet
        /// </summary>
        /// <param name="xmlData"></param>
        /// <returns></returns>
        public static DataSet ConvertXmlToDataSet(string xmlData)
        {
            XmlTextReader reader = null;
            try
            {
                StringReader stream = null;
                DataSet xmlDS = new DataSet();
                stream = new StringReader(xmlData);
                reader = new XmlTextReader(stream);
                xmlDS.ReadXml(reader);
                return xmlDS;
            }
            catch (Exception ex)
            {
                string strTest = ex.Message;
                return null;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        } 
        #endregion
    }
}
