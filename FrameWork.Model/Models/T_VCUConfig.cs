using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace FrameWork.Model.Models
{
    [SugarTable("T_VCUConfig")]
    public class T_VCUConfig
    {
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public int id { get; set; }

        [SugarColumn(ColumnName = "mtoc")]
        public string mtoc { get; set; }

        [SugarColumn(ColumnName = "drivername")]
        public string drivername { get; set; }

        [SugarColumn(ColumnName = "driverpath")]
        public string driverpath { get; set; }

        [SugarColumn(ColumnName = "binname")]
        public string binname { get; set; }

        [SugarColumn(ColumnName = "binpath")]
        public string binpath { get; set; }

        [SugarColumn(ColumnName = "calname")]
        public string calname { get; set; }

        [SugarColumn(ColumnName = "calpath")]
        public string calpath { get; set; }

        [SugarColumn(ColumnName = "softwareversion")]
        public string softwareversion { get; set; }

        [SugarColumn(ColumnName = "elementNum")]
        public string elementNum { get; set; }

        [SugarColumn(ColumnName = "hardwarecode")]
        public string hardwarecode { get; set; }

        [SugarColumn(ColumnName = "HW")]
        public string HW { get; set; }

        [SugarColumn(ColumnName = "SW")]
        public string SW { get; set; }

        [SugarColumn(ColumnName = "elementSign")]
        public string elementSign { get; set; }

        [SugarColumn(ColumnName = "sign")]
        public string sign { get; set; }

    }
}
