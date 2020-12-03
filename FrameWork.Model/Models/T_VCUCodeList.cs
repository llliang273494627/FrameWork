using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace FrameWork.Model.Models
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("T_VCUCodeList")] 
    public class T_VCUCodeList
    {
           public T_VCUCodeList(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string baud {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string sendaddress {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string responseaddress {get;set;}

    }
}
