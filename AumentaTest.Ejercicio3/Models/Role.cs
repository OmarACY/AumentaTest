using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AumentaTest.Ejercicio3.Models
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Nombre")]
        [StringLength(100)]
        public string Name { get; set; }

        [DisplayName("Descripción")]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [DisplayName("Habilitado")]
        public bool Enabled { get; set; }

        public ObservableCollection<UserRole> UserRoles;
        public ObservableCollection<RolePermission> RolePermissions;
    }
}