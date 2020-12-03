using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace FrameWork.Model.Models
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("T_MTOC")]
    public class T_MTOC
    {
           public T_MTOC(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public long id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string vin {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string mtoc {get;set;}

           /// <summary>
           /// Desc:
           /// Default:-1
           /// Nullable:True
           /// </summary>           
           public int? state {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string element {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? updateTime {get;set;}

    }
}
