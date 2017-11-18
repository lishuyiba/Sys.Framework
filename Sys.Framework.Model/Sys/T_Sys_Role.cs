using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Framework.Model.Sys
{
    public class T_Sys_Role
    {
        [Key]
        public int F_Id { get; set; }
        public string F_RoleName { get; set; }
    }
}
