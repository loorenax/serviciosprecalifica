using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using System.Data;
using wspreclasifica.Models.Preclasifica;
using System.Net.Mail;
using System.Net.Http;
using ClienteCirculoCreditoPRD;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Web.Script.Serialization;

namespace wspreclasifica.Controllers.preclasifica
{

    [Produces("application/json")]
    [Route("api/preclasifica")]
    [EnableCors("AllowMyOrigin")]

    public class preclasificaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public preclasificaController(IConfiguration configuration)
        {
            _configuration = configuration;

        }


        Datos.PreClasifica dat = new Datos.PreClasifica();

        [HttpGet("getColoniasPorCP")]
        public ActionResult<object> getColoniasPorCP(string codigoPostal)
        {
            DataSet ds = new DataSet();

            try
            {
                //ds = D_Laboratorio.ws_ResLab_getResultados(modelRegistro.CURP, modelRegistro.Fecha_Toma);
                ds = dat.getColoniasByCP(codigoPostal);

            }
            catch (Exception ex)
            {
                Utilerias.WriteProblems(ex, null);
            }


            return Utilerias.DataSetToDictionaryArray(ds);
        }

        [HttpPost("setProspecto")]
        public ActionResult<object> setProspecto([FromBody] mdlPreclasifica modelRegistro)
        {
            DataSet ds = new DataSet();

            try
            {
                //ds = D_Laboratorio.ws_ResLab_getResultados(modelRegistro.CURP, modelRegistro.Fecha_Toma);
                Dictionary<string, object> dydatos = Utilerias.Convert_Model_To_Dictionary(modelRegistro);
                Utilerias.writeLogParametros(dydatos);

                ds = dat.setProspecto(dydatos);

                Utilerias.writeLogResult(ds.Tables["result"]);
                if (ds.Tables["result"].Rows[0]["Estatus_Procedimiento"].ToString() == Utilerias._OK_)
                {
                    OTP otp = new OTP(modelRegistro.celular, modelRegistro.correo, modelRegistro.enviarAvisoPor);
                    DataSet dsotp = otp.enviarCodigo();

                    if (dsotp.Tables["result"].Rows[0]["Estatus_Procedimiento"].ToString() == Utilerias._OK_) {
                        DataSet dsCV = dat.setCodigoValidacion(ds.Tables["result"].Rows[0]["ID"].ToString(), otp.codigoValidacion);

                        if (dsCV.Tables["result"].Rows[0]["Estatus_Procedimiento"].ToString() == Utilerias._OK_)
                        {
                            ds.Tables["result"].Rows[0]["Estatus_Procedimiento"] = Utilerias._OK_;
                            ds.Tables["result"].Rows[0]["Mensaje_Procedimiento"] = $"{modelRegistro.enviarAvisoPor} enviado.";
                        }
                        else {
                            ds.Tables["result"].Rows[0]["Estatus_Procedimiento"] = dsCV.Tables["result"].Rows[0]["Estatus_Procedimiento"];
                            ds.Tables["result"].Rows[0]["Mensaje_Procedimiento"] = dsCV.Tables["result"].Rows[0]["Mensaje_Procedimiento"];
                        }
                    }
                    else
                    {
                        ds.Tables["result"].Rows[0]["Estatus_Procedimiento"] = dsotp.Tables["result"].Rows[0]["Estatus_Procedimiento"];
                        ds.Tables["result"].Rows[0]["Mensaje_Procedimiento"] = dsotp.Tables["result"].Rows[0]["Mensaje_Procedimiento"];
                    }

                }
            }
            catch (Exception ex)
            {
                Utilerias.WriteProblems(ex, null);
            }


            return Utilerias.DataSetToDictionaryArray(ds);
        }

        [HttpPost("autenticar-codigoValidacion")]
        public ActionResult<object> autenticarCodigoValidacion(string idProspecto, string codigoValidacion)
        {
            DataSet ds = new DataSet();

            try
            {
                ds = dat.autenticacionCodigo(idProspecto, codigoValidacion);

            }
            catch (Exception ex)
            {
                Utilerias.WriteProblems(ex, null);
            }


            return Utilerias.DataSetToDictionaryArray(ds);
        }

        [HttpPost("enviar-codigoValidacion-porcorreo")]
        public ActionResult<object> enviarCodigoValidacionPorCorreo(string correoTo)
        {
            DataSet ds = new DataSet();
            DataTable dtresult = Utilerias.SchemaDtResult_V2();

            try
            {

                GestorCorreo gestor = new GestorCorreo();
                gestor.enviarCorreo(correoTo, "Correo de prueba", "<h1>CÓDIGO: 9999</h1>");


                dtresult.Rows[0]["Estatus_Procedimiento"] = Utilerias._OK_;
            }
            catch (Exception ex)
            {
                dtresult.Rows[0]["Estatus_Procedimiento"] = Utilerias._ERROR_;
                Utilerias.WriteProblems(ex, null);
            }

            ds = new DataSet();
            ds.Tables.Add(dtresult);

            return Utilerias.DataSetToDictionaryArray(ds);
        }

        [HttpPost("enviar-codigoValidacion-porwhatsapp")]
        public ActionResult<object> enviarCodigoValidacionPorWhatsApp(string celular)
        {
            DataSet ds = new DataSet();
            DataTable dtresult = Utilerias.SchemaDtResult_V2();
            SendWhatsApp wa = new SendWhatsApp();

            try
            {
                Dictionary<string, object> dyparametros = new Dictionary<string, object>();
                dyparametros.Add("P_CodigoPlantilla", "MSGOTP");
                DataSet dsPlantilla = dat.getPlantillaByCodigo(dyparametros);

                ds = wa.SendTest(dyparametros, dsPlantilla.Tables["Plantillas"]);

                ds.Tables["result"].Rows[0]["Estatus_Procedimiento"] = Utilerias._OK_;
            }
            catch (Exception ex)
            {
                dtresult.Rows[0]["Estatus_Procedimiento"] = Utilerias._ERROR_;
                ds.Tables.Add(dtresult);

                Utilerias.WriteProblems(ex, null);
            }

            
            

            return Utilerias.DataSetToDictionaryArray(ds);
        }

        [HttpPost("enviar-whatsapp-directo")]
        public ActionResult<object> enviarWhatsAppDirecto([FromBody] mdlPreclasifica modelRegistro)
        {
            DataSet ds = new DataSet();
            DataTable dtresult = Utilerias.SchemaDtResult_V2();
            SendWhatsApp wa = new SendWhatsApp();

            try
            {
                Dictionary<string, object> dyparametros = Utilerias.Convert_Model_To_Dictionary(modelRegistro);
                //Dictionary<string, object> dyparametros = new Dictionary<string, object>();
                dyparametros.Add("P_CodigoPlantilla", "TEST");
                DataSet dsPlantilla = dat.getPlantillaByCodigo(dyparametros);

                ds = wa.SendTest(dyparametros, dsPlantilla.Tables["Plantillas"]);

                ds.Tables["result"].Rows[0]["Estatus_Procedimiento"] = Utilerias._OK_;
            }
            catch (Exception ex)
            {
                dtresult.Rows[0]["Estatus_Procedimiento"] = Utilerias._ERROR_;
                ds.Tables.Add(dtresult);

                Utilerias.WriteProblems(ex, null);
            }

            return Utilerias.DataSetToDictionaryArray(ds);
        }



        [HttpPost("reenviar-codigoValidacion")]
        public ActionResult<object> reenviarCodigoValidacion([FromBody] mdlPreclasifica modelRegistro)
        {
            DataSet ds = new DataSet();
            

            try
            {
               
                OTP otp = new OTP(modelRegistro.celular, modelRegistro.correo, modelRegistro.enviarAvisoPor);
                ds = otp.enviarCodigo();

                if (ds.Tables["result"].Rows[0]["Estatus_Procedimiento"].ToString() == Utilerias._OK_)
                {
                    DataSet dsCV = dat.setCodigoValidacion(modelRegistro.idProspecto, otp.codigoValidacion);

                    if (dsCV.Tables["result"].Rows[0]["Estatus_Procedimiento"].ToString() == Utilerias._OK_)
                    {
                        ds.Tables["result"].Rows[0]["Estatus_Procedimiento"] = Utilerias._OK_;
                        ds.Tables["result"].Rows[0]["Mensaje_Procedimiento"] = $"{modelRegistro.enviarAvisoPor} enviado.";
                    }
                    else
                    {
                        ds.Tables["result"].Rows[0]["Estatus_Procedimiento"] = dsCV.Tables["result"].Rows[0]["Estatus_Procedimiento"];
                        ds.Tables["result"].Rows[0]["Mensaje_Procedimiento"] = dsCV.Tables["result"].Rows[0]["Mensaje_Procedimiento"];
                    }
                }


            }
            catch (Exception ex)
            {
                ds.Tables["result"].Rows[0]["Estatus_Procedimiento"] = Utilerias._ERROR_;
                Utilerias.WriteProblems(ex, null);
            }


            return Utilerias.DataSetToDictionaryArray(ds);
        }

        [HttpPost("validar-circulo-credito")]
        public ActionResult<object> validarCirculoCredito([FromBody] mdlPreclasifica modelRegistro)
        {
            DataSet ds = null;
            try
            {
                DataSet dsCC = dat.getConfiguracionCC();

                DataRow drCC = dsCC.Tables["configuracionCC"].Rows[0];

                HttpClient httpClient = new HttpClient();
                string x_api_key = drCC["ccCirucloApiKey"].ToString(); //  _configuration.GetValue<string>("CirucloApiKey");
                string url = _configuration.GetValue<string>("UrlCiculoCredito");
                string urldev = _configuration.GetValue<string>("UrlCiculoCreditoDev");
                string ambiente = _configuration.GetValue<string>("ambiente");
                string user = drCC["ccUserCirculo"].ToString(); //_configuration.GetValue<string>("userCirculo");
                string pass = drCC["ccPassCirculo"].ToString(); //_configuration.GetValue<string>("passCirculo");


                DataSet dsprospecto = dat.getProspecto(modelRegistro.idProspecto, ambiente);

                Client client = new Client(httpClient);
                

                if (ambiente.Equals("prd"))
                {
                    //PersonaPeticion personaPeticion = dat.getPersonPeticion(dsprospecto.Tables["prospecto"]);
                    PersonaPeticion personaPeticion = dat.getPersonPeticionProdEjemplo();
                    client.BaseUrl = url;
                    var payload = JsonConvert.SerializeObject(personaPeticion);
                    var signature = Utils.CryptoUtils.sign(Encoding.UTF8.GetBytes(payload));
                    var response = client.GetReporteCreditoPM(signature, x_api_key, user, pass, personaPeticion);

                    ds = dat.setPrecalificacion(response, modelRegistro);

                }
                else
                {
                    //Esta fijo los datos, realmente no lle la DB, si no puse datos duros de la parte de ejemplo que tiene la API.
                    PersonaPeticion personaPeticion = dat.getPersonPeticion(dsprospecto.Tables["prospecto"]);
                    //PersonaPeticion personaPeticion = dat.getPersonPeticionDevEjemplo();
                    client.BaseUrl = urldev;
                    var response = client.GetReporteCreditoPMDEV(x_api_key, personaPeticion);
                    ds = dat.setPrecalificacion(response, modelRegistro);
                    ds.Tables["result"].Rows[0]["Mensaje_Procedimiento"] = "Petición a la API DEV";
                }


            }
            catch (Exception ex)
            {
                DataTable dt = Utilerias.SchemaDtResult_V2();
                ds = new DataSet();
                ds.Tables.Add(dt);

                ds.Tables["result"].Rows[0]["Estatus_Procedimiento"] = Utilerias._ERROR_;
                Utilerias.WriteProblems(ex, null);
            }


            return Utilerias.DataSetToDictionaryArray(ds);
        }


        [HttpPost("setProspectoMalHistorial")]
        public ActionResult<object> setProspectoMalHistorial([FromBody] mdlPreclasifica modelRegistro)
        {
            DataSet ds = new DataSet();

            try
            {
                //ds = D_Laboratorio.ws_ResLab_getResultados(modelRegistro.CURP, modelRegistro.Fecha_Toma);
                Dictionary<string, object> dydatos = Utilerias.Convert_Model_To_Dictionary(modelRegistro);
                Utilerias.writeLogParametros(dydatos);

                ds = dat.setProspecto(dydatos);

                Utilerias.writeLogResult(ds.Tables["result"]);
                if (ds.Tables["result"].Rows[0]["Estatus_Procedimiento"].ToString() == Utilerias._OK_)
                {
                    dydatos.Add("P_idProspecto", ds.Tables["result"].Rows[0]["ID"].ToString());
                    DataSet dsotp = dat.setPreclasificacion(dydatos);


                }
            }
            catch (Exception ex)
            {
                Utilerias.WriteProblems(ex, null);
            }


            return Utilerias.DataSetToDictionaryArray(ds);
        }


        /// <summary>
        /// Este se ejecuta despues de dar el codigo 
        /// </summary>
        /// <param name="modelRegistro"></param>
        /// <returns></returns>
        [HttpPost("setProspectoAutenticado")]
        public ActionResult<object> setProspectoAutenticado([FromBody] mdlPreclasifica modelRegistro)
        {
            DataSet ds = new DataSet();

            try
            {
                //ds = D_Laboratorio.ws_ResLab_getResultados(modelRegistro.CURP, modelRegistro.Fecha_Toma);
                Dictionary<string, object> dydatos = Utilerias.Convert_Model_To_Dictionary(modelRegistro);
                Utilerias.writeLogParametros(dydatos);

                ds = dat.setProspecto(dydatos);

                Utilerias.writeLogResult(ds.Tables["result"]);
                if (ds.Tables["result"].Rows[0]["Estatus_Procedimiento"].ToString() == Utilerias._OK_)
                {
                    if (!dydatos.ContainsKey("P_idProspecto")) {
                        dydatos.Add("P_idProspecto", ds.Tables["result"].Rows[0]["ID"].ToString());
                    }
                    
                    DataSet dsotp = dat.setPreclasificacion(dydatos);


                }
            }
            catch (Exception ex)
            {
                Utilerias.WriteProblems(ex, null);
            }


            return Utilerias.DataSetToDictionaryArray(ds);
        }

    }
}