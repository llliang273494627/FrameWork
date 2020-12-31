using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Data;
using System.IO;

namespace DSG_Group.DGComm
{
    public class HelperFile
    {
        /// <summary>
        /// 创建工作薄
        /// </summary>
        /// <param name="tab"></param>
        private static void CreateSheet(IWorkbook wb, DataTable tab)
        {
            // 创建工作薄
            ISheet sht = wb.CreateSheet(tab.TableName);
            // 创建列
            IRow columnName = sht.CreateRow(0);
            for (int iColumn = 0; iColumn < tab.Columns.Count; iColumn++)
            {
                // 创建单元格并赋值
                columnName.CreateCell(iColumn).SetCellValue(tab.Columns[iColumn].ColumnName);
            }
            for (int iRow = 0; iRow < tab.Rows.Count; iRow++)
            {
                // 创建行
                IRow row = sht.CreateRow(iRow + 1);
                for (int iColumn = 0; iColumn < tab.Columns.Count; iColumn++)
                {
                    // 创建单元格并赋值
                    row.CreateCell(iColumn).SetCellValue(tab.Rows[iRow][iColumn].ToString());
                }
            }
        }

        /// <summary>
        /// 保存Excel文件
        /// </summary>
        /// <param name="wb"></param>
        /// <param name="dirName"></param>
        /// <param name="fileName"></param>
        private static void SaveExcel(IWorkbook wb,string dirName,string fileName)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), dirName);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            path = Path.Combine(path, fileName);
            using (FileStream file = new FileStream(path, FileMode.Create))
            {
                wb.Write(file);
                file.Close();
                file.Dispose();
            }
        }

        /// <summary>
        /// 创建表格
        /// </summary>
        /// <param name="tab"></param>
        /// <returns></returns>
        public static bool CreateExcel(DataTable tab)
        {
            try
            {
                var wb = new HSSFWorkbook();
                // 创建工作薄
                CreateSheet(wb, tab);
                SaveExcel(wb, "Excel", $"{DateTime.Now.ToString("yyyyMMdd")}_{tab.TableName}.xls");
                return true;
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("创建表格失败！", ex);
                return false;
            }
        }
        public static bool CreateExcel(DataTable tab,string fileName)
        {
            try
            {
                var wb = new HSSFWorkbook();
                // 创建工作薄
                CreateSheet(wb, tab);
                SaveExcel(wb, "Excel", $"{DateTime.Now.ToString("yyyyMMdd")}_{fileName}.xls");
                return true;
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("创建表格失败！", ex);
                return false;
            }
        }

        /// <summary>
        /// 创建表格
        /// </summary>
        /// <param name="set"></param>
        /// <returns></returns>
        public static bool CreateExcel(DataSet set)
        {
            try
            {
                var wb = new HSSFWorkbook();
                foreach (DataTable iTb in set.Tables)
                {
                    // 创建工作薄
                    CreateSheet(wb, iTb);
                }
                SaveExcel(wb, "Excel", $"{DateTime.Now.ToString("yyyyMMdd")}_set.xls");
                return true;
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("创建表格失败！", ex);
                return false;
            }
        }
        public static bool CreateExcel(DataSet set,string fileName)
        {
            try
            {
                var wb = new HSSFWorkbook();
                foreach (DataTable iTb in set.Tables)
                {
                    // 创建工作薄
                    CreateSheet(wb, iTb);
                }
                SaveExcel(wb, "Excel", $"{DateTime.Now.ToString("yyyyMMdd")}_{fileName}.xls");
                return true;
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("创建表格失败！", ex);
                return false;
            }
        }
    }
}
