using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectosConstruccion.Persistencia.Models
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            Compras = new HashSet<Compra>();
        }

        public short IdProyecto { get; set; }
        public string FechaInicio { get; set; }
        public string Constructora { get; set; }
        public decimal? NumeroBanos { get; set; }
        public decimal? NumeroHabitaciones { get; set; }
        public string BancoVinculado { get; set; }
        public decimal? PorcentajeCuotaInicial { get; set; }
        public string Ciudad { get; set; }
        public string Clasificacion { get; set; }
        public string Acabados { get; set; }
        public string Serial { get; set; }
        public byte? IdTipo { get; set; }
        public byte? IdLider { get; set; }

        public virtual Lider IdLiderNavigation { get; set; }
        public virtual Tipo IdTipoNavigation { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
