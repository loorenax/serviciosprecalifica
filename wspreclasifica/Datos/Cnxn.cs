using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace wspreclasifica.Datos
{
    public class Cnxn
    {
        public static string sCon = "";
        public static string Repositorio_Fotos_Reportes = "";
        public SqlConnection conn = new SqlConnection();

        public Cnxn()
        {
            this.conn = new SqlConnection(sCon);

            //this.conn = new SqlConnection(string.Format("Data Source={0}; Initial Catalog={1}; User ID={2};Password={3}", this.IPAddress, this.DataBase, this.Login, this.Password));

        }

        public Dictionary<string, object> SetFormatDyDatos(Dictionary<string, object> _DyDatos, string spname)
        {

            //Obtienes todos los parametros que utiliza el sp
            DataSet ds_parametros = SqlHelper.ExecuteDataset(sCon, "sys_GetParametroSP", new SqlParameter("P_SP", (object)Utilerias.getValueToSP(spname)));
            ds_parametros.Tables[0].TableName = "dtParameterSP";

            //Se crea un diccionario limpio para que sea en el orden en que estan los parametros del sp
            Dictionary<string, object> dyParametros = new Dictionary<string, object>();

            foreach (DataRow dr in ds_parametros.Tables["dtParameterSP"].Rows)
            {

                //La lectura trae la @, por ello se quita
                string nombreparametro = dr["NombreParametro"].ToString().Replace("@", "");
                string nombreparametroalterno = nombreparametro;

                if (nombreparametro.StartsWith("P_"))
                {
                    //Esto se hizo por que si hago el replace directo truena con algunas, por ejemplo P_CURP_; quita la primer p y la segunda y entonces ya no se encuentra el campo
                    string solo_para_limpiar = "XYZ_" + nombreparametro;
                    nombreparametroalterno = solo_para_limpiar.Replace("XYZ_P_", "");
                }



                //Se va agregando el parametro el nuevo diccionario
                dyParametros.Add(nombreparametro, DBNull.Value);

                //En esta parte lo que se hace es verificar si el parametro viene del diccionario _DyDatos
                //Si viene del parametro que esta enviando el usuaro entonces el valor se toma de _DyDatos
                //Se hacen revisiones especiales que se pueden tomar de la sesion como el nombre del usuario y el id
                //Si no esta simplemente se dejara el valor de nulo
                if (_DyDatos.ContainsKey(nombreparametro))
                {
                    dyParametros[nombreparametro] = _DyDatos[nombreparametro];
                }
                else if (_DyDatos.ContainsKey(nombreparametroalterno))
                {
                    dyParametros[nombreparametro] = _DyDatos[nombreparametroalterno];
                }

                if (dr["tipoDato"].ToString() == "bit") {

                    if (dyParametros[nombreparametro] == null)
                    {
                        dyParametros[nombreparametro] = 0;
                    }
                    else if (string.IsNullOrEmpty(dyParametros[nombreparametro].ToString()))
                    {
                        dyParametros[nombreparametro] = 0;
                    }
                    else {
                        dyParametros[nombreparametro] = (dyParametros[nombreparametro].ToString() == "SI" || dyParametros[nombreparametro].ToString() == "True" ? 1 : 0);
                    }


                }
            }


            return dyParametros;

        }
        public SqlParameter[] getSQLParameters(Dictionary<string, object> _DyDatos)
        {
            SqlParameter[] sqlParameters = new SqlParameter[_DyDatos.Count];

            int irow = 0;
            foreach (KeyValuePair<string, object> entry in _DyDatos)
            {
                sqlParameters[irow] = new SqlParameter(entry.Key, (object)Utilerias.getValueToSP(entry.Value));
                irow++;
            }

            return sqlParameters;

        }


    }
}
