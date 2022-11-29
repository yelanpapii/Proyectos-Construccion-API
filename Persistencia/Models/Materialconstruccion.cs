using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectosConstruccion.Persistencia.Models
{
    public partial class Materialconstruccion
    {
        public Materialconstruccion()
        {
            Compras = new HashSet<Compra>();
        }

        public byte IdMaterialConstruccion { get; set; }
        public string NombreMaterial { get; set; }
        public string Importado { get; set; }
        public short? PrecioUnidad { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
    }
}
