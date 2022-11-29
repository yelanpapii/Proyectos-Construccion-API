using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectosConstruccion.Persistencia.Models
{
    public partial class Lider
    {
        public Lider()
        {
            Proyectos = new HashSet<Proyecto>();
        }

        public byte IdLider { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int? Salario { get; set; }
        public string CiudadResidencia { get; set; }
        public string Cargo { get; set; }
        public decimal? Clasificacion { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string FechaNacimiento { get; set; }

        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}
