using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace wspreclasifica
{
    public class OTP
    {
        public string correo { get; set; }
        public string celular { get; set; }
        public string enviarAvisoPor { get; set; }

        public string codigoValidacion { get; set; }

        public Datos.PreClasifica dat = new Datos.PreClasifica();

        public OTP(string _celular, string _correo, string _enviarAvisoPor )
        {
            celular = _celular;
            correo = _correo;
            enviarAvisoPor = _enviarAvisoPor;

        }

        public DataSet enviarCodigo() {
            DataSet ds = new DataSet();
            DataTable dt = Utilerias.SchemaDtResult_V2();

            try
            {
                ds.Tables.Add(dt);
                Random rdm = new Random();
                string strcodigo = rdm.Next(0, 9999).ToString("0000");
                codigoValidacion = strcodigo;
                string asunto = "MAAY -- Código de validación --";
                string body = $"<div style=\"text-align: center;\"><h3>CÓDIGO DE VALIDACIÓN</3><h2>{strcodigo}</h2></div>";
                string msg = $"MAAY *Código de Validación* {strcodigo}";
                bool enviado = false;

                if (enviarAvisoPor == "WhatsApp") {
                    SendWhatsApp whatsApp = new SendWhatsApp();
                    enviado = whatsApp.send(celular, msg);
                }
                else if (enviarAvisoPor == "Correo")
                {
                    GestorCorreo gestor = new GestorCorreo();
                    enviado = gestor.enviarCorreo(correo, asunto, body);
                }

                ds.Tables["result"].Rows[0]["Estatus_Procedimiento"] = Utilerias._OK_;
                ds.Tables["result"].Rows[0]["Mensaje_Procedimiento"] = $"{enviarAvisoPor} enviado.";

            }
            catch (Exception ex) {

                ds.Tables["result"].Rows[0]["Estatus_Procedimiento"] = Utilerias._RESTRICCION_;
                ds.Tables["result"].Rows[0]["Mensaje_Procedimiento"] = $"El {enviarAvisoPor} no se puedo enviar.";

                Utilerias.WriteProblems(ex, null);
            }

            return ds;
        }
    }
}
