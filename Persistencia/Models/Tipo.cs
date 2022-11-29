using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectosConstruccion.Persistencia.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            Proyectos = new HashSet<Proyecto>();
        }

        public byte IdTipo { get; set; }
        public short? CodigoTipo { get; set; }
        public short? AreaMax { get; set; }
        public byte? Financiable { get; set; }
        public byte? Estrato { get; set; }

        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}
