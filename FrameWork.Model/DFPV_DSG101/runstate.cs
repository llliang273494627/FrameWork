using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace FrameWork.Model.DFPV_DSG101
{
    [SugarTable("runstate")]
    public class runstate
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int id { get; set; }
    
        public string vin { get; set; }
          
        public bool test { get; set; }
      
        public string dsgrf { get; set; }
      
        public string dsglf { get; set; }
       
        public string dsgrr { get; set; }
       
        public string dsglr { get; set; }
         
        public int state { get; set; }
      
        public string mdlrf { get; set; }
       
        public string mdllf { get; set; }
       
        public string mdlrr { get; set; }
      
        public string mdllr { get; set; }
      
        public string prerf { get; set; }
  
        public string prelf { get; set; }
       
        public string prerr { get; set; }
       
        public string prelr { get; set; }
      
        public string temprf { get; set; }
       
        public string templf { get; set; }
         
        public string temprr { get; set; }
      
        public string templr { get; set; }
        
        public string batteryrf { get; set; }
         
        public string batterylf { get; set; }
         
        public string batteryrr { get; set; }
       
        public string batterylr { get; set; }
         
        public string acspeedrf { get; set; }
          
        public string acspeedlf { get; set; }
         
        public string acspeedrr { get; set; }
        
        public string acspeedlr { get; set; }
    }
}
