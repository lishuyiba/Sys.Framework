using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Framework.Model.Sys
{
    public class T_Sys_Accept
    {
        //F_Id, F_No, F_Status, F_CreateTime
        [Key]
        public int F_Id { get; set; }
        public string F_No { get; set; }
        public int F_Status { get; set; }
        public string F_Remark { get; set; }
        public DateTime F_CreateTime { get; set; }
    }
}
