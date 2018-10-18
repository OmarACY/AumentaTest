using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AumentaTest.Ejercicio3.Models
{
    public class RolePermission
    {
        [Required]
        public int RoleId { get; set; }
        [Required]
        public int PermissionId { get; set; }
        
        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }
}