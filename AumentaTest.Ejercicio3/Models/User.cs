﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Services.Description;

namespace AumentaTest.Ejercicio3.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Nombre de usuario")]
        [StringLength(15)]
        [RegularExpression(@"^[a-zA-Z0-9]*$",ErrorMessage = "No se aceptan espacios ni caracteres especiales para el 'Nombre de usuario'.")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Nombre(s)")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Apellido(s)")]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Correo electrónico")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Nueva Contraseña")]
        [NotMapped]
        public virtual string NewPassword { get; set; }

        public List<UserRole> UserRoles;
    }
}