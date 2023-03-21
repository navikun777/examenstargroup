using System;
using System.Collections.Generic;

namespace STARPrueba.Models
{
    public partial class Area
    {
        public Area()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
