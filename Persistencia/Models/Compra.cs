using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectosConstruccion.Persistencia.Models
{
    public partial class Compra
    {
        public short IdCompra { get; set; }
        public byte? Cantidad { get; set; }
        public string Proveedor { get; set; }
        public string Pagado { get; set; }
        public string Fecha { get; set; }
        public short? IdProyecto { get; set; }
        public byte? IdMaterialConstruccion { get; set; }

        public virtual Materialconstruccion IdMaterialConstruccionNavigation { get; set; }
        public virtual Proyecto IdProyectoNavigation { get; set; }
    }
}
