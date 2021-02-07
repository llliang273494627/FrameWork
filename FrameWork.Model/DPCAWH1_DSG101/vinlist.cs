using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace FrameWork.Model.DPCAWH1_DSG101
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("vinlist")]
    public partial class vinlist
    {
           public vinlist(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? uw5anoseq {get;set;}

           /// <summary>
           /// Desc:
           /// Default:false
           /// Nullable:True
           /// </summary>           
           public bool? tested {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string whof {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string uw2anoseq {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string vin {get;set;}

           /// <summary>
           /// Desc:
           /// Default:nextval('vinlist_id_seq'::regclass)
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int id {get;set;}

    }
}
