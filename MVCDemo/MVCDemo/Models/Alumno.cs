//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCDemo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Alumno
    {
        public Alumno()
        {
            this.Asistencias = new HashSet<Asistencia>();
        }
    
        public int CodigoAlumno { get; set; }
        public string Nombre { get; set; }
        public string ApellidoParterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string TelefonoMovil { get; set; }
    
        public virtual ICollection<Asistencia> Asistencias { get; set; }
    }
}