﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AumentaTest.Ejercicio3.Models
{
    public class RolePermission
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        
        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }
}