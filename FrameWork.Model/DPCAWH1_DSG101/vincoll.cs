using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace FrameWork.Model.DPCAWH1_DSG101
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("vincoll")]
    public partial class vincoll
    {
           public vincoll(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string vin {get;set;}

           /// <summary>
           /// Desc:
           /// Default:nextval('vincoll_id_seq'::regclass)
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int id {get;set;}

    }
}
