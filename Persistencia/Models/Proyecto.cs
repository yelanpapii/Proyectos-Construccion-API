using ProyectosConstruccion.Persistencia.Interceptor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ProyectosConstruccion.Persistencia.Models
{
    public partial class Proyecto : IAuditableEntity
    {
        public Proyecto()
        {
            Compras = new HashSet<Compra>();
        }

        public short IdProyecto { get; set; }
        public string FechaInicio { get; set; }
        [Required]
        public string Constructora { get; set; }
        public decimal? NumeroBanos { get; set; }
        public decimal? NumeroHabitaciones { get; set; }
        [Required]
        public string BancoVinculado { get; set; }
        public decimal? PorcentajeCuotaInicial { get; set; }
        public string Ciudad { get; set; }
        public string Clasificacion { get; set; }
        public string Acabados { get; set; }
        public string Serial { get; set; }
        public byte? IdTipo { get; set; }
        public byte? IdLider { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual Lider IdLiderNavigation { get; set; }
        public virtual Tipo IdTipoNavigation { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
        
    }
}
