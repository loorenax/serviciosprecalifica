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
            //accountSid = dr["w_accountSid"].ToString();
            //authToken = dr["w_authToken"].ToString();
            //fromPhone = dr["w_fromPhone"].ToString();
            //prefijoEnvio = dr["w_prefijoEnvio"].ToString();

            accountSid = "AC40b8f32037264e3f32e5aaa0f6056c62";
            authToken = "ec565bf3abce5f5bed2ef5a3109706a2";
            fromPhone = "whatsapp:+5218141702514"; // dr["w_fromPhone"].ToString();
            prefijoEnvio = "whatsapp:+521";


        }

        public bool send(string _telefono, string _mensaje) {

            bool enviado = false;

            try
            {
                TwilioClient.Init(accountSid, authToken);

                var messageOptions = new CreateMessageOptions(
                    new PhoneNumber(prefijoEnvio + _telefono)
                    );

                messageOptions.From = new PhoneNumber(fromPhone);
                messageOptions.Body = _mensaje;

                var message = MessageResource.Create(messageOptions);
                Console.WriteLine(message.Body);
            }
            catch (Exception ex) {
                Utilerias.WriteProblems(ex, null);
            }

            return enviado;
        }

        public bool sendTest_Respaldo_1()
        {

            bool enviado = false;

            try
            {
                var accountSid = "";
                var authToken = "";

                TwilioClient.Init(accountSid, authToken);

                var messageOptions = new CreateMessageOptions(
                    new PhoneNumber("whatsapp:+521" + "8116988508"));
                messageOptions.From = new PhoneNumber("whatsapp:+14155238886");
                messageOptions.Body = "Si jala!!!";

                var message = MessageResource.Create(messageOptions);
                Console.WriteLine(message.Body);
            }
            catch (Exception ex)
            {
                Utilerias.WriteProblems(ex, null);
            }

            return enviado;
        }

        public DataSet SendTest(Dictionary<string, object> _DyParametros, DataTable _DtPlantillas)
        {
            DataSet ds = new DataSet();
            DataTable dt = Utilerias.SchemaDtResult_V2();

            string telefono = "";
            StringBuilder plantilla = new StringBuilder();
            //string plantilla = _DtPlantillas.Rows[0]["Plantilla"].ToString();

            try
            {
                //De momento usare el template de Notificación de Cita que solo requiere
                //el nombre de la compañía, una fecha y el telefono a donde se va a enviar.
                telefono = _DyParametros["celular"].ToString();

                plantilla.Append(_DtPlantillas.Rows[0]["Plantilla"].ToString());
                plantilla = plantilla.Replace("{{1}}", "7777");


                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(
                        from: new Twilio.Types.PhoneNumber(fromPhone),
                        body: plantilla.ToString(),
                        to: new Twilio.Types.PhoneNumber($"{prefijoEnvio}{telefono}")
                    );

                dt.Rows[0]["estatusProcedimiento"] = Utilerias._OK_;
                dt.Rows[0]["mensajeProcedimiento"] = $"El mensaje se envio con estatus: {message.Status}";

            }
            catch (Exception ex)
            {
                Utilerias.WriteProblems(ex, null);
            }

            ds.Tables.Add(dt);

            return ds;

        }
    }
}
