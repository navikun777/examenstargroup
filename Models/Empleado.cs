using System;
using System.Collections.Generic;

namespace STARPrueba.Models
{
    public partial class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? ApePaterno { get; set; }
        public string? ApeMaterno { get; set; }
        public int? Edad { get; set; }
        public string? Direccion { get; set; }
        public string? Email { get; set; }
        public int? AreaId { get; set; }

        public virtual Area Area { get; set; } = null!;
    }
}
