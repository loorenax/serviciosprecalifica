using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace wspreclasifica
{
    public class GestorCorreo
    {

        public string sendFrom { get; set; }
        public string sendPassword { get; set; }
        public int sendPort { get; set; }
        public bool sendEnableSsl { get; set; }
        public string sendHost { get; set; }
      
        public Datos.PreClasifica dat = new Datos.PreClasifica();

        public GestorCorreo()
        {
            DataSet ds = dat.getConfiguracionCorreo();
            InicializaConfiguracion(ds.Tables["configuracionCorreo"]);
        }
        public void InicializaConfiguracion(DataTable _dtConfiguracionCorreo)
        {
            DataRow dr = _dtConfiguracionCorreo.Rows[0];
            sendHost = dr["servidor"].ToString();
            sendPort = int.Parse(dr["puerto"].ToString());
            sendEnableSsl = bool.Parse(dr["EnableSSL"].ToString());

            sendFrom = dr["correo"].ToString();
            sendPassword = dr["password"].ToString();
        }

        public bool enviarCorreo(string _correoTo, string _asunto, string _body)
        {
            bool correoEnviado = false;

            try
            {

                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                msg.To.Add(_correoTo);
                msg.Bcc.Add(sendFrom);
                msg.Subject = _asunto;
                msg.SubjectEncoding = System.Text.Encoding.UTF8;
                msg.Body = _body;
                msg.IsBodyHtml = true;
                msg.From = new System.Net.Mail.MailAddress(sendFrom);

                System.Net.Mail.SmtpClient correoCliente = new System.Net.Mail.SmtpClient();
                correoCliente.UseDefaultCredentials = false;
                correoCliente.Credentials = new System.Net.NetworkCredential(sendFrom, sendPassword);
                correoCliente.Port = Convert.ToInt32(sendPort);
                correoCliente.EnableSsl = sendEnableSsl; // true;
                correoCliente.Host = sendHost;
                correoCliente.DeliveryFormat = System.Net.Mail.SmtpDeliveryFormat.International;

                correoCliente.Send(msg);
                correoEnviado = true;
            }
            catch (Exception ex)
            {
                // Sometimes an error occures, e.g. if the network was disconected or a timeout occured.
                //Logger.Instance.LogException(this, ex);
                Utilerias.WriteProblems(ex, null);
            }

            return correoEnviado;
        }

    }
}
