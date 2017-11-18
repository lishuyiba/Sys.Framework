using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Framework.Model.Sys
{
    public class T_Sys_Business
    {
        //F_Id, F_BusinessName, F_BusinessNo, F_Status, F_CreateTime

        [Key]
        public int F_Id { get; set; }
        public string F_BusinessName { get; set; }
        public string F_BusinessNo { get; set; }
        public int F_Status { get; set; }
        public DateTime F_CreateTime { get; set; }
    }
}
