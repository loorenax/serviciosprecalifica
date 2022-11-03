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
        
        
        public string celular { get; set; }
        public string correo { get; set; }
        public string enviarAvisoPor { get; set; }

        public string idEstadoCivil { get; set; }
        public string idActividad { get; set; }

        /********************   Para el registro de las preclasificaciones  **********************************/
        public string codigoVerificacion { get; set; }


        public string tipoCredito              { get; set; }
        public string valorAproximado          { get; set; }
        public string MontoCredito             { get; set; }
        public string HistorialCreditoBueno { get; set; }

        /*Credito Hipotecario*/
        public string MontoHipotecaActual { get; set; }
        public string ValorAproximadoInmuebleHipotecaMejorar { get; set; }
        public string PagoPuntualHipoteca { get; set; }
        public string AquienDebes { get; set; }


        /*Liquidez*/
        public string ValorAproximadoInmuebleGarantia { get; set; }


        public bool autorizoContactoAsesor { get; set; }


        public string resultadoPreclasificacion { get; set; }
        public string tieneBuenHistorial { get; set; }
    }
}
