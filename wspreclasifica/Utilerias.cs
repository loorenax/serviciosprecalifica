using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace wspreclasifica
{
    public class Utilerias
    {

        public const string _OK_ = "OK";
        public const string _ERROR_ = "ERROR";
        public const string _RESTRICCION_ = "RESTRICCION";

        public const String Fecha_Formato_AAAA_MMM_DD = "yyyy-MMM-dd";
        public const String Hora_Formato_hh_mm_AM_PM = "hh:mm tt";
        public const String Hora_Formato_HH_MM_AM_PM = "HH:mm tt";
        public static IFormatProvider FORMATO_FECHA = System.Globalization.CultureInfo.GetCultureInfo("es-MX").DateTimeFormat;


        public static DataTable SchemaDtResult() {
            DataTable dtSchema = new DataTable();
            dtSchema.Columns.Add("Proceso");
            dtSchema.Columns.Add("Mensaje");
            dtSchema.Columns.Add("Dato_Generado");
            


            return dtSchema;
        }

        public static DataTable SchemaDtResult_V2()
        {
            DataTable dtSchema = new DataTable();
            dtSchema.Columns.Add("Estatus_Procedimiento");
            dtSchema.Columns.Add("Mensaje_Procedimiento");

            DataRow dr = dtSchema.NewRow();
            dtSchema.Rows.Add(dr);
            dtSchema.TableName = "result";
            return dtSchema;
        }


        public static DataTable ProcesoExitoso(string _Message, string _Dato)
        {
            
            DataTable dt = SchemaDtResult();
            DataRow dr = dt.NewRow();
            dr["Proceso"] = "OK";
            dr["Dato_Generado"] = _Dato;
            dr["Mensaje"] = string.IsNullOrEmpty(_Message) ?  "Proceso exitoso!!" : _Message;
            dt.Rows.Add(dr);


            return dt;

        }

        public static DataTable Agrupar_Tipos_Fotos(DataTable _Dt_Listado_Proyectos, DataTable  _Dt_Listado_Proyectos_Fotos, DataTable _Dt_Tipos_Fotos)
        {
            DataTable dt_resultado = new DataTable();
            dt_resultado.Columns.Add("No_Proyecto_Solicitud");
            dt_resultado.Columns.Add("Tipo_Foto_Cierre_ID");
            dt_resultado.Columns.Add("Tipo");
            dt_resultado.Columns.Add("Foto_Tomada");
            dt_resultado.Columns.Add("No_Solicitud_Foto_ID");
            dt_resultado.Columns.Add("Fecha_Foto", typeof(DateTime));

            foreach (DataRow dr in _Dt_Listado_Proyectos.Rows)
            {
                foreach (DataRow dr_Tipo in _Dt_Tipos_Fotos.Rows)
                {
                    DataRow drNuevo;
                    drNuevo = dt_resultado.NewRow();
                    drNuevo["No_Proyecto_Solicitud"] = dr["No_Proyecto_Solicitud"];
                    drNuevo["Tipo_Foto_Cierre_ID"] = dr_Tipo["Tipo_Foto_Cierre_ID"];
                    drNuevo["Tipo"] = dr_Tipo["Tipo"];
                    drNuevo["Foto_Tomada"] = "NO";
                    drNuevo["No_Solicitud_Foto_ID"] = null;
                    drNuevo["Fecha_Foto"] = DBNull.Value;


                    if (dr["Visita_Supervision_ID"] != DBNull.Value) {

                        DataRow[] busqueda_foto = _Dt_Listado_Proyectos_Fotos.Select("No_Proyecto_Solicitud = '" + dr["No_Proyecto_Solicitud"] + "' "
                                                                                      + " AND Tipo_Foto_Cierre_ID = " + dr_Tipo["Tipo_Foto_Cierre_ID"].ToString()
                                                                                      + " AND Visita_Supervision_ID = " + dr["Visita_Supervision_ID"].ToString()
                                                                                      );

                        if (busqueda_foto.Length > 0)
                        {
                            drNuevo["Foto_Tomada"] = "SI";
                            drNuevo["No_Solicitud_Foto_ID"] = busqueda_foto[0]["No_Solicitud_Foto_ID"];
                            drNuevo["Fecha_Foto"] = busqueda_foto[0]["Fecha_Foto"];

                        }
                    }

                    dt_resultado.Rows.Add(drNuevo);
                }

            }

            return dt_resultado;
        }

        public static bool ValidateSource(DataSet ds)
        {
            bool resultado = false;

            if (ds != null) {

                if (ds.Tables.Count > 0) {
                    resultado = true;
                }
            }


            return resultado;
        }

        public static DataTable ProcesoErroneo(Exception _Ex, string _Message)
        {
            DataTable dt = SchemaDtResult();
            DataRow dr = dt.NewRow();
            dr["Proceso"] = "ERROR";
            dr["Mensaje"] = _Message  + " === " + _Ex.Message  + " === " + _Ex.StackTrace;
            dt.Rows.Add(dr);


            return dt;

        }

        public static object GetValueParameterSP(object _Valor)
        {
            
            object resultado = DBNull.Value;
            if (_Valor != null) {
                if (!string.IsNullOrEmpty(_Valor.ToString())) {
                    resultado = _Valor.ToString();
                }
                
            }

            return resultado;
        }
        public static object GetValueParameterSPDate(object _Valor)
        {
            object resultado = DBNull.Value;
            try
            {
                if (_Valor != null)
                {
                    if (string.IsNullOrEmpty(_Valor.ToString().Trim()))
                    {

                    }
                    else
                    {
                        resultado = DateTime.Parse(_Valor.ToString(), FORMATO_FECHA);
                    }
                    
                }
            }
            catch (Exception ex) {
               // AccesoDatos.Set_Registrar_Errores("GetValueParameterSPDate", ex.Message);
            }

            return resultado;
        }

        public static bool WriteProblems(Exception _ex, string _msg)
        {
            bool Bol_Estatus = false;
            string Texto = _msg;
            System.Diagnostics.StackTrace stacktrace = new System.Diagnostics.StackTrace();
            string nombre_metodo = stacktrace.GetFrame(1).GetMethod().Name;

            string ruta = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            string nombre_log = "Log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            string strFile = ruta + @"\" + nombre_log;

            try
            {

                bool fileExists = File.Exists(strFile);

                using (StreamWriter writer = new StreamWriter(strFile, true))
                {
                    if (!fileExists)
                        File.Create(strFile);
                    writer.WriteLine(DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + " " + nombre_metodo);
                    writer.WriteLine("  --> msg: " + Texto);

                    if (_ex != null)
                    {
                        writer.WriteLine("  --> exception: " + (_ex != null ? _ex.Message.ToString() : "No indicado"));
                        writer.WriteLine("  --> source: " + (_ex != null ? _ex.Source.ToString() : "No indicado"));
                        writer.WriteLine("  --> stacktrace: " + (_ex != null ? _ex.StackTrace.ToString() : "No indicado"));
                    }


                    //if (!string.IsNullOrEmpty(_msg)) {
                    //    writer.WriteLine("Mensaje: " + _msg);
                    //}
                }
            }
            catch (Exception exx)
            {
                string mes = exx.Message;
            }

            return Bol_Estatus;
        }

        public static DataTable Agrupar_DataTable(DataTable _Dt_Fuente, string _Campo_Agrupador)
        {
            DataTable dt_resultado = new DataTable();

            string grupo = "___";
            try
            {
                dt_resultado = _Dt_Fuente.Clone();
                foreach (DataRow registro in _Dt_Fuente.Rows)
                {
                    if (!((registro[_Campo_Agrupador].Equals(DBNull.Value))))
                    {
                        if ((grupo != registro[_Campo_Agrupador].ToString() ))
                        {
                            var row_grupo = dt_resultado.NewRow();
                            row_grupo.ItemArray = registro.ItemArray;
                            grupo = registro[_Campo_Agrupador].ToString();
                            dt_resultado.Rows.Add(row_grupo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utilerias.WriteProblems(ex, null);
            }
            return dt_resultado;
        }
        public static bool Fuente_Datos_Valida(DataTable P_Dt)
        {
            var resultado = false;
            if ((P_Dt != null))
            {
                if ((P_Dt.Rows.Count > 0))
                    resultado = true;
            }
            return resultado;
        }

        public static string GenerateTokenJwt(string username, string secretKey)
        {
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                                    new Claim( ClaimTypes.Name, username, ClaimValueTypes.String, "(local)" )
                              }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                                                new SymmetricSecurityKey(key),
                                                SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(createdToken);
        }

        public static Dictionary<string, object> DataTableToDictionary(DataTable _Dt)
        {
            Dictionary<string, object> lst = new Dictionary<string, object>();

            foreach (DataColumn dc in _Dt.Columns)
            {

                foreach (DataRow dr in _Dt.Rows)
                {
                    lst.Add(dc.ColumnName, dr[dc.ColumnName]);
                }
                
            }

            return lst;

        }

        public static List<Dictionary<string, object>>  DataTableToDictionaryList(DataTable _Dt)
        {
            List<Dictionary<string, object>> lst = new List<Dictionary<string, object>>();

            foreach (DataRow dr in _Dt.Rows)
            {
                Dictionary<string, object> dyList = new Dictionary<string, object>();

                foreach (DataColumn dc in _Dt.Columns) {
                    dyList.Add(dc.ColumnName, dr[dc.ColumnName]);
                }

                lst.Add(dyList);
            }

            return lst;
        }
        public static List<KeyValuePair<int, Object>> DataSetToDictionaryList(DataSet _Ds)
        {
            List<KeyValuePair<int, Object>> lstDs = new List<KeyValuePair<int, object>>();


            List<Dictionary<string, object>> lst = new List<Dictionary<string, object>>();

            int countTabla = 0;
            foreach (DataTable dt in _Ds.Tables) {

                foreach (DataRow dr in dt.Rows)
                {
                    Dictionary<string, object> dyList = new Dictionary<string, object>();

                    foreach (DataColumn dc in dt.Columns)
                    {
                        dyList.Add(dc.ColumnName, dr[dc.ColumnName]);
                    }

                    lst.Add(dyList);
                }

                lstDs.Add(new KeyValuePair<int, Object>(countTabla, lst));
                countTabla++;

            }


            return lstDs;
        }


        public static Dictionary<string, object> DataSetToDictionaryArray(DataSet _Ds)
        {
            Dictionary<string, object> dy_resultado = new Dictionary<string, object>();

            int countTabla = 0;
            foreach (DataTable dt in _Ds.Tables)
            {
                List<Dictionary<string, object>> lst = new List<Dictionary<string, object>>();
                foreach (DataRow dr in dt.Rows)
                {
                    Dictionary<string, object> dyList = new Dictionary<string, object>();

                    foreach (DataColumn dc in dt.Columns)
                    {
                        dyList.Add(dc.ColumnName, dr[dc.ColumnName]);
                    }

                    lst.Add(dyList);
                }

                dy_resultado.Add(dt.TableName , lst);
                countTabla++;

            }


            return dy_resultado;
        }








        static string GetMimeType(string ext)
        {
            //    CodecName FilenameExtension FormatDescription MimeType 
            //    .BMP;*.DIB;*.RLE BMP ==> image/bmp 
            //    .JPG;*.JPEG;*.JPE;*.JFIF JPEG ==> image/jpeg 
            //    *.GIF GIF ==> image/gif 
            //    *.TIF;*.TIFF TIFF ==> image/tiff 
            //    *.PNG PNG ==> image/png 
            switch (ext.ToLower())
            {
                case ".bmp":
                case ".dib":
                case ".rle":
                    return "image/bmp";

                case ".jpg":
                case ".jpeg":
                case ".jpe":
                case ".fif":
                    return "image/jpeg";

                case "gif":
                    return "image/gif";
                case ".tif":
                case ".tiff":
                    return "image/tiff";
                case "png":
                    return "image/png";
                default:
                    return "image/jpeg";
            }
        }
        

        public static string EncryptarCadena(string inputString)
        {
            MemoryStream memStream = null;
                byte[] key = { };
                byte[] IV = { 12, 21, 43, 17, 57, 35, 67, 27 };
                string encryptKey = "aXb2uy4z"; // MUST be 8 characters
                key = Encoding.UTF8.GetBytes(encryptKey);
                byte[] byteInput = Encoding.UTF8.GetBytes(inputString);
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                memStream = new MemoryStream();
                ICryptoTransform transform = provider.CreateEncryptor(key, IV);
                CryptoStream cryptoStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
                cryptoStream.Write(byteInput, 0, byteInput.Length);
                cryptoStream.FlushFinalBlock();


            return Convert.ToBase64String(memStream.ToArray());
        }

        public string DesEncriptarCadena(string inputString)
        {
            MemoryStream memStream = null;

                byte[] key = { };
                byte[] IV = { 12, 21, 43, 17, 57, 35, 67, 27 };
                string encryptKey = "aXb2uy4z"; // MUST be 8 characters
                key = Encoding.UTF8.GetBytes(encryptKey);
                byte[] byteInput = new byte[inputString.Length];
                byteInput = Convert.FromBase64String(inputString);
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                memStream = new MemoryStream();
                ICryptoTransform transform = provider.CreateDecryptor(key, IV);
                CryptoStream cryptoStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
                cryptoStream.Write(byteInput, 0, byteInput.Length);
                cryptoStream.FlushFinalBlock();

            Encoding encoding1 = Encoding.UTF8;
            return encoding1.GetString(memStream.ToArray());
        }



        public static object getValueToSP(object _Valor)
        {
            object resultado = DBNull.Value;
            if (_Valor == null)
            {
                // Regrese DBNUL.Value;
            }
            else if (!string.IsNullOrEmpty(_Valor.ToString()))
            {
                resultado = _Valor;
            }

            return resultado;
        }
        public static DateTime? getValueToSPDate(object _Valor)
        {
            DateTime? resultado = null;
            try
            {
                if (_Valor == null)
                {
                    // Regrese DBNUL.Value;
                }
                else if (!string.IsNullOrEmpty(_Valor.ToString()))
                {
                    resultado = DateTime.Parse(_Valor.ToString(), FORMATO_FECHA);
                }

            }
            catch (Exception ex)
            {

                string strfecha = _Valor.ToString();
                strfecha = strfecha.Replace("ENE", "01");
                strfecha = strfecha.Replace("FEB", "02");
                strfecha = strfecha.Replace("MAR", "03");
                strfecha = strfecha.Replace("ABR", "04");
                strfecha = strfecha.Replace("MAY", "05");
                strfecha = strfecha.Replace("JUN", "06");
                strfecha = strfecha.Replace("JUL", "07");
                strfecha = strfecha.Replace("AGO", "08");
                strfecha = strfecha.Replace("SEP", "09");
                strfecha = strfecha.Replace("OCT", "10");
                strfecha = strfecha.Replace("NOV", "11");
                strfecha = strfecha.Replace("DIC", "12");

                resultado = DateTime.Parse(strfecha, FORMATO_FECHA);

            }

            return resultado;
        }

        public static Dictionary<string, object> Convert_Model_To_Dictionary(object _Model)
        {
            Dictionary<string, object> dy_result = new Dictionary<string, object>();

            try
            {

                PropertyInfo[] infos = _Model.GetType().GetProperties();

                Dictionary<string, object> dix = new Dictionary<string, object>();

                foreach (PropertyInfo info in infos)
                {
                    string valor_parametro = (info.GetValue(_Model, null) == null ? "" : info.GetValue(_Model, null).ToString());

                    dix.Add(info.Name, valor_parametro);
                }

                dy_result = dix;
            }
            catch (Exception ex)
            {
                Utilerias.WriteProblems(ex, null);

            }

            return dy_result;
        }


        public static void writeLogParametros(Dictionary<string, object> _DyDatos)
        {

            Utilerias.WriteProblems(null, "Parametros: ");

            foreach (KeyValuePair<string, object> entry in _DyDatos)
            {
                if (entry.Value == DBNull.Value)
                {
                    Utilerias.WriteProblems(null, $"{entry.Key}: esta vacío.");
                }
                else {
                    Utilerias.WriteProblems(null, $"{entry.Key}: {entry.Value.ToString()}");
                }               
            }
        }
        public static void writeLogResult(DataTable dtResult)
        {

            Utilerias.WriteProblems(null, "Result: ");
            
            foreach (DataColumn dc in dtResult.Columns)
            {
                string valores = "";
                if (dtResult.Rows[0][dc.ColumnName] == DBNull.Value)
                {
                    valores += $"{dc.ColumnName}: - vacío -";
                }
                else
                {
                    valores += $"{dc.ColumnName}: {dtResult.Rows[0][dc.ColumnName].ToString()}";
                }

                Utilerias.WriteProblems(null, valores);
            }
        }

    }



}


