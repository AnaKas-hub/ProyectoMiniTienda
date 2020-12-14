using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoMiniTienda.Models
{
    public class CompraVenta
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(30)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage ="Campo obligatorio")]
        [Display(Name ="Tipo")]
        public bool EsCompra { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Valor")]
        public double valor { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public int Cantidad { get; set; }
        
        public DateTime Fecha { get; set; }

    }
}