﻿namespace SegundaPracticaMVC.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    namespace PruebaExamen.Models
    {
        [Table("USUARIOS")]
        public class Usuario
        {
            [Key]
            [Column("IdUsuario")]
            public int IdUsuario { get; set; }

            [Column("Nombre")]
            public string Nombre { get; set; }

            [Column("Apellidos")]
            public string Apellidos { get; set; }

            [Column("Email")]
            public string Email { get; set; }

            [Column("Foto")]
            public string Foto { get; set; }

            [Column("Pass")]
            public string Password { get; set; }
        }
    }

}
