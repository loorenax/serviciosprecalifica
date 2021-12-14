using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wspreclasifica.Models.Preclasifica
{
    public class mdlPreclasifica
    {
        public string idProspecto { get; set; }
        public string nombres { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string genero { get; set; }
        public string fechaNacimiento { get; set; }
        public string rfc { get; set; }
        public string idCodigoPostal { get; set; }
        public string calleyNo { get; set; }
        
        
        public string celular { get; set; }
        public string correo { get; set; }
        public string enviarAvisoPor { get; set; }

        /********************   Para el registro de las preclasificaciones  **********************************/
        public string codigoVerificacion { get; set; }
        public string tipoCredito { get; set; }
        public string ingresoMensual { get; set; }
        public string valorAproximado { get; set; }
        
        public string domicilio { get; set; }
        public string resultadoPreclasificacion { get; set; }
    }
}
