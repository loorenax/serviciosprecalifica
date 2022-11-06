using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace wspreclasifica
{
    public class SendWhatsApp
    {
        public string accountSid { get; set; }
        public string authToken { get; set; }
        public string fromPhone { get; set; }
        public string prefijoEnvio { get; set; }

        public Datos.PreClasifica dat = new Datos.PreClasifica();

        public SendWhatsApp()
        {
            DataSet ds = dat.getConfiguracionWhatsApp();

            DataRow dr = ds.Tables["configuracionWhatsApp"].Rows[0];

            accountSid = dr["w_accountSid"].ToString();
            authToken = dr["w_authToken"].ToString();
            fromPhone = dr["w_fromPhone"].ToString();
            prefijoEnvio = dr["w_prefijoEnvio"].ToString();


            //Para envio de SMS
            //accountSid = "AC40b8f32037264e3f32e5aaa0f6056c62";
            // authToken = "cfd3657271ffa837e13db250c517d9ab";
            //fromPhone = "+15136475686";
            //prefijoEnvio = "+52";




        }

        public DataSet SendSMSTest()
        {
            DataSet ds = new DataSet();
            DataTable dt = Utilerias.SchemaDtResult_V2();

            string telefono = "";
            StringBuilder plantilla = new StringBuilder();
            //string plantilla = _DtPlantillas.Rows[0]["Plantilla"].ToString();

            try
            {

                accountSid = "AC40b8f32037264e3f32e5aaa0f6056c62";
                authToken = "9ffdf6dd5f8c001d81226da364956f5b";

                //fromPhone = "whatsapp:+15136475686"; // dr["w_fromPhone"].ToString();
                fromPhone = "+15136475686"; // dr["w_fromPhone"].ToString();
                prefijoEnvio = "+52";


                //De momento usare el template de Notificación de Cita que solo requiere
                //el nombre de la compañía, una fecha y el telefono a donde se va a enviar.
                telefono = "4624202462";

                plantilla.Append("¡Hola! Tu código de seguridad para MAAY CAPITAL es *{{1}}*");
                plantilla = plantilla.Replace("{{1}}", "7777");

                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(
                        from: new Twilio.Types.PhoneNumber(fromPhone),
                        body: plantilla.ToString(),
                        to: new Twilio.Types.PhoneNumber($"{prefijoEnvio}{telefono}")
                    );

                dt.Rows[0]["Estatus_Procedimiento"] = Utilerias._OK_;
                dt.Rows[0]["Mensaje_Procedimiento"] = $"El mensaje se envio con estatus: {message.Status}";

            }
            catch (Exception ex)
            {
                dt.Rows[0]["Estatus_Procedimiento"] = Utilerias._ERROR_;
                dt.Rows[0]["Mensaje_Procedimiento"] = ex.Message;

                Utilerias.WriteProblems(ex, null);
            }

            ds.Tables.Add(dt);

            return ds;

        }
        public DataSet SendSMSCodigo(string _celular, string msg)
        {
            DataSet ds = new DataSet();
            DataTable dt = Utilerias.SchemaDtResult_V2();

            string telefono = "";
            StringBuilder plantilla = new StringBuilder();

            try
            {

                Random rdm = new Random();
                string strcodigo = rdm.Next(0, 9999).ToString("0000");

                //De momento usare el template de Notificación de Cita que solo requiere
                //el nombre de la compañía, una fecha y el telefono a donde se va a enviar.
                //telefono = "4624202462";
                telefono = _celular;

                plantilla.Append(msg);

                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(
                        from: new Twilio.Types.PhoneNumber(fromPhone),
                        body: plantilla.ToString(),
                        to: new Twilio.Types.PhoneNumber($"{prefijoEnvio}{telefono}")
                    );

                dt.Rows[0]["Estatus_Procedimiento"] = Utilerias._OK_;
                dt.Rows[0]["Mensaje_Procedimiento"] = $"El mensaje se envio con estatus: {message.Status}";

            }
            catch (Twilio.Exceptions.ApiException twex) {

                if (twex.Code == 21211)
                {
                    //The 'To' number +52444444444444455555555 is not a valid phone number.
                    dt.Rows[0]["Estatus_Procedimiento"] = Utilerias._RESTRICCION_;
                    dt.Rows[0]["Mensaje_Procedimiento"] = twex.Message;
                }
                else {
                    dt.Rows[0]["Estatus_Procedimiento"] = Utilerias._RESTRICCION_;
                    dt.Rows[0]["Mensaje_Procedimiento"] = twex.Message;
                }

                Utilerias.WriteProblems(null, $"Error Twilio: {twex.Message}");
            }
            catch (Exception ex)
            {

                dt.Rows[0]["Estatus_Procedimiento"] = Utilerias._ERROR_;
                dt.Rows[0]["Mensaje_Procedimiento"] = ex.Message;

                Utilerias.WriteProblems(ex, null);
            }

            ds.Tables.Add(dt);

            return ds;

        }

    }
}
