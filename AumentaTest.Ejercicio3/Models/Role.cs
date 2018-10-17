using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace AumentaTest.Ejercicio3.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public ObservableCollection<UserRole> UserRoles;
        public ObservableCollection<RolePermission> RolePermissions;
    }
}