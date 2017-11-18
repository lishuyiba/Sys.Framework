using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Framework.Model.Sys
{
    public class T_Sys_User
    {
        [Key]
        public int F_Id { get; set; }
        public string F_Account { get; set; }
        public string F_Password { get; set; }
        public int F_RoleId { get; set; }
        public DateTime F_CreateTime { get; set; }
        public int F_IsDelete { get; set; }
    }
}
