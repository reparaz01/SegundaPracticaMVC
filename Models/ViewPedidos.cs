﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SegundaPracticaMVC.Models
{
    [Table("VISTAPEDIDOS")]
    public class ViewPedidos
    {
        [Key]
        [Column("IDVISTAPEDIDOS")]
        public int IdVistaPedido { get; set; }

        [Column("IdUsuario")]
        public int IdUsuario { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }

        [Column("Apellidos")]
        public string Apellidos { get; set; }

        [Column("Titulo")]
        public string Titulo { get; set; }

        [Column("Precio")]
        public int Precio { get; set; }

        [Column("Portada")]
        public string Portada { get; set; }

        [Column("FECHA")]
        public DateTime Fecha { get; set; }

        [Column("PRECIOFINAL")]
        public int PrecioFinal { get; set; }
    }
}
