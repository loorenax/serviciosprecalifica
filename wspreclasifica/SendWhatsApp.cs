using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public bool sendTest()
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
    }
}
