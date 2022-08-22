using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using wspreclasifica.Models.Preclasifica;

namespace wspreclasifica
{
    public class SendMail
    {        
        public string sendFrom { get; set; }
        public string sendPassword { get; set; }
        public int sendPort { get; set; }
        public bool sendEnableSsl { get; set; }
        public string sendHost { get; set; }

        public string codigoValidacion { get; set; }

        
        public SendMail()
        {

        }

        public SendMail(DataTable _dtConfiguracionCorreo)
        {
            sendHost = _dtConfiguracionCorreo.Rows[0]["servidor"].ToString();
            sendFrom = _dtConfiguracionCorreo.Rows[0]["correo"].ToString();
            sendPassword = _dtConfiguracionCorreo.Rows[0]["password"].ToString();
            if (_dtConfiguracionCorreo.Rows[0]["puerto"] != null)
                sendPort = int.Parse(_dtConfiguracionCorreo.Rows[0]["puerto"].ToString());
            sendEnableSsl = bool.Parse(_dtConfiguracionCorreo.Rows[0]["EnableSSL"].ToString());


            //sendHost = "smtp.gmail.com";
            //sendPort = 587;
            //sendEnableSsl = true;

            //sendFrom = "canespvas@gmail.com";
            //sendPassword = "Canelita123%";
            

        }


        public bool send(string _Para, string _Asunto, string _MensajeCuerpo)
        {

            bool enviado = false;

            try
            {
                if (string.IsNullOrEmpty(sendFrom))
                {
                    Utilerias.WriteProblems(null,"El correo para enviar es nulo o vacio.");
                }
                else
                {

                    System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                    msg.To.Add(_Para);
                    //msg.Bcc.Add(set.mailSendFrom);
                    msg.Subject = _Asunto;
                    msg.SubjectEncoding = System.Text.Encoding.UTF8;
                    msg.Body = _MensajeCuerpo;
                    msg.IsBodyHtml = true;
                    msg.From = new System.Net.Mail.MailAddress(sendFrom);

                    System.Net.Mail.SmtpClient correoCliente = new System.Net.Mail.SmtpClient();
                    correoCliente.Host = sendHost;
                    correoCliente.Port = sendPort;
                    correoCliente.EnableSsl = sendEnableSsl;
                    correoCliente.DeliveryMethod = SmtpDeliveryMethod.Network;
                    correoCliente.UseDefaultCredentials = true;
                    correoCliente.Credentials = new System.Net.NetworkCredential(sendFrom, sendPassword);
                    correoCliente.DeliveryFormat = SmtpDeliveryFormat.International;
                                        
                    correoCliente.Send(msg);
                    enviado = true;
                }
            }
            catch (Exception ex)
            {
                Utilerias.WriteProblems(ex, null);
            }

            return enviado;
        }

        public bool sendCodigoValidacion(mdlPreclasifica _mdlPreclasifica)
        {
            bool elCorreoFueEnviado = false;
            try
            {

                Random random = new Random();                    
                int intCodigoValidacion = random.Next(1, 9999);
                string body = "<div style=\"width: 520px;\">" +
                                $"<h1>{intCodigoValidacion.ToString("0000")}</h1>" +
                                $"<small>CÓDIGO VALIDACIÓN</small>" +
                              "</div> ";

                elCorreoFueEnviado = send(_mdlPreclasifica.correo, "MAAY -- Código de Validación --", body);

                codigoValidacion = intCodigoValidacion.ToString("0000");

            }
            catch (Exception ex) {

                Utilerias.WriteProblems(ex, null);
            }

            return elCorreoFueEnviado;
        }
    }
}
