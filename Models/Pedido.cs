﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SegundaPracticaMVC.Models
{
    [Table("PEDIDOS")]
    public class Pedido
    {
        [Key]
        [Column("IDPEDIDO")]
        public int IdPedido { get; set; }

        [Column("IDFACTURA")]
        public int IdFactura { get; set; }

        [Column("FECHA")]
        public DateTime FechaCompra { get; set; }
        [Column("IDLIBRO")]
        public int IdLibro { get; set; }
        [Column("IDUSUARIO")]
        public int IdUsuario { get; set; }
        [Column("CANTIDAD")]
        public int Cantidad { get; set; }
    }
}
