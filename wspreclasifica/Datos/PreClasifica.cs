using ClienteCirculoCreditoPRD;
using Microsoft.ApplicationBlocks.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using wspreclasifica.Models.Preclasifica;

namespace wspreclasifica.Datos
{
    public class PreClasifica
    {
        private Cnxn cnxn = new Cnxn();

        public DataSet getColoniasByCP(string _codigoPostal)
        {
            DataSet ds = null;
            string spname = "stdGetColoniasByCP";
            Dictionary<string, object> dyparametros = new Dictionary<string, object>();
            dyparametros.Add("P_Codigo_Postal", _codigoPostal);

            Dictionary<string, object> dydatos = cnxn.SetFormatDyDatos(dyparametros, spname);
            SqlParameter[] sqlparameters = cnxn.getSQLParameters(dydatos);

            ds = SqlHelper.ExecuteDataset(Cnxn.sCon, spname, sqlparameters);
            ds.Tables[0].TableName = "colonias";
            return ds;
        }
        public DataSet setProspecto(Dictionary<string, object> _Dyparametros)
        {
            DataSet ds = null;
            string spname = "prospectosSetProspecto";

            Dictionary<string, object> dydatos = cnxn.SetFormatDyDatos(_Dyparametros, spname);
            SqlParameter[] sqlparameters = cnxn.getSQLParameters(dydatos);

            ds = SqlHelper.ExecuteDataset(Cnxn.sCon, spname, sqlparameters);
            ds.Tables[0].TableName = "result";
            if (ds.Tables.Count > 1) {
                ds.Tables[1].TableName = "configuracionCorreo";
            }
            return ds;
        }
        public DataSet setCodigoValidacion(string _idProspecto, string _codigoValidacion)
        {
            DataSet ds = null;
            string spname = "prospectosSetcodigoValidacion";

            Dictionary<string, object> _Dyparametros = new Dictionary<string, object>();
            _Dyparametros.Add("P_idProspecto", _idProspecto);
            string codigoValidacion = Utilerias.EncryptarCadena(_codigoValidacion);
            _Dyparametros.Add("P_codigoValidacion", codigoValidacion);

            Dictionary<string, object> dydatos = cnxn.SetFormatDyDatos(_Dyparametros, spname);
            SqlParameter[] sqlparameters = cnxn.getSQLParameters(dydatos);

            ds = SqlHelper.ExecuteDataset(Cnxn.sCon, spname, sqlparameters);
            ds.Tables[0].TableName = "result";

            return ds;
        }
        public DataSet autenticacionCodigo(string _idProspecto, string _codigoValidacion)
        {
            DataSet ds = null;
            string spname = "prospectosSetAutenticacionCodigo";

            Dictionary<string, object> _Dyparametros = new Dictionary<string, object>();
            _Dyparametros.Add("P_idProspecto", _idProspecto);
            string codigoValidacion = Utilerias.EncryptarCadena(_codigoValidacion);
            _Dyparametros.Add("P_codigoValidacion", codigoValidacion);

            Dictionary<string, object> dydatos = cnxn.SetFormatDyDatos(_Dyparametros, spname);
            SqlParameter[] sqlparameters = cnxn.getSQLParameters(dydatos);

            ds = SqlHelper.ExecuteDataset(Cnxn.sCon, spname, sqlparameters);
            ds.Tables[0].TableName = "result";

            return ds;
        }
        public DataSet getConfiguracionCorreo()
        {
            DataSet ds = null;
            string spname = "stdGetParametrosCorreo";

            ds = SqlHelper.ExecuteDataset(Cnxn.sCon, spname, null);
            ds.Tables[0].TableName = "configuracionCorreo";

            return ds;
        }
        public DataSet getConfiguracionWhatsApp()
        {
            DataSet ds = null;
            string spname = "stdGetParametrosWhatsApp";

            ds = SqlHelper.ExecuteDataset(Cnxn.sCon, spname, null);
            ds.Tables[0].TableName = "configuracionWhatsApp";

            return ds;
        }
        public DataSet getConfiguracionCC()
        {
            DataSet ds = null;
            string spname = "stdGetParametrosCirculoCredito";

            ds = SqlHelper.ExecuteDataset(Cnxn.sCon, spname, null);
            ds.Tables[0].TableName = "configuracionCC";

            return ds;
        }


        public DataSet setPreclasificacion(Dictionary<string, object> _Dyparametros)
        {
            DataSet ds = null;
            string spname = "prospectosSetPreclasificacion";

            Dictionary<string, object> dydatos = cnxn.SetFormatDyDatos(_Dyparametros, spname);
            SqlParameter[] sqlparameters = cnxn.getSQLParameters(dydatos);

            ds = SqlHelper.ExecuteDataset(Cnxn.sCon, spname, sqlparameters);
            ds.Tables[0].TableName = "result";
            return ds;
        }
        public DataSet setPrecalificacion(ReporteRespuesta _response, mdlPreclasifica _modelRegistro)
        {

            int nivelaceptacion = 1;

            foreach (var ctacomercial in _response.Credito.CuentasComerciales)
            {

                if (ctacomercial.AtrasoMayor >= 61)
                {
                    nivelaceptacion = 3;
                    break;
                }
                else if (ctacomercial.AtrasoMayor > 0 && nivelaceptacion < 3)
                {
                    nivelaceptacion = 2;
                }

            }

            if (nivelaceptacion == 1)
            {
                foreach (var ctafinanciera in _response.Credito.CuentasFinancieras)
                {
                    if (ctafinanciera.AtrasoMayor >= 61)
                    {
                        nivelaceptacion = 3;
                        break;
                    }
                    else if (ctafinanciera.AtrasoMayor > 0 && nivelaceptacion < 3)
                    {
                        nivelaceptacion = 2;
                    }

                }

            }

            Dictionary<string, object> dynivelaceptacion = Utilerias.Convert_Model_To_Dictionary(_modelRegistro);
            dynivelaceptacion.Add("P_nivelAceptacion", nivelaceptacion);
            dynivelaceptacion.Add("P_responseAPI", JsonConvert.SerializeObject(_response));


            DataSet ds = null;
            string spname = "prospectosSetPreclasificacion";

            Dictionary<string, object> dydatos = cnxn.SetFormatDyDatos(dynivelaceptacion, spname);
            SqlParameter[] sqlparameters = cnxn.getSQLParameters(dydatos);

            ds = SqlHelper.ExecuteDataset(Cnxn.sCon, spname, sqlparameters);
            ds.Tables[0].TableName = "result";
            return ds;

        }
        public DataSet getProspecto(string _idProspecto, string _ambiente)
        {
            DataSet ds = null;
            string spname = "prospectosGetProspectoModel";
            Dictionary<string, object> _Dyparametros = new Dictionary<string, object>();
            _Dyparametros.Add("P_idProspecto", _idProspecto);
            _Dyparametros.Add("P_ambiente", _ambiente);


            Dictionary<string, object> dydatos = cnxn.SetFormatDyDatos(_Dyparametros, spname);
            SqlParameter[] sqlparameters = cnxn.getSQLParameters(dydatos);

            ds = SqlHelper.ExecuteDataset(Cnxn.sCon, spname, sqlparameters);
            ds.Tables[0].TableName = "prospecto";

            return ds;
        }



        public PersonaPeticion getPersonPeticion(DataTable _dtProspecto)
        {
            DataRow dr = _dtProspecto.Rows[0];

            int iestado = (int.Parse(dr["Codigo_Estado"].ToString()) - 1);

            var personaPeticion = new PersonaPeticion()
            {
                FolioOtorgante = dr["FolioOtorgante"].ToString(),
                Persona = new Persona()
                {
                    Nombre = dr["nombreCompleto"].ToString(),
                    RFC = dr["rfc"].ToString(),
                    Domicilio = new Domicilio()
                    {
                        Pais = CatalogoPais.MX,
                        Estado = (CatalogoEstados)iestado,
                        Ciudad = dr["Ciudad"].ToString(),
                        ColoniaPoblacion = dr["Colonia"].ToString(),
                        CP = dr["CP"].ToString(),
                        DelegacionMunicipio = dr["Municipio"].ToString(),
                        Direccion = dr["Direccion"].ToString()
                    }
                }
            };

            return personaPeticion;

        }


        public PersonaPeticion getPersonPeticionProdEjemplo()
        {
            var personaPeticion = new PersonaPeticion()
            {
                FolioOtorgante = "7632",
                Persona = new Persona()
                {
                    Nombre = "EMPRESA SA DE CV",
                    RFC = "ADS990201AN1",
                    Domicilio = new Domicilio()
                    {
                        Pais = CatalogoPais.MX,
                        Estado = CatalogoEstados.AGS,
                        Ciudad = "ZAPOPAN",
                        ColoniaPoblacion = "DESARROLLO ZAPOPAN NORTE",
                        CP = "45145",
                        DelegacionMunicipio = "DEL VALLE",
                        Direccion = "CALLE INDUSTRIA ZAPATERA   66",
                        EstadoExtranjero = "ALB"                        
                    }
                }
            };

            return personaPeticion;

        }
        public PersonaPeticion getPersonPeticionDevEjemplo()
        {
            var personaPeticion = new PersonaPeticion()
            {
                //FolioOtorgante = "1000002",
                FolioOtorgante = "1000002",
                Persona = new Persona()
                {
                    Nombre = "EMPRESA TI SA DE CV",
                    RFC = "EDC930121E02",
                    Domicilio = new Domicilio()
                    {
                        Pais = CatalogoPais.MX,
                        Estado = CatalogoEstados.CDMX,
                        Ciudad = "CUAUHTEMOC",
                        ColoniaPoblacion = "GUERRERO",
                        CP = "68370",
                        DelegacionMunicipio = "CUAUHTEMOC",
                        Direccion = "AV. PASEO DE LA REFORMA 02"
                    }
                }
            };

            return personaPeticion;

        }


        public PersonaPeticion getPersonPeticionPrdEjemploLEC()
        {
            var personaPeticion = new PersonaPeticion()
            {
                FolioOtorgante = "15",
                // FolioOtorgante = modelRegistro.idProspecto
                Persona = new Persona()
                {
                    Nombre = "LORENA ESPINOZA CUEVAS",
                    RFC = "EICL8009041B6",
                    Domicilio = new Domicilio()
                    {
                        Pais = CatalogoPais.MX,
                        Estado = (CatalogoEstados)11,
                        Ciudad = "IRAPUATO",
                        ColoniaPoblacion = "VALLE REAL",
                        CP = "36625",
                        DelegacionMunicipio = "IRAPUATO",
                        Direccion = "VALLE DEL DANUBIO 128 A"
                    }
                }
            };

            return personaPeticion;

        }



    }
}
