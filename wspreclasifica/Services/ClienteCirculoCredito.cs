
namespace ClienteCirculoCreditoPRD
{
    using System = global::System;

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.14.1.0 (NJsonSchema v10.5.2.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class Client
    {
        private string _baseUrl = "https://services.circulodecredito.com.mx/";
        private System.Net.Http.HttpClient _httpClient;
        private System.Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;

        public Client(System.Net.Http.HttpClient httpClient)
        {
            _httpClient = httpClient;
            _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>(CreateSerializerSettings);
        }

        private Newtonsoft.Json.JsonSerializerSettings CreateSerializerSettings()
        {
            var settings = new Newtonsoft.Json.JsonSerializerSettings();
            UpdateJsonSerializerSettings(settings);
            return settings;
        }

        public string BaseUrl
        {
            get { return _baseUrl; }
            set { _baseUrl = value; }
        }

        protected Newtonsoft.Json.JsonSerializerSettings JsonSerializerSettings { get { return _settings.Value; } }

        partial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings);


        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
        partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);

        /// <summary></summary>
        /// <param name="x_signature">Firma generada con la llave privada</param>
        /// <param name="x_api_key">ConsumerKey obtenido desde el portal de desarrolladores</param>
        /// <returns>OK</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public string GetSecurityTest(string x_signature, string x_api_key)
        {
            return System.Threading.Tasks.Task.Run(async () => await GetSecurityTestAsync(x_signature, x_api_key, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        public async System.Threading.Tasks.Task<string> GetSecurityTestAsync(string x_signature, string x_api_key,  System.Threading.CancellationToken cancellationToken)
        {

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/v1/securitytest");

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    if (x_signature == null)
                        throw new System.ArgumentNullException("x_signature");
                    request_.Headers.TryAddWithoutValidation("x-signature", ConvertToString(x_signature, System.Globalization.CultureInfo.InvariantCulture));
                    if (x_api_key == null)
                        throw new System.ArgumentNullException("x_api_key");
                    request_.Headers.TryAddWithoutValidation("x-api-key", ConvertToString(x_api_key, System.Globalization.CultureInfo.InvariantCulture));

                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        //var status_ = (int)response_.StatusCode;
                        return response_.ToString();
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }








        /// <summary>Generación de Reporte de Crédito Consolidado de Personas Morales</summary>
        /// <param name="x_signature">Firma generada con la llave privada</param>
        /// <param name="x_api_key">ConsumerKey obtenido desde el portal de desarrolladores</param>
        /// <param name="username">Usuario de Círculo de Crédito</param>
        /// <param name="password">Contraseña de Círculo de Crédito</param>
        /// <param name="body">Solicitud para consultar reporte de crédito personas morales.</param>
        /// <returns>OK</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ReporteRespuesta> GetReporteCreditoPMAsync(string x_signature, string x_api_key, string username, string password, PersonaPeticion body)
        {
            return GetReporteCreditoPMAsync(x_signature, x_api_key, username, password, body, System.Threading.CancellationToken.None);
        }

        /// <summary>Generación de Reporte de Crédito Consolidado de Personas Morales</summary>
        /// <param name="x_signature">Firma generada con la llave privada</param>
        /// <param name="x_api_key">ConsumerKey obtenido desde el portal de desarrolladores</param>
        /// <param name="username">Usuario de Círculo de Crédito</param>
        /// <param name="password">Contraseña de Círculo de Crédito</param>
        /// <param name="body">Solicitud para consultar reporte de crédito personas morales.</param>
        /// <returns>OK</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public ReporteRespuesta GetReporteCreditoPM(string x_signature, string x_api_key, string username, string password, PersonaPeticion body)
        {
            return System.Threading.Tasks.Task.Run(async () => await GetReporteCreditoPMAsync(x_signature, x_api_key, username, password, body, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Generación de Reporte de Crédito Consolidado de Personas Morales</summary>
        /// <param name="x_signature">Firma generada con la llave privada</param>
        /// <param name="x_api_key">ConsumerKey obtenido desde el portal de desarrolladores</param>
        /// <param name="username">Usuario de Círculo de Crédito</param>
        /// <param name="password">Contraseña de Círculo de Crédito</param>
        /// <param name="body">Solicitud para consultar reporte de crédito personas morales.</param>
        /// <returns>OK</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ReporteRespuesta> GetReporteCreditoPMAsync(string x_signature, string x_api_key, string username, string password, PersonaPeticion body, System.Threading.CancellationToken cancellationToken)
        {
            if (body == null)
                throw new System.ArgumentNullException("body");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/v1/rcc-pm");

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    if (x_signature == null)
                        throw new System.ArgumentNullException("x_signature");
                    request_.Headers.TryAddWithoutValidation("x-signature", ConvertToString(x_signature, System.Globalization.CultureInfo.InvariantCulture));
                    if (x_api_key == null)
                        throw new System.ArgumentNullException("x_api_key");
                    request_.Headers.TryAddWithoutValidation("x-api-key", ConvertToString(x_api_key, System.Globalization.CultureInfo.InvariantCulture));
                    if (username == null)
                        throw new System.ArgumentNullException("username");
                    request_.Headers.TryAddWithoutValidation("username", ConvertToString(username, System.Globalization.CultureInfo.InvariantCulture));
                    if (password == null)
                        throw new System.ArgumentNullException("password");
                    request_.Headers.TryAddWithoutValidation("password", ConvertToString(password, System.Globalization.CultureInfo.InvariantCulture));
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<ReporteRespuesta>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if (status_ == 400)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<Errores>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<Errores>("BAD REQUEST", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                        else
                        if (status_ == 401)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<Errores>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<Errores>("UNAUTHORIZED", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                        else
                        if (status_ == 403)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<Errores>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<Errores>("FORBIDDEN", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                        else
                        if (status_ == 404)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<Errores>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<Errores>("NOT FOUND", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                        else
                        if (status_ == 429)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<Errores>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<Errores>("TOO MANY REQUESTS", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                        else
                        if (status_ == 500)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<Errores>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<Errores>("INTERNAL SERVER ERROR", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                        else
                        if (status_ == 503)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<Errores>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<Errores>("SERVICE UNAVAILABLE", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }


        /// <summary>Generación de Reporte de Crédito Consolidado de Personas Morales</summary>
        /// <param name="x_api_key">ConsumerKey obtenido desde el portal de desarrolladores</param>
        /// <param name="body">&lt;p&gt;Ejemplos para generar diferentes respuestas:&lt;br&gt;&lt;ul&gt;&lt;li&gt;&lt;b&gt;Status Code 200. Sin clave de prevenciones y declarativas&lt;/b&gt;&lt;br&gt;{&lt;ol&gt;"folioOtorgante": "1000001",&lt;br&gt;"persona": {&lt;br&gt;&lt;ol&gt;"RFC": "EDC930121E01",&lt;br&gt;"nombre": "RESTAURANTE SA DE CV",&lt;br&gt;"domicilio": {&lt;br&gt;&lt;ol&gt;"direccion": "AV. PASEO DE LA REFORMA 01",&lt;br&gt;"coloniaPoblacion": "GUERRERO",&lt;br&gt;"delegacionMunicipio": "CUAUHTEMOC",&lt;br&gt;"ciudad": "CIUDAD DE MÉXICO",&lt;br&gt;"estado": "DF",&lt;br&gt;"CP": "68370",&lt;br&gt;"pais": "MX"&lt;/ol&gt;}&lt;/ol&gt;}&lt;/ol&gt;}&lt;/li&gt;       &lt;li&gt;&lt;b&gt;Status Code 200. Con clave de prevenciones y declarativas&lt;/b&gt;&lt;br&gt;{&lt;ol&gt;"folioOtorgante": "1000002",&lt;br&gt;"persona": {&lt;br&gt;&lt;ol&gt;"RFC": "EDC930121E02",&lt;br&gt;"nombre": "EMPRESA TI SA DE CV",&lt;br&gt;"domicilio": {&lt;br&gt;&lt;ol&gt;"direccion": "AV. PASEO DE LA REFORMA 02",&lt;br&gt;"coloniaPoblacion": "GUERRERO",&lt;br&gt;"delegacionMunicipio": "CUAUHTEMOC",&lt;br&gt;"ciudad": "CIUDAD DE MÉXICO",&lt;br&gt;"estado": "DF",&lt;br&gt;"CP": "68370",&lt;br&gt;"pais": "MX"&lt;/ol&gt;}&lt;/ol&gt;}&lt;/ol&gt;}&lt;/li&gt;       &lt;cite&gt;&lt;b&gt;Nota:&lt;/b&gt; Para más casos con Status Code 200, consulte la colección de Postman&lt;/cite&gt;&lt;br&gt;&lt;br&gt;&lt;br&gt;       &lt;li&gt;&lt;b&gt;Status Code 400&lt;/b&gt;&lt;br&gt;{&lt;ol&gt;"folioOtorgante": "",&lt;br&gt;"persona": {&lt;br&gt;&lt;ol&gt;"RFC": null,&lt;br&gt;"nombre": "RESTAURANTE SA DE CV",&lt;br&gt;"domicilio": {&lt;br&gt;&lt;ol&gt;"direccion": "AV. PASEO DE LA REFORMA 01",&lt;br&gt;"coloniaPoblacion": "GUERRERO",&lt;br&gt;"ciudad": "CIUDAD DE MÉXICO",&lt;br&gt;"estado": "DF",&lt;br&gt;"CP": "68370",&lt;br&gt;"pais": "MXX"&lt;/ol&gt;}&lt;/ol&gt;}&lt;/ol&gt;}&lt;/li&gt;       &lt;li&gt;&lt;b&gt;Status Code 401&lt;/b&gt;&lt;br&gt;{&lt;ol&gt;"folioOtorgante": "1000092",&lt;br&gt;"persona": {&lt;br&gt;&lt;ol&gt;"RFC": "EMP930121E92",&lt;br&gt;"nombre": "EMPRESA SA DE CV",&lt;br&gt;"domicilio": {&lt;br&gt;&lt;ol&gt;"direccion": "AV. PASEO DE LA REFORMA 92",&lt;br&gt;"coloniaPoblacion": "GUERRERO",&lt;br&gt;"delegacionMunicipio": "CUAUHTEMOC",&lt;br&gt;"ciudad": "CIUDAD DE MÉXICO",&lt;br&gt;"estado": "DF",&lt;br&gt;"CP": "68370",&lt;br&gt;"pais": "MX"&lt;/ol&gt;}&lt;/ol&gt;}&lt;/ol&gt;}&lt;/li&gt;       &lt;li&gt;&lt;b&gt;Status Code 403&lt;/b&gt;&lt;br&gt;{&lt;ol&gt;"folioOtorgante": "1000095",&lt;br&gt;"persona": {&lt;br&gt;&lt;ol&gt;"RFC": "EMP930121E95",&lt;br&gt;"nombre": "EMPRESA SA DE CV",&lt;br&gt;"domicilio": {&lt;br&gt;&lt;ol&gt;"direccion": "AV. PASEO DE LA REFORMA 95",&lt;br&gt;"coloniaPoblacion": "GUERRERO",&lt;br&gt;"delegacionMunicipio": "CUAUHTEMOC",&lt;br&gt;"ciudad": "CIUDAD DE MÉXICO",&lt;br&gt;"estado": "DF",&lt;br&gt;"CP": "68370",&lt;br&gt;"pais": "MX"&lt;/ol&gt;}&lt;/ol&gt;}&lt;/ol&gt;}&lt;/li&gt;       &lt;li&gt;&lt;b&gt;Status Code 404&lt;/b&gt;&lt;br&gt;{&lt;ol&gt;"folioOtorgante": "1000096",&lt;br&gt;"persona": {&lt;br&gt;&lt;ol&gt;"RFC": "EMP930121E96",&lt;br&gt;"nombre": "EMPRESA SA DE CV",&lt;br&gt;"domicilio": {&lt;br&gt;&lt;ol&gt;"direccion": "AV. PASEO DE LA REFORMA 96",&lt;br&gt;"coloniaPoblacion": "GUERRERO",&lt;br&gt;"delegacionMunicipio": "CUAUHTEMOC",&lt;br&gt;"ciudad": "CIUDAD DE MÉXICO",&lt;br&gt;"estado": "DF",&lt;br&gt;"CP": "68370",&lt;br&gt;"pais": "MX"&lt;/ol&gt;}&lt;/ol&gt;}&lt;/ol&gt;}&lt;/li&gt;       &lt;li&gt;&lt;b&gt;Status Code 429&lt;/b&gt;&lt;br&gt;{&lt;ol&gt;"folioOtorgante": "1000097",&lt;br&gt;"persona": {&lt;br&gt;&lt;ol&gt;"RFC": "EMP930121E97",&lt;br&gt;"nombre": "EMPRESA SA DE CV",&lt;br&gt;"domicilio": {&lt;br&gt;&lt;ol&gt;"direccion": "AV. PASEO DE LA REFORMA 97",&lt;br&gt;"coloniaPoblacion": "GUERRERO",&lt;br&gt;"delegacionMunicipio": "CUAUHTEMOC",&lt;br&gt;"ciudad": "CIUDAD DE MÉXICO",&lt;br&gt;"estado": "DF",&lt;br&gt;"CP": "68370",&lt;br&gt;"pais": "MX"&lt;/ol&gt;}&lt;/ol&gt;}&lt;/ol&gt;}&lt;/li&gt;       &lt;li&gt;&lt;b&gt;Status Code 500&lt;/b&gt;&lt;br&gt;{&lt;ol&gt;"folioOtorgante": "1000098",&lt;br&gt;"persona": {&lt;br&gt;&lt;ol&gt;"RFC": "EMP930121E98",&lt;br&gt;"nombre": "EMPRESA SA DE CV",&lt;br&gt;"domicilio": {&lt;br&gt;&lt;ol&gt;"direccion": "AV. PASEO DE LA REFORMA 98",&lt;br&gt;"coloniaPoblacion": "GUERRERO",&lt;br&gt;"delegacionMunicipio": "CUAUHTEMOC",&lt;br&gt;"ciudad": "CIUDAD DE MÉXICO",&lt;br&gt;"estado": "DF",&lt;br&gt;"CP": "68370",&lt;br&gt;"pais": "MX"&lt;/ol&gt;}&lt;/ol&gt;}&lt;/ol&gt;}&lt;/li&gt;       &lt;li&gt;&lt;b&gt;Status Code 503&lt;/b&gt;&lt;br&gt;{&lt;ol&gt;"folioOtorgante": "1000099",&lt;br&gt;"persona": {&lt;br&gt;&lt;ol&gt;"RFC": "EMP930121E99",&lt;br&gt;"nombre": "EMPRESA SA DE CV",&lt;br&gt;"domicilio": {&lt;br&gt;&lt;ol&gt;"direccion": "AV. PASEO DE LA REFORMA 99",&lt;br&gt;"coloniaPoblacion": "GUERRERO",&lt;br&gt;"delegacionMunicipio": "CUAUHTEMOC",&lt;br&gt;"ciudad": "CIUDAD DE MÉXICO",&lt;br&gt;"estado": "DF",&lt;br&gt;"CP": "68370",&lt;br&gt;"pais": "MX"&lt;/ol&gt;}&lt;/ol&gt;}&lt;/ol&gt;}&lt;/li&gt;       &lt;/ul&gt;&lt;/p&gt;</param>
        /// <returns>OK</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public ReporteRespuesta GetReporteCreditoPMDEV(string x_api_key, PersonaPeticion body)
        {
            return System.Threading.Tasks.Task.Run(async () => await GetReporteCreditoPMAsyncDEV(x_api_key, body, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Generación de Reporte de Crédito Consolidado de Personas Morales</summary>
        /// <param name="x_api_key">ConsumerKey obtenido desde el portal de desarrolladores</param>
        /// <param name="body">&lt;p&gt;Ejemplos para generar diferentes respuestas:&lt;br&gt;&lt;ul&gt;&lt;li&gt;&lt;b&gt;Status Code 200. Sin clave de prevenciones y declarativas&lt;/b&gt;&lt;br&gt;{&lt;ol&gt;"folioOtorgante": "1000001",&lt;br&gt;"persona": {&lt;br&gt;&lt;ol&gt;"RFC": "EDC930121E01",&lt;br&gt;"nombre": "RESTAURANTE SA DE CV",&lt;br&gt;"domicilio": {&lt;br&gt;&lt;ol&gt;"direccion": "AV. PASEO DE LA REFORMA 01",&lt;br&gt;"coloniaPoblacion": "GUERRERO",&lt;br&gt;"delegacionMunicipio": "CUAUHTEMOC",&lt;br&gt;"ciudad": "CIUDAD DE MÉXICO",&lt;br&gt;"estado": "DF",&lt;br&gt;"CP": "68370",&lt;br&gt;"pais": "MX"&lt;/ol&gt;}&lt;/ol&gt;}&lt;/ol&gt;}&lt;/li&gt;       &lt;li&gt;&lt;b&gt;Status Code 200. Con clave de prevenciones y declarativas&lt;/b&gt;&lt;br&gt;{&lt;ol&gt;"folioOtorgante": "1000002",&lt;br&gt;"persona": {&lt;br&gt;&lt;ol&gt;"RFC": "EDC930121E02",&lt;br&gt;"nombre": "EMPRESA TI SA DE CV",&lt;br&gt;"domicilio": {&lt;br&gt;&lt;ol&gt;"direccion": "AV. PASEO DE LA REFORMA 02",&lt;br&gt;"coloniaPoblacion": "GUERRERO",&lt;br&gt;"delegacionMunicipio": "CUAUHTEMOC",&lt;br&gt;"ciudad": "CIUDAD DE MÉXICO",&lt;br&gt;"estado": "DF",&lt;br&gt;"CP": "68370",&lt;br&gt;"pais": "MX"&lt;/ol&gt;}&lt;/ol&gt;}&lt;/ol&gt;}&lt;/li&gt;       &lt;cite&gt;&lt;b&gt;Nota:&lt;/b&gt; Para más casos con Status Code 200, consulte la colección de Postman&lt;/cite&gt;&lt;br&gt;&lt;br&gt;&lt;br&gt;       &lt;li&gt;&lt;b&gt;Status Code 400&lt;/b&gt;&lt;br&gt;{&lt;ol&gt;"folioOtorgante": "",&lt;br&gt;"persona": {&lt;br&gt;&lt;ol&gt;"RFC": null,&lt;br&gt;"nombre": "RESTAURANTE SA DE CV",&lt;br&gt;"domicilio": {&lt;br&gt;&lt;ol&gt;"direccion": "AV. PASEO DE LA REFORMA 01",&lt;br&gt;"coloniaPoblacion": "GUERRERO",&lt;br&gt;"ciudad": "CIUDAD DE MÉXICO",&lt;br&gt;"estado": "DF",&lt;br&gt;"CP": "68370",&lt;br&gt;"pais": "MXX"&lt;/ol&gt;}&lt;/ol&gt;}&lt;/ol&gt;}&lt;/li&gt;       &lt;li&gt;&lt;b&gt;Status Code 401&lt;/b&gt;&lt;br&gt;{&lt;ol&gt;"folioOtorgante": "1000092",&lt;br&gt;"persona": {&lt;br&gt;&lt;ol&gt;"RFC": "EMP930121E92",&lt;br&gt;"nombre": "EMPRESA SA DE CV",&lt;br&gt;"domicilio": {&lt;br&gt;&lt;ol&gt;"direccion": "AV. PASEO DE LA REFORMA 92",&lt;br&gt;"coloniaPoblacion": "GUERRERO",&lt;br&gt;"delegacionMunicipio": "CUAUHTEMOC",&lt;br&gt;"ciudad": "CIUDAD DE MÉXICO",&lt;br&gt;"estado": "DF",&lt;br&gt;"CP": "68370",&lt;br&gt;"pais": "MX"&lt;/ol&gt;}&lt;/ol&gt;}&lt;/ol&gt;}&lt;/li&gt;       &lt;li&gt;&lt;b&gt;Status Code 403&lt;/b&gt;&lt;br&gt;{&lt;ol&gt;"folioOtorgante": "1000095",&lt;br&gt;"persona": {&lt;br&gt;&lt;ol&gt;"RFC": "EMP930121E95",&lt;br&gt;"nombre": "EMPRESA SA DE CV",&lt;br&gt;"domicilio": {&lt;br&gt;&lt;ol&gt;"direccion": "AV. PASEO DE LA REFORMA 95",&lt;br&gt;"coloniaPoblacion": "GUERRERO",&lt;br&gt;"delegacionMunicipio": "CUAUHTEMOC",&lt;br&gt;"ciudad": "CIUDAD DE MÉXICO",&lt;br&gt;"estado": "DF",&lt;br&gt;"CP": "68370",&lt;br&gt;"pais": "MX"&lt;/ol&gt;}&lt;/ol&gt;}&lt;/ol&gt;}&lt;/li&gt;       &lt;li&gt;&lt;b&gt;Status Code 404&lt;/b&gt;&lt;br&gt;{&lt;ol&gt;"folioOtorgante": "1000096",&lt;br&gt;"persona": {&lt;br&gt;&lt;ol&gt;"RFC": "EMP930121E96",&lt;br&gt;"nombre": "EMPRESA SA DE CV",&lt;br&gt;"domicilio": {&lt;br&gt;&lt;ol&gt;"direccion": "AV. PASEO DE LA REFORMA 96",&lt;br&gt;"coloniaPoblacion": "GUERRERO",&lt;br&gt;"delegacionMunicipio": "CUAUHTEMOC",&lt;br&gt;"ciudad": "CIUDAD DE MÉXICO",&lt;br&gt;"estado": "DF",&lt;br&gt;"CP": "68370",&lt;br&gt;"pais": "MX"&lt;/ol&gt;}&lt;/ol&gt;}&lt;/ol&gt;}&lt;/li&gt;       &lt;li&gt;&lt;b&gt;Status Code 429&lt;/b&gt;&lt;br&gt;{&lt;ol&gt;"folioOtorgante": "1000097",&lt;br&gt;"persona": {&lt;br&gt;&lt;ol&gt;"RFC": "EMP930121E97",&lt;br&gt;"nombre": "EMPRESA SA DE CV",&lt;br&gt;"domicilio": {&lt;br&gt;&lt;ol&gt;"direccion": "AV. PASEO DE LA REFORMA 97",&lt;br&gt;"coloniaPoblacion": "GUERRERO",&lt;br&gt;"delegacionMunicipio": "CUAUHTEMOC",&lt;br&gt;"ciudad": "CIUDAD DE MÉXICO",&lt;br&gt;"estado": "DF",&lt;br&gt;"CP": "68370",&lt;br&gt;"pais": "MX"&lt;/ol&gt;}&lt;/ol&gt;}&lt;/ol&gt;}&lt;/li&gt;       &lt;li&gt;&lt;b&gt;Status Code 500&lt;/b&gt;&lt;br&gt;{&lt;ol&gt;"folioOtorgante": "1000098",&lt;br&gt;"persona": {&lt;br&gt;&lt;ol&gt;"RFC": "EMP930121E98",&lt;br&gt;"nombre": "EMPRESA SA DE CV",&lt;br&gt;"domicilio": {&lt;br&gt;&lt;ol&gt;"direccion": "AV. PASEO DE LA REFORMA 98",&lt;br&gt;"coloniaPoblacion": "GUERRERO",&lt;br&gt;"delegacionMunicipio": "CUAUHTEMOC",&lt;br&gt;"ciudad": "CIUDAD DE MÉXICO",&lt;br&gt;"estado": "DF",&lt;br&gt;"CP": "68370",&lt;br&gt;"pais": "MX"&lt;/ol&gt;}&lt;/ol&gt;}&lt;/ol&gt;}&lt;/li&gt;       &lt;li&gt;&lt;b&gt;Status Code 503&lt;/b&gt;&lt;br&gt;{&lt;ol&gt;"folioOtorgante": "1000099",&lt;br&gt;"persona": {&lt;br&gt;&lt;ol&gt;"RFC": "EMP930121E99",&lt;br&gt;"nombre": "EMPRESA SA DE CV",&lt;br&gt;"domicilio": {&lt;br&gt;&lt;ol&gt;"direccion": "AV. PASEO DE LA REFORMA 99",&lt;br&gt;"coloniaPoblacion": "GUERRERO",&lt;br&gt;"delegacionMunicipio": "CUAUHTEMOC",&lt;br&gt;"ciudad": "CIUDAD DE MÉXICO",&lt;br&gt;"estado": "DF",&lt;br&gt;"CP": "68370",&lt;br&gt;"pais": "MX"&lt;/ol&gt;}&lt;/ol&gt;}&lt;/ol&gt;}&lt;/li&gt;       &lt;/ul&gt;&lt;/p&gt;</param>
        /// <returns>OK</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ReporteRespuesta> GetReporteCreditoPMAsyncDEV(string x_api_key, PersonaPeticion body, System.Threading.CancellationToken cancellationToken)
        {
            if (body == null)
                throw new System.ArgumentNullException("body");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/v1/rcc-pm");

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    if (x_api_key == null)
                        throw new System.ArgumentNullException("x_api_key");
                    request_.Headers.TryAddWithoutValidation("x-api-key", ConvertToString(x_api_key, System.Globalization.CultureInfo.InvariantCulture));
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<ReporteRespuesta>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if (status_ == 400)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<Errores>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<Errores>("BAD REQUEST", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                        else
                        if (status_ == 401)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<Errores>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<Errores>("UNAUTHORIZED", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                        else
                        if (status_ == 403)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<Errores>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<Errores>("FORBIDDEN", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                        else
                        if (status_ == 404)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<Errores>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<Errores>("NOT FOUND", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                        else
                        if (status_ == 429)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<Errores>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<Errores>("TOO MANY REQUESTS", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                        else
                        if (status_ == 500)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<Errores>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<Errores>("INTERNAL SERVER ERROR", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                        else
                        if (status_ == 503)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<Errores>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            throw new ApiException<Errores>("SERVICE UNAVAILABLE", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        protected struct ObjectResponseResult<T>
        {
            public ObjectResponseResult(T responseObject, string responseText)
            {
                this.Object = responseObject;
                this.Text = responseText;
            }

            public T Object { get; }

            public string Text { get; }
        }

        public bool ReadResponseAsString { get; set; }

        protected virtual async System.Threading.Tasks.Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(System.Net.Http.HttpResponseMessage response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Threading.CancellationToken cancellationToken)
        {
            if (response == null || response.Content == null)
            {
                return new ObjectResponseResult<T>(default(T), string.Empty);
            }

            if (ReadResponseAsString)
            {
                var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    var typedBody = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseText, JsonSerializerSettings);
                    return new ObjectResponseResult<T>(typedBody, responseText);
                }
                catch (Newtonsoft.Json.JsonException exception)
                {
                    var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
                    throw new ApiException(message, (int)response.StatusCode, responseText, headers, exception);
                }
            }
            else
            {
                try
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    using (var streamReader = new System.IO.StreamReader(responseStream))
                    using (var jsonTextReader = new Newtonsoft.Json.JsonTextReader(streamReader))
                    {
                        var serializer = Newtonsoft.Json.JsonSerializer.Create(JsonSerializerSettings);
                        var typedBody = serializer.Deserialize<T>(jsonTextReader);
                        return new ObjectResponseResult<T>(typedBody, string.Empty);
                    }
                }
                catch (Newtonsoft.Json.JsonException exception)
                {
                    var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
                    throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
                }
            }
        }

        private string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return "";
            }

            if (value is System.Enum)
            {
                var name = System.Enum.GetName(value.GetType(), value);
                if (name != null)
                {
                    var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                    if (field != null)
                    {
                        var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute))
                            as System.Runtime.Serialization.EnumMemberAttribute;
                        if (attribute != null)
                        {
                            return attribute.Value != null ? attribute.Value : name;
                        }
                    }

                    var converted = System.Convert.ToString(System.Convert.ChangeType(value, System.Enum.GetUnderlyingType(value.GetType()), cultureInfo));
                    return converted == null ? string.Empty : converted;
                }
            }
            else if (value is bool)
            {
                return System.Convert.ToString((bool)value, cultureInfo).ToLowerInvariant();
            }
            else if (value is byte[])
            {
                return System.Convert.ToBase64String((byte[])value);
            }
            else if (value.GetType().IsArray)
            {
                var array = System.Linq.Enumerable.OfType<object>((System.Array)value);
                return string.Join(",", System.Linq.Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
            }

            var result = System.Convert.ToString(value, cultureInfo);
            return result == null ? "" : result;
        }
    }

    /// <summary>&lt;table&gt; &lt;thead&gt; &lt;tr&gt; &lt;th&gt;Clave&lt;/th&gt; &lt;th&gt;Descripción&lt;/th&gt; &lt;/tr&gt; &lt;/thead&gt; &lt;tr&gt; &lt;td&gt;78&lt;/td&gt; &lt;td&gt;Negocio receptor de tarjetas de crédito que ocasionó pérdida al Usuario&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;79&lt;/td&gt; &lt;td&gt;Persona relacionada con la empresa o con Persona Física con Actividad Empresarial con clave de prevención&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;80&lt;/td&gt; &lt;td&gt;Cliente declarado en quiebra, suspensión de pagos o en concurso mercantil&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;81&lt;/td&gt; &lt;td&gt;Cliente en trámite judicial&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;82&lt;/td&gt; &lt;td&gt;Cliente que propició pérdida al Otorgante por fraude comprobado, declarado conforme a sentencia judicial&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;83&lt;/td&gt; &lt;td&gt;Cliente que solicitó y/o acordó con el Otorgante liquidación del crédito con pago menor a la deuda total&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;84&lt;/td&gt; &lt;td&gt;El usuario no ha podido localizar al Cliente, titular de la cuenta&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;85&lt;/td&gt; &lt;td&gt;Cliente desvió recursos a fines distintos a los pactados, debidamente comprobado&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;86&lt;/td&gt; &lt;td&gt;Cliente que dispuso de las garantías que respaldan el crédito sin autorización del Otorgante&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;87&lt;/td&gt; &lt;td&gt;Cliente que enajena o cambia régimen de propiedad de sus bienes o permite gravámenes sobre los mismos&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;88&lt;/td&gt; &lt;td&gt;Cliente que dispuso de las retenciones de sus trabajadores, no enterando a la Institución correspondiente&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;92&lt;/td&gt; &lt;td&gt;Cliente que propició pérdida total al Otorgante&lt;/td&gt; &lt;/tr&gt; &lt;/table&gt;</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum CatalogoClavesPrevencion
    {
        [System.Runtime.Serialization.EnumMember(Value = @"78")]
        _78 = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"79")]
        _79 = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"80")]
        _80 = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"81")]
        _81 = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"82")]
        _82 = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"83")]
        _83 = 5,

        [System.Runtime.Serialization.EnumMember(Value = @"84")]
        _84 = 6,

        [System.Runtime.Serialization.EnumMember(Value = @"85")]
        _85 = 7,

        [System.Runtime.Serialization.EnumMember(Value = @"86")]
        _86 = 8,

        [System.Runtime.Serialization.EnumMember(Value = @"87")]
        _87 = 9,

        [System.Runtime.Serialization.EnumMember(Value = @"88")]
        _88 = 10,

        [System.Runtime.Serialization.EnumMember(Value = @"92")]
        _92 = 11,

    }

    /// <summary>&lt;table&gt; &lt;thead&gt; &lt;tr&gt; &lt;th&gt;Nombre&lt;/th&gt; &lt;th&gt;Moneda&lt;/th&gt; &lt;/tr&gt; &lt;/thead&gt; &lt;tr&gt; &lt;td&gt;No definido&lt;/td&gt; &lt;td&gt;218&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Moneda nacional / Peso mexicano &lt;/td&gt; &lt;td&gt;001&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Unidad de inversión &lt;/td&gt; &lt;td&gt;003&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dolar Americano &lt;/td&gt; &lt;td&gt;005&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Euro - Ue &lt;/td&gt; &lt;td&gt;100&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Afghani de Afganistán &lt;/td&gt; &lt;td&gt;104&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Baht de Tailandia &lt;/td&gt; &lt;td&gt;030&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Balboa Panameña &lt;/td&gt; &lt;td&gt;053&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Birr Etiope &lt;/td&gt; &lt;td&gt;128&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Bolivar de Venezuela &lt;/td&gt; &lt;td&gt;039&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Cedi de Ghana &lt;/td&gt; &lt;td&gt;131&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Chelín Austriaco &lt;/td&gt; &lt;td&gt;049&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Chelín de Tanzania &lt;/td&gt; &lt;td&gt;194&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Chelín de Uganda &lt;/td&gt; &lt;td&gt;196&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Chelín Keniano &lt;/td&gt; &lt;td&gt;143&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Chelín Somalí &lt;/td&gt; &lt;td&gt;184&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Clave de Pruebas &lt;/td&gt; &lt;td&gt;213&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Colon Costarricense &lt;/td&gt; &lt;td&gt;048&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Colon Salvadoreño &lt;/td&gt; &lt;td&gt;022&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Córdova de Nicaragua &lt;/td&gt; &lt;td&gt;040&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Corona Checa &lt;/td&gt; &lt;td&gt;122&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Corona Danesa &lt;/td&gt; &lt;td&gt;029&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Corona de Estonia &lt;/td&gt; &lt;td&gt;125&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Corona Eslovaca &lt;/td&gt; &lt;td&gt;182&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Corona Islandesa &lt;/td&gt; &lt;td&gt;140&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Corona Noruega &lt;/td&gt; &lt;td&gt;054&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Corona Sueca &lt;/td&gt; &lt;td&gt;002&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dalasi de Gambia &lt;/td&gt; &lt;td&gt;133&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;denar de Macedonia &lt;/td&gt; &lt;td&gt;157&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;derechos Especiales Girofmi &lt;/td&gt; &lt;td&gt;207&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dinar Argelino &lt;/td&gt; &lt;td&gt;124&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dinar Bahrain &lt;/td&gt; &lt;td&gt;084&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dinar de Libia &lt;/td&gt; &lt;td&gt;085&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dinar Iraquí &lt;/td&gt; &lt;td&gt;138&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dinar Jordano &lt;/td&gt; &lt;td&gt;142&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dinar Kuwaiti &lt;/td&gt; &lt;td&gt;088&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dinar Sudanés &lt;/td&gt; &lt;td&gt;179&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dinar Tunes &lt;/td&gt; &lt;td&gt;091&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dinar Yugoslavo &lt;/td&gt; &lt;td&gt;215&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dirham de Emiratos &lt;/td&gt; &lt;td&gt;103&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dirham de Marruecos &lt;/td&gt; &lt;td&gt;063&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dobla Sto Tomás Y Príncipe &lt;/td&gt; &lt;td&gt;186&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dolar Australiano &lt;/td&gt; &lt;td&gt;074&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dolar Bahamas &lt;/td&gt; &lt;td&gt;068&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dolar Belice &lt;/td&gt; &lt;td&gt;024&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dolar Bermudas &lt;/td&gt; &lt;td&gt;059&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dolar Canadiense &lt;/td&gt; &lt;td&gt;004&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dolar de Barbados &lt;/td&gt; &lt;td&gt;110&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dolar de Brunéi &lt;/td&gt; &lt;td&gt;113&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dolar de Las Islas Salomón &lt;/td&gt; &lt;td&gt;177&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dolar de Liberia &lt;/td&gt; &lt;td&gt;151&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dolar de Namibia &lt;/td&gt; &lt;td&gt;167&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dolar de Zimabwe &lt;/td&gt; &lt;td&gt;217&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dolar del Caribe Oriental &lt;/td&gt; &lt;td&gt;206&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dolar Fiji &lt;/td&gt; &lt;td&gt;070&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dolar Guyana &lt;/td&gt; &lt;td&gt;073&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dolar Hong Kong &lt;/td&gt; &lt;td&gt;023&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dolar Isalas Caimán &lt;/td&gt; &lt;td&gt;147&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dolar Jamaiquino &lt;/td&gt; &lt;td&gt;141&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dolar Neozolandes &lt;/td&gt; &lt;td&gt;058&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dolar Singapur &lt;/td&gt; &lt;td&gt;055&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dolar Taiwanes &lt;/td&gt; &lt;td&gt;087&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dolar Trinidad Y Tobago &lt;/td&gt; &lt;td&gt;193&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dong de Vietnam &lt;/td&gt; &lt;td&gt;198&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dracha Griego &lt;/td&gt; &lt;td&gt;095&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Dram de Armenia &lt;/td&gt; &lt;td&gt;106&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Escudo de Cabo Verde &lt;/td&gt; &lt;td&gt;121&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Escudo de Timor &lt;/td&gt; &lt;td&gt;192&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Escudo Portugues &lt;/td&gt; &lt;td&gt;006&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Florin Ant Holandesas &lt;/td&gt; &lt;td&gt;066&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Florin de Aruba &lt;/td&gt; &lt;td&gt;037&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Florin de Surinam &lt;/td&gt; &lt;td&gt;185&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Florin Holandes &lt;/td&gt; &lt;td&gt;020&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Florin Hungaro &lt;/td&gt; &lt;td&gt;090&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Francesas Africa Occidental &lt;/td&gt; &lt;td&gt;210&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Franco Belga &lt;/td&gt; &lt;td&gt;025&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Franco Col Francesas &lt;/td&gt; &lt;td&gt;201&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Franco Congoles &lt;/td&gt; &lt;td&gt;118&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Franco de Burundi &lt;/td&gt; &lt;td&gt;112&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Franco de Comoros &lt;/td&gt; &lt;td&gt;145&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Franco de Djibouti &lt;/td&gt; &lt;td&gt;123&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Franco de Guinea &lt;/td&gt; &lt;td&gt;134&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Franco de Luxemburgo &lt;/td&gt; &lt;td&gt;096&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Franco de Ruanda &lt;/td&gt; &lt;td&gt;175&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Franco Frances &lt;/td&gt; &lt;td&gt;007&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Franco Malgache &lt;/td&gt; &lt;td&gt;156&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Franco Oro &lt;/td&gt; &lt;td&gt;208&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Franco Polinesia Francesa &lt;/td&gt; &lt;td&gt;075&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Franco Suizo &lt;/td&gt; &lt;td&gt;008&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Gourde de Haiti &lt;/td&gt; &lt;td&gt;061&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Guarani Paraguayo &lt;/td&gt; &lt;td&gt;065&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Hryvnia de Ucrania &lt;/td&gt; &lt;td&gt;195&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Kina de Papua Nueva Guinea &lt;/td&gt; &lt;td&gt;171&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Kip de Laos &lt;/td&gt; &lt;td&gt;149&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Kuna Croata &lt;/td&gt; &lt;td&gt;136&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Kwacha de Malawi &lt;/td&gt; &lt;td&gt;165&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Kwacha de Zambia &lt;/td&gt; &lt;td&gt;216&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Kwanza de Angola &lt;/td&gt; &lt;td&gt;107&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Kyat de Myanmar &lt;/td&gt; &lt;td&gt;158&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Lari de Georgia &lt;/td&gt; &lt;td&gt;130&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Lats de Letonia &lt;/td&gt; &lt;td&gt;154&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Lek de Albania &lt;/td&gt; &lt;td&gt;105&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Lempira Hondureña &lt;/td&gt; &lt;td&gt;045&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Leona de Sierra Leona &lt;/td&gt; &lt;td&gt;183&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Leu de Moldova &lt;/td&gt; &lt;td&gt;155&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Leu Rumano &lt;/td&gt; &lt;td&gt;174&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Leva de Bulgaria &lt;/td&gt; &lt;td&gt;093&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Libra Chipriota &lt;/td&gt; &lt;td&gt;098&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Libra de Gibraltar &lt;/td&gt; &lt;td&gt;132&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Libra de Las Islas Ma &lt;/td&gt; &lt;td&gt;129&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Libra de Santa Elena &lt;/td&gt; &lt;td&gt;180&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Libra Egipcia &lt;/td&gt; &lt;td&gt;126&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Libra Esterlina &lt;/td&gt; &lt;td&gt;009&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Libra Israeli &lt;/td&gt; &lt;td&gt;035&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Libra Siria &lt;/td&gt; &lt;td&gt;187&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Lilangeni de Suazilandia &lt;/td&gt; &lt;td&gt;188&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Lira Italiana &lt;/td&gt; &lt;td&gt;010&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Lira Libanesa &lt;/td&gt; &lt;td&gt;097&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Lira Maltesa &lt;/td&gt; &lt;td&gt;162&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Lira Turquia &lt;/td&gt; &lt;td&gt;086&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Litus de Lituania &lt;/td&gt; &lt;td&gt;153&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Loti de Lesotho &lt;/td&gt; &lt;td&gt;152&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Manat de Azerbayan &lt;/td&gt; &lt;td&gt;108&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Manat de Turkmenistan &lt;/td&gt; &lt;td&gt;190&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Marco Aleman &lt;/td&gt; &lt;td&gt;011&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Marco Finlandes &lt;/td&gt; &lt;td&gt;092&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Marcos Conver de Bosnia &lt;/td&gt; &lt;td&gt;109&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Metical de Mozambique &lt;/td&gt; &lt;td&gt;166&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Moneda Nal Boliviana &lt;/td&gt; &lt;td&gt;114&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Nafka de Eritrea &lt;/td&gt; &lt;td&gt;127&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Naira de Nigeria &lt;/td&gt; &lt;td&gt;168&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Ngultrum de Buthan &lt;/td&gt; &lt;td&gt;115&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Oro &lt;/td&gt; &lt;td&gt;013&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Ouguiya Mauritania &lt;/td&gt; &lt;td&gt;161&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Paanga de Tonga &lt;/td&gt; &lt;td&gt;191&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Paladio &lt;/td&gt; &lt;td&gt;211&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Pataca de Macao &lt;/td&gt; &lt;td&gt;160&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Peseta Andorra &lt;/td&gt; &lt;td&gt;102&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Peseta Española &lt;/td&gt; &lt;td&gt;027&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Peso Argentino &lt;/td&gt; &lt;td&gt;016&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Peso Boliviano &lt;/td&gt; &lt;td&gt;062&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Peso Chileno &lt;/td&gt; &lt;td&gt;033&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Peso Colombiano &lt;/td&gt; &lt;td&gt;043&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Peso Cubano &lt;/td&gt; &lt;td&gt;120&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Peso de Guinea Bissau &lt;/td&gt; &lt;td&gt;135&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Peso Dominicano &lt;/td&gt; &lt;td&gt;044&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Peso Filipino &lt;/td&gt; &lt;td&gt;056&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Peso Uruguayo &lt;/td&gt; &lt;td&gt;034&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Plata &lt;/td&gt; &lt;td&gt;014&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Platino &lt;/td&gt; &lt;td&gt;212&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;Pula de Botswana &lt;/td&gt; &lt;td&gt;116&lt;/td&gt; &lt;/tr&gt; &lt;/table&gt;</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum CatalogoTipoMoneda
    {
        [System.Runtime.Serialization.EnumMember(Value = @"001")]
        _001 = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"002")]
        _002 = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"003")]
        _003 = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"004")]
        _004 = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"005")]
        _005 = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"006")]
        _006 = 5,

        [System.Runtime.Serialization.EnumMember(Value = @"007")]
        _007 = 6,

        [System.Runtime.Serialization.EnumMember(Value = @"008")]
        _008 = 7,

        [System.Runtime.Serialization.EnumMember(Value = @"009")]
        _009 = 8,

        [System.Runtime.Serialization.EnumMember(Value = @"010")]
        _010 = 9,

        [System.Runtime.Serialization.EnumMember(Value = @"011")]
        _011 = 10,

        [System.Runtime.Serialization.EnumMember(Value = @"013")]
        _013 = 11,

        [System.Runtime.Serialization.EnumMember(Value = @"014")]
        _014 = 12,

        [System.Runtime.Serialization.EnumMember(Value = @"016")]
        _016 = 13,

        [System.Runtime.Serialization.EnumMember(Value = @"020")]
        _020 = 14,

        [System.Runtime.Serialization.EnumMember(Value = @"022")]
        _022 = 15,

        [System.Runtime.Serialization.EnumMember(Value = @"023")]
        _023 = 16,

        [System.Runtime.Serialization.EnumMember(Value = @"024")]
        _024 = 17,

        [System.Runtime.Serialization.EnumMember(Value = @"025")]
        _025 = 18,

        [System.Runtime.Serialization.EnumMember(Value = @"027")]
        _027 = 19,

        [System.Runtime.Serialization.EnumMember(Value = @"029")]
        _029 = 20,

        [System.Runtime.Serialization.EnumMember(Value = @"030")]
        _030 = 21,

        [System.Runtime.Serialization.EnumMember(Value = @"033")]
        _033 = 22,

        [System.Runtime.Serialization.EnumMember(Value = @"034")]
        _034 = 23,

        [System.Runtime.Serialization.EnumMember(Value = @"035")]
        _035 = 24,

        [System.Runtime.Serialization.EnumMember(Value = @"037")]
        _037 = 25,

        [System.Runtime.Serialization.EnumMember(Value = @"039")]
        _039 = 26,

        [System.Runtime.Serialization.EnumMember(Value = @"040")]
        _040 = 27,

        [System.Runtime.Serialization.EnumMember(Value = @"043")]
        _043 = 28,

        [System.Runtime.Serialization.EnumMember(Value = @"044")]
        _044 = 29,

        [System.Runtime.Serialization.EnumMember(Value = @"045")]
        _045 = 30,

        [System.Runtime.Serialization.EnumMember(Value = @"048")]
        _048 = 31,

        [System.Runtime.Serialization.EnumMember(Value = @"049")]
        _049 = 32,

        [System.Runtime.Serialization.EnumMember(Value = @"053")]
        _053 = 33,

        [System.Runtime.Serialization.EnumMember(Value = @"054")]
        _054 = 34,

        [System.Runtime.Serialization.EnumMember(Value = @"055")]
        _055 = 35,

        [System.Runtime.Serialization.EnumMember(Value = @"056")]
        _056 = 36,

        [System.Runtime.Serialization.EnumMember(Value = @"058")]
        _058 = 37,

        [System.Runtime.Serialization.EnumMember(Value = @"059")]
        _059 = 38,

        [System.Runtime.Serialization.EnumMember(Value = @"061")]
        _061 = 39,

        [System.Runtime.Serialization.EnumMember(Value = @"062")]
        _062 = 40,

        [System.Runtime.Serialization.EnumMember(Value = @"063")]
        _063 = 41,

        [System.Runtime.Serialization.EnumMember(Value = @"065")]
        _065 = 42,

        [System.Runtime.Serialization.EnumMember(Value = @"066")]
        _066 = 43,

        [System.Runtime.Serialization.EnumMember(Value = @"068")]
        _068 = 44,

        [System.Runtime.Serialization.EnumMember(Value = @"070")]
        _070 = 45,

        [System.Runtime.Serialization.EnumMember(Value = @"073")]
        _073 = 46,

        [System.Runtime.Serialization.EnumMember(Value = @"074")]
        _074 = 47,

        [System.Runtime.Serialization.EnumMember(Value = @"075")]
        _075 = 48,

        [System.Runtime.Serialization.EnumMember(Value = @"084")]
        _084 = 49,

        [System.Runtime.Serialization.EnumMember(Value = @"085")]
        _085 = 50,

        [System.Runtime.Serialization.EnumMember(Value = @"086")]
        _086 = 51,

        [System.Runtime.Serialization.EnumMember(Value = @"087")]
        _087 = 52,

        [System.Runtime.Serialization.EnumMember(Value = @"088")]
        _088 = 53,

        [System.Runtime.Serialization.EnumMember(Value = @"090")]
        _090 = 54,

        [System.Runtime.Serialization.EnumMember(Value = @"091")]
        _091 = 55,

        [System.Runtime.Serialization.EnumMember(Value = @"092")]
        _092 = 56,

        [System.Runtime.Serialization.EnumMember(Value = @"093")]
        _093 = 57,

        [System.Runtime.Serialization.EnumMember(Value = @"095")]
        _095 = 58,

        [System.Runtime.Serialization.EnumMember(Value = @"096")]
        _096 = 59,

        [System.Runtime.Serialization.EnumMember(Value = @"097")]
        _097 = 60,

        [System.Runtime.Serialization.EnumMember(Value = @"098")]
        _098 = 61,

        [System.Runtime.Serialization.EnumMember(Value = @"100")]
        _100 = 62,

        [System.Runtime.Serialization.EnumMember(Value = @"102")]
        _102 = 63,

        [System.Runtime.Serialization.EnumMember(Value = @"103")]
        _103 = 64,

        [System.Runtime.Serialization.EnumMember(Value = @"104")]
        _104 = 65,

        [System.Runtime.Serialization.EnumMember(Value = @"105")]
        _105 = 66,

        [System.Runtime.Serialization.EnumMember(Value = @"106")]
        _106 = 67,

        [System.Runtime.Serialization.EnumMember(Value = @"107")]
        _107 = 68,

        [System.Runtime.Serialization.EnumMember(Value = @"108")]
        _108 = 69,

        [System.Runtime.Serialization.EnumMember(Value = @"109")]
        _109 = 70,

        [System.Runtime.Serialization.EnumMember(Value = @"110")]
        _110 = 71,

        [System.Runtime.Serialization.EnumMember(Value = @"112")]
        _112 = 72,

        [System.Runtime.Serialization.EnumMember(Value = @"113")]
        _113 = 73,

        [System.Runtime.Serialization.EnumMember(Value = @"114")]
        _114 = 74,

        [System.Runtime.Serialization.EnumMember(Value = @"115")]
        _115 = 75,

        [System.Runtime.Serialization.EnumMember(Value = @"116")]
        _116 = 76,

        [System.Runtime.Serialization.EnumMember(Value = @"118")]
        _118 = 77,

        [System.Runtime.Serialization.EnumMember(Value = @"120")]
        _120 = 78,

        [System.Runtime.Serialization.EnumMember(Value = @"121")]
        _121 = 79,

        [System.Runtime.Serialization.EnumMember(Value = @"122")]
        _122 = 80,

        [System.Runtime.Serialization.EnumMember(Value = @"123")]
        _123 = 81,

        [System.Runtime.Serialization.EnumMember(Value = @"124")]
        _124 = 82,

        [System.Runtime.Serialization.EnumMember(Value = @"125")]
        _125 = 83,

        [System.Runtime.Serialization.EnumMember(Value = @"126")]
        _126 = 84,

        [System.Runtime.Serialization.EnumMember(Value = @"127")]
        _127 = 85,

        [System.Runtime.Serialization.EnumMember(Value = @"128")]
        _128 = 86,

        [System.Runtime.Serialization.EnumMember(Value = @"129")]
        _129 = 87,

        [System.Runtime.Serialization.EnumMember(Value = @"130")]
        _130 = 88,

        [System.Runtime.Serialization.EnumMember(Value = @"131")]
        _131 = 89,

        [System.Runtime.Serialization.EnumMember(Value = @"132")]
        _132 = 90,

        [System.Runtime.Serialization.EnumMember(Value = @"133")]
        _133 = 91,

        [System.Runtime.Serialization.EnumMember(Value = @"134")]
        _134 = 92,

        [System.Runtime.Serialization.EnumMember(Value = @"135")]
        _135 = 93,

        [System.Runtime.Serialization.EnumMember(Value = @"136")]
        _136 = 94,

        [System.Runtime.Serialization.EnumMember(Value = @"138")]
        _138 = 95,

        [System.Runtime.Serialization.EnumMember(Value = @"140")]
        _140 = 96,

        [System.Runtime.Serialization.EnumMember(Value = @"141")]
        _141 = 97,

        [System.Runtime.Serialization.EnumMember(Value = @"142")]
        _142 = 98,

        [System.Runtime.Serialization.EnumMember(Value = @"143")]
        _143 = 99,

        [System.Runtime.Serialization.EnumMember(Value = @"145")]
        _145 = 100,

        [System.Runtime.Serialization.EnumMember(Value = @"147")]
        _147 = 101,

        [System.Runtime.Serialization.EnumMember(Value = @"149")]
        _149 = 102,

        [System.Runtime.Serialization.EnumMember(Value = @"151")]
        _151 = 103,

        [System.Runtime.Serialization.EnumMember(Value = @"152")]
        _152 = 104,

        [System.Runtime.Serialization.EnumMember(Value = @"153")]
        _153 = 105,

        [System.Runtime.Serialization.EnumMember(Value = @"154")]
        _154 = 106,

        [System.Runtime.Serialization.EnumMember(Value = @"155")]
        _155 = 107,

        [System.Runtime.Serialization.EnumMember(Value = @"156")]
        _156 = 108,

        [System.Runtime.Serialization.EnumMember(Value = @"157")]
        _157 = 109,

        [System.Runtime.Serialization.EnumMember(Value = @"158")]
        _158 = 110,

        [System.Runtime.Serialization.EnumMember(Value = @"160")]
        _160 = 111,

        [System.Runtime.Serialization.EnumMember(Value = @"161")]
        _161 = 112,

        [System.Runtime.Serialization.EnumMember(Value = @"162")]
        _162 = 113,

        [System.Runtime.Serialization.EnumMember(Value = @"165")]
        _165 = 114,

        [System.Runtime.Serialization.EnumMember(Value = @"166")]
        _166 = 115,

        [System.Runtime.Serialization.EnumMember(Value = @"167")]
        _167 = 116,

        [System.Runtime.Serialization.EnumMember(Value = @"168")]
        _168 = 117,

        [System.Runtime.Serialization.EnumMember(Value = @"171")]
        _171 = 118,

        [System.Runtime.Serialization.EnumMember(Value = @"174")]
        _174 = 119,

        [System.Runtime.Serialization.EnumMember(Value = @"175")]
        _175 = 120,

        [System.Runtime.Serialization.EnumMember(Value = @"177")]
        _177 = 121,

        [System.Runtime.Serialization.EnumMember(Value = @"179")]
        _179 = 122,

        [System.Runtime.Serialization.EnumMember(Value = @"180")]
        _180 = 123,

        [System.Runtime.Serialization.EnumMember(Value = @"182")]
        _182 = 124,

        [System.Runtime.Serialization.EnumMember(Value = @"183")]
        _183 = 125,

        [System.Runtime.Serialization.EnumMember(Value = @"184")]
        _184 = 126,

        [System.Runtime.Serialization.EnumMember(Value = @"185")]
        _185 = 127,

        [System.Runtime.Serialization.EnumMember(Value = @"186")]
        _186 = 128,

        [System.Runtime.Serialization.EnumMember(Value = @"187")]
        _187 = 129,

        [System.Runtime.Serialization.EnumMember(Value = @"188")]
        _188 = 130,

        [System.Runtime.Serialization.EnumMember(Value = @"190")]
        _190 = 131,

        [System.Runtime.Serialization.EnumMember(Value = @"191")]
        _191 = 132,

        [System.Runtime.Serialization.EnumMember(Value = @"192")]
        _192 = 133,

        [System.Runtime.Serialization.EnumMember(Value = @"193")]
        _193 = 134,

        [System.Runtime.Serialization.EnumMember(Value = @"194")]
        _194 = 135,

        [System.Runtime.Serialization.EnumMember(Value = @"195")]
        _195 = 136,

        [System.Runtime.Serialization.EnumMember(Value = @"196")]
        _196 = 137,

        [System.Runtime.Serialization.EnumMember(Value = @"198")]
        _198 = 138,

        [System.Runtime.Serialization.EnumMember(Value = @"201")]
        _201 = 139,

        [System.Runtime.Serialization.EnumMember(Value = @"206")]
        _206 = 140,

        [System.Runtime.Serialization.EnumMember(Value = @"207")]
        _207 = 141,

        [System.Runtime.Serialization.EnumMember(Value = @"208")]
        _208 = 142,

        [System.Runtime.Serialization.EnumMember(Value = @"210")]
        _210 = 143,

        [System.Runtime.Serialization.EnumMember(Value = @"211")]
        _211 = 144,

        [System.Runtime.Serialization.EnumMember(Value = @"212")]
        _212 = 145,

        [System.Runtime.Serialization.EnumMember(Value = @"213")]
        _213 = 146,

        [System.Runtime.Serialization.EnumMember(Value = @"215")]
        _215 = 147,

        [System.Runtime.Serialization.EnumMember(Value = @"216")]
        _216 = 148,

        [System.Runtime.Serialization.EnumMember(Value = @"217")]
        _217 = 149,

        [System.Runtime.Serialization.EnumMember(Value = @"218")]
        _218 = 150,

    }

    /// <summary>Pais en el que se ubica el domicilio &lt;table&gt; &lt;thead&gt; &lt;tr&gt; &lt;th&gt;País&lt;/th&gt; &lt;th&gt;Clave&lt;/th&gt; &lt;/tr&gt; &lt;/thead&gt; &lt;tbody&gt; &lt;tr&gt; &lt;td&gt; Croacia&lt;/td&gt; &lt;td&gt;HX&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; México&lt;/td&gt; &lt;td&gt;MX&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; África Del Sur&lt;/td&gt; &lt;td&gt;ZA&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Albania&lt;/td&gt; &lt;td&gt;AN&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Alemania&lt;/td&gt; &lt;td&gt;DW&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Andorra&lt;/td&gt; &lt;td&gt;AD&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Angola&lt;/td&gt; &lt;td&gt;AO&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Anguila&lt;/td&gt; &lt;td&gt;AI&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Antigua Y Barbado&lt;/td&gt; &lt;td&gt;AG&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Antillas Holandesas&lt;/td&gt; &lt;td&gt;NN&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Arabia Saudita&lt;/td&gt; &lt;td&gt;SA&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Argelia&lt;/td&gt; &lt;td&gt;DZ&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Argentina&lt;/td&gt; &lt;td&gt;AT&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Arabia&lt;/td&gt; &lt;td&gt;AW&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Ascensión&lt;/td&gt; &lt;td&gt;AS&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Australia&lt;/td&gt; &lt;td&gt;AU&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Austria&lt;/td&gt; &lt;td&gt;DF&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Azores&lt;/td&gt; &lt;td&gt;AX&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Bahamas&lt;/td&gt; &lt;td&gt;BS&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Baréin&lt;/td&gt; &lt;td&gt;BH&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Bangladés&lt;/td&gt; &lt;td&gt;BD&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Barbados&lt;/td&gt; &lt;td&gt;BB&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Bélgica&lt;/td&gt; &lt;td&gt;BE&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Belice&lt;/td&gt; &lt;td&gt;BZ&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Benín&lt;/td&gt; &lt;td&gt;BJ&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Bermudas&lt;/td&gt; &lt;td&gt;BU&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Birmania&lt;/td&gt; &lt;td&gt;BK&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Bolivia&lt;/td&gt; &lt;td&gt;BO&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Bosnia Herzegovina&lt;/td&gt; &lt;td&gt;BX&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Botswana&lt;/td&gt; &lt;td&gt;BW&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Brasil&lt;/td&gt; &lt;td&gt;BR&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Brunéi&lt;/td&gt; &lt;td&gt;BN&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Bulgaria&lt;/td&gt; &lt;td&gt;BG&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Burkina&lt;/td&gt; &lt;td&gt;BF&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Burundi&lt;/td&gt; &lt;td&gt;BI&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Bután&lt;/td&gt; &lt;td&gt;BM&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Cabo Verde&lt;/td&gt; &lt;td&gt;CV&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Camerún&lt;/td&gt; &lt;td&gt;CM&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Canadá&lt;/td&gt; &lt;td&gt;CN&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Cariacou&lt;/td&gt; &lt;td&gt;CU&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Chad&lt;/td&gt; &lt;td&gt;CD&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Chile&lt;/td&gt; &lt;td&gt;CL&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; China (pekin)&lt;/td&gt; &lt;td&gt;CP&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Chipre&lt;/td&gt; &lt;td&gt;CY&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Ciudad Del Vaticano&lt;/td&gt; &lt;td&gt;VC&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Colombia&lt;/td&gt; &lt;td&gt;CB&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Comoros&lt;/td&gt; &lt;td&gt;CJ&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Congo&lt;/td&gt; &lt;td&gt;CG&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Corcega&lt;/td&gt; &lt;td&gt;CC&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Corea Del Norte&lt;/td&gt; &lt;td&gt;KX&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Corea Del Sur&lt;/td&gt; &lt;td&gt;KR&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Costa De Marfil&lt;/td&gt; &lt;td&gt;IC&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Cuba&lt;/td&gt; &lt;td&gt;HR&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Dinamarca&lt;/td&gt; &lt;td&gt;DK&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Djibouti&lt;/td&gt; &lt;td&gt;DJ&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Dominicana&lt;/td&gt; &lt;td&gt;DM&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Ecuador&lt;/td&gt; &lt;td&gt;EC&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Egipto&lt;/td&gt; &lt;td&gt;EG&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; El Salvador&lt;/td&gt; &lt;td&gt;SV&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Emiratos Arabes Unidos&lt;/td&gt; &lt;td&gt;UM&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; España&lt;/td&gt; &lt;td&gt;ES&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Estados Unidos&lt;/td&gt; &lt;td&gt;US&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Eslovenia&lt;/td&gt; &lt;td&gt;XN&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Estonia&lt;/td&gt; &lt;td&gt;SU&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Etiopia&lt;/td&gt; &lt;td&gt;ET&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Fiji&lt;/td&gt; &lt;td&gt;FJ&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Filipinas&lt;/td&gt; &lt;td&gt;PH&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Finlandia&lt;/td&gt; &lt;td&gt;FI&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Francia&lt;/td&gt; &lt;td&gt;FR&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Gabón&lt;/td&gt; &lt;td&gt;GB&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Gales / Isla Futura&lt;/td&gt; &lt;td&gt;WT&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Gambia&lt;/td&gt; &lt;td&gt;GM&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Ghana&lt;/td&gt; &lt;td&gt;GH&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Gibraltar&lt;/td&gt; &lt;td&gt;GI&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Granada&lt;/td&gt; &lt;td&gt;GD&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Grecia&lt;/td&gt; &lt;td&gt;GR&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Groenlandia&lt;/td&gt; &lt;td&gt;GE&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Guadalupe&lt;/td&gt; &lt;td&gt;GP&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Guatemala&lt;/td&gt; &lt;td&gt;GT&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Guyana&lt;/td&gt; &lt;td&gt;GY&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Guayana Francesa&lt;/td&gt; &lt;td&gt;GF&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Guinea&lt;/td&gt; &lt;td&gt;GN&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Guinea Bissau&lt;/td&gt; &lt;td&gt;GW&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Guinea Ecuatorial&lt;/td&gt; &lt;td&gt;GQ&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Haití&lt;/td&gt; &lt;td&gt;HA&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Holanda&lt;/td&gt; &lt;td&gt;NL&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Honduras&lt;/td&gt; &lt;td&gt;HN&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Hong Kong&lt;/td&gt; &lt;td&gt;HK&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Hungría&lt;/td&gt; &lt;td&gt;HU&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; India&lt;/td&gt; &lt;td&gt;IB&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Indonesia&lt;/td&gt; &lt;td&gt;IF&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Irán&lt;/td&gt; &lt;td&gt;IR&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Irak&lt;/td&gt; &lt;td&gt;IQ&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Irlanda&lt;/td&gt; &lt;td&gt;IE&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Islandia&lt;/td&gt; &lt;td&gt;IS&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Islas Caimán&lt;/td&gt; &lt;td&gt;CI&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Islas De Sotavento&lt;/td&gt; &lt;td&gt;LE&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Islas Falkland (malvinas)&lt;/td&gt; &lt;td&gt;FA&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Islas Faroe&lt;/td&gt; &lt;td&gt;FE&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Islas Pitcairn&lt;/td&gt; &lt;td&gt;PS&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Islas Reunión&lt;/td&gt; &lt;td&gt;RE&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Islas Santa Cruz&lt;/td&gt; &lt;td&gt;ST&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Islas Salmón&lt;/td&gt; &lt;td&gt;SI&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Islas Virgenes Inglesas&lt;/td&gt; &lt;td&gt;VG&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Israel&lt;/td&gt; &lt;td&gt;IG&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Italia&lt;/td&gt; &lt;td&gt;IT&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Jamaica&lt;/td&gt; &lt;td&gt;JM&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Japón&lt;/td&gt; &lt;td&gt;JP&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Jordania&lt;/td&gt; &lt;td&gt;JO&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Kampuchea&lt;/td&gt; &lt;td&gt;KA&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Katar&lt;/td&gt; &lt;td&gt;OA&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Kenya&lt;/td&gt; &lt;td&gt;KE&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Kiribati&lt;/td&gt; &lt;td&gt;KI&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Kuwait&lt;/td&gt; &lt;td&gt;KW&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Laos&lt;/td&gt; &lt;td&gt;LO&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Lesotho&lt;/td&gt; &lt;td&gt;LS&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Letonia&lt;/td&gt; &lt;td&gt;LX&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Libano&lt;/td&gt; &lt;td&gt;LB&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Liberia&lt;/td&gt; &lt;td&gt;LR&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Libia&lt;/td&gt; &lt;td&gt;LV&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Liechtenstein&lt;/td&gt; &lt;td&gt;CH&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Lituania&lt;/td&gt; &lt;td&gt;LT&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Luxemburgo&lt;/td&gt; &lt;td&gt;LU&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Macao&lt;/td&gt; &lt;td&gt;MJ&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Macedonia&lt;/td&gt; &lt;td&gt;MH&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Madagascar&lt;/td&gt; &lt;td&gt;MG&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Madeira&lt;/td&gt; &lt;td&gt;MD&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Malasia&lt;/td&gt; &lt;td&gt;MY&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Malawi&lt;/td&gt; &lt;td&gt;MW&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Maldivias&lt;/td&gt; &lt;td&gt;MV&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Mali&lt;/td&gt; &lt;td&gt;ML&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Malta&lt;/td&gt; &lt;td&gt;MT&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Marruecos&lt;/td&gt; &lt;td&gt;RC&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Martinico&lt;/td&gt; &lt;td&gt;MQ&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Mauricio&lt;/td&gt; &lt;td&gt;MU&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Mauritania&lt;/td&gt; &lt;td&gt;MR&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Afganistán&lt;/td&gt; &lt;td&gt;AF&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Mongolia&lt;/td&gt; &lt;td&gt;MC&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Montenegro&lt;/td&gt; &lt;td&gt;MM&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Montserrat&lt;/td&gt; &lt;td&gt;MK&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Mozambique&lt;/td&gt; &lt;td&gt;MZ&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Nauru&lt;/td&gt; &lt;td&gt;NA&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Nepal&lt;/td&gt; &lt;td&gt;NP&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Nicaragua&lt;/td&gt; &lt;td&gt;NI&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Nigeria&lt;/td&gt; &lt;td&gt;NR&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Noruega&lt;/td&gt; &lt;td&gt;NO&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Nueva Caledonia&lt;/td&gt; &lt;td&gt;NW&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Nueva Zelanda&lt;/td&gt; &lt;td&gt;NZ&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Oman&lt;/td&gt; &lt;td&gt;OM&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Pakistan&lt;/td&gt; &lt;td&gt;PK&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Panamá&lt;/td&gt; &lt;td&gt;PM&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Papua Nueva Guinea&lt;/td&gt; &lt;td&gt;PG&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Paraguay&lt;/td&gt; &lt;td&gt;PY&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Perú&lt;/td&gt; &lt;td&gt;PU&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Polonia&lt;/td&gt; &lt;td&gt;PL&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Polinesia&lt;/td&gt; &lt;td&gt;FP&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Portugal&lt;/td&gt; &lt;td&gt;PT&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Reino Unido&lt;/td&gt; &lt;td&gt;UK&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Rep. Central Africana&lt;/td&gt; &lt;td&gt;CF&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; República Checa Eslovaca&lt;/td&gt; &lt;td&gt;CS&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; República De Georgia&lt;/td&gt; &lt;td&gt;GX&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; República Dominicana&lt;/td&gt; &lt;td&gt;DO&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Rumanía&lt;/td&gt; &lt;td&gt;RO&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Rusia&lt;/td&gt; &lt;td&gt;RU&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Rwanda&lt;/td&gt; &lt;td&gt;RW&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Samoa Oeste&lt;/td&gt; &lt;td&gt;WS&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; San Cristóbal De Nevais&lt;/td&gt; &lt;td&gt;KN&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; San Kitts&lt;/td&gt; &lt;td&gt;SS&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; San Pierre Y Miquelon&lt;/td&gt; &lt;td&gt;SP&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; San Vincent Y Las Granadas&lt;/td&gt; &lt;td&gt;SF&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Santa Helena&lt;/td&gt; &lt;td&gt;SH&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Santa Lucia&lt;/td&gt; &lt;td&gt;LC&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Sao Tome Y Principado&lt;/td&gt; &lt;td&gt;MP&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Senegal&lt;/td&gt; &lt;td&gt;SN&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Serbia&lt;/td&gt; &lt;td&gt;SX&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Siria&lt;/td&gt; &lt;td&gt;SY&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Somalia&lt;/td&gt; &lt;td&gt;SO&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Sri Lanka&lt;/td&gt; &lt;td&gt;LK&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Sudan&lt;/td&gt; &lt;td&gt;SB&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Suecia&lt;/td&gt; &lt;td&gt;SE&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Suiza&lt;/td&gt; &lt;td&gt;SW&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Surinam&lt;/td&gt; &lt;td&gt;SR&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Swazilandia&lt;/td&gt; &lt;td&gt;SZ&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Tailandia&lt;/td&gt; &lt;td&gt;TH&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Taiwan&lt;/td&gt; &lt;td&gt;TW&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Tanzania&lt;/td&gt; &lt;td&gt;TZ&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Timor Oriental&lt;/td&gt; &lt;td&gt;EM&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Togo&lt;/td&gt; &lt;td&gt;TG&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Tonga&lt;/td&gt; &lt;td&gt;TA&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Trinidad Y Tobago&lt;/td&gt; &lt;td&gt;TT&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Tristan De Cunha&lt;/td&gt; &lt;td&gt;TD&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Tunez&lt;/td&gt; &lt;td&gt;TU&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Turcos Y Islas Caicos&lt;/td&gt; &lt;td&gt;TC&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Turquia &lt;/td&gt; &lt;td&gt;TR&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Tuvala&lt;/td&gt; &lt;td&gt;TV&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Uganda&lt;/td&gt; &lt;td&gt;UG&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Ucrania&lt;/td&gt; &lt;td&gt;UA&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Uruguay&lt;/td&gt; &lt;td&gt;UY&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Vanuatu&lt;/td&gt; &lt;td&gt;VU&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Venezuela&lt;/td&gt; &lt;td&gt;VE&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Vietnam&lt;/td&gt; &lt;td&gt;VN&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Yemen (del Norte)&lt;/td&gt; &lt;td&gt;YS&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Yemen (del Sur)&lt;/td&gt; &lt;td&gt;YE&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Zaire&lt;/td&gt; &lt;td&gt;ZR&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Zambia&lt;/td&gt; &lt;td&gt;ZM&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; Zimbabwe&lt;/td&gt; &lt;td&gt;ZW&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt; No Definido&lt;/td&gt; &lt;td&gt;ND&lt;/td&gt; &lt;/tr&gt; &lt;/tbody&gt; &lt;/table&gt;</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum CatalogoPais
    {
        [System.Runtime.Serialization.EnumMember(Value = @"AD")]
        AD = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"AF")]
        AF = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"AG")]
        AG = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"AI")]
        AI = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"AN")]
        AN = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"AO")]
        AO = 5,

        [System.Runtime.Serialization.EnumMember(Value = @"AS")]
        AS = 6,

        [System.Runtime.Serialization.EnumMember(Value = @"AT")]
        AT = 7,

        [System.Runtime.Serialization.EnumMember(Value = @"AU")]
        AU = 8,

        [System.Runtime.Serialization.EnumMember(Value = @"AW")]
        AW = 9,

        [System.Runtime.Serialization.EnumMember(Value = @"AX")]
        AX = 10,

        [System.Runtime.Serialization.EnumMember(Value = @"BB")]
        BB = 11,

        [System.Runtime.Serialization.EnumMember(Value = @"BD")]
        BD = 12,

        [System.Runtime.Serialization.EnumMember(Value = @"BE")]
        BE = 13,

        [System.Runtime.Serialization.EnumMember(Value = @"BF")]
        BF = 14,

        [System.Runtime.Serialization.EnumMember(Value = @"BG")]
        BG = 15,

        [System.Runtime.Serialization.EnumMember(Value = @"BH")]
        BH = 16,

        [System.Runtime.Serialization.EnumMember(Value = @"BI")]
        BI = 17,

        [System.Runtime.Serialization.EnumMember(Value = @"BJ")]
        BJ = 18,

        [System.Runtime.Serialization.EnumMember(Value = @"BK")]
        BK = 19,

        [System.Runtime.Serialization.EnumMember(Value = @"BM")]
        BM = 20,

        [System.Runtime.Serialization.EnumMember(Value = @"BN")]
        BN = 21,

        [System.Runtime.Serialization.EnumMember(Value = @"BO")]
        BO = 22,

        [System.Runtime.Serialization.EnumMember(Value = @"BR")]
        BR = 23,

        [System.Runtime.Serialization.EnumMember(Value = @"BS")]
        BS = 24,

        [System.Runtime.Serialization.EnumMember(Value = @"BU")]
        BU = 25,

        [System.Runtime.Serialization.EnumMember(Value = @"BW")]
        BW = 26,

        [System.Runtime.Serialization.EnumMember(Value = @"BX")]
        BX = 27,

        [System.Runtime.Serialization.EnumMember(Value = @"BZ")]
        BZ = 28,

        [System.Runtime.Serialization.EnumMember(Value = @"CB")]
        CB = 29,

        [System.Runtime.Serialization.EnumMember(Value = @"CC")]
        CC = 30,

        [System.Runtime.Serialization.EnumMember(Value = @"CD")]
        CD = 31,

        [System.Runtime.Serialization.EnumMember(Value = @"CF")]
        CF = 32,

        [System.Runtime.Serialization.EnumMember(Value = @"CG")]
        CG = 33,

        [System.Runtime.Serialization.EnumMember(Value = @"CH")]
        CH = 34,

        [System.Runtime.Serialization.EnumMember(Value = @"CI")]
        CI = 35,

        [System.Runtime.Serialization.EnumMember(Value = @"CJ")]
        CJ = 36,

        [System.Runtime.Serialization.EnumMember(Value = @"CL")]
        CL = 37,

        [System.Runtime.Serialization.EnumMember(Value = @"CM")]
        CM = 38,

        [System.Runtime.Serialization.EnumMember(Value = @"CN")]
        CN = 39,

        [System.Runtime.Serialization.EnumMember(Value = @"CP")]
        CP = 40,

        [System.Runtime.Serialization.EnumMember(Value = @"CS")]
        CS = 41,

        [System.Runtime.Serialization.EnumMember(Value = @"CU")]
        CU = 42,

        [System.Runtime.Serialization.EnumMember(Value = @"CV")]
        CV = 43,

        [System.Runtime.Serialization.EnumMember(Value = @"CY")]
        CY = 44,

        [System.Runtime.Serialization.EnumMember(Value = @"DF")]
        DF = 45,

        [System.Runtime.Serialization.EnumMember(Value = @"DJ")]
        DJ = 46,

        [System.Runtime.Serialization.EnumMember(Value = @"DK")]
        DK = 47,

        [System.Runtime.Serialization.EnumMember(Value = @"DM")]
        DM = 48,

        [System.Runtime.Serialization.EnumMember(Value = @"DO")]
        DO = 49,

        [System.Runtime.Serialization.EnumMember(Value = @"DW")]
        DW = 50,

        [System.Runtime.Serialization.EnumMember(Value = @"DZ")]
        DZ = 51,

        [System.Runtime.Serialization.EnumMember(Value = @"EC")]
        EC = 52,

        [System.Runtime.Serialization.EnumMember(Value = @"EG")]
        EG = 53,

        [System.Runtime.Serialization.EnumMember(Value = @"EM")]
        EM = 54,

        [System.Runtime.Serialization.EnumMember(Value = @"ES")]
        ES = 55,

        [System.Runtime.Serialization.EnumMember(Value = @"ET")]
        ET = 56,

        [System.Runtime.Serialization.EnumMember(Value = @"FA")]
        FA = 57,

        [System.Runtime.Serialization.EnumMember(Value = @"FE")]
        FE = 58,

        [System.Runtime.Serialization.EnumMember(Value = @"FI")]
        FI = 59,

        [System.Runtime.Serialization.EnumMember(Value = @"FJ")]
        FJ = 60,

        [System.Runtime.Serialization.EnumMember(Value = @"FP")]
        FP = 61,

        [System.Runtime.Serialization.EnumMember(Value = @"FR")]
        FR = 62,

        [System.Runtime.Serialization.EnumMember(Value = @"GB")]
        GB = 63,

        [System.Runtime.Serialization.EnumMember(Value = @"GD")]
        GD = 64,

        [System.Runtime.Serialization.EnumMember(Value = @"GE")]
        GE = 65,

        [System.Runtime.Serialization.EnumMember(Value = @"GF")]
        GF = 66,

        [System.Runtime.Serialization.EnumMember(Value = @"GH")]
        GH = 67,

        [System.Runtime.Serialization.EnumMember(Value = @"GI")]
        GI = 68,

        [System.Runtime.Serialization.EnumMember(Value = @"GM")]
        GM = 69,

        [System.Runtime.Serialization.EnumMember(Value = @"GN")]
        GN = 70,

        [System.Runtime.Serialization.EnumMember(Value = @"GP")]
        GP = 71,

        [System.Runtime.Serialization.EnumMember(Value = @"GQ")]
        GQ = 72,

        [System.Runtime.Serialization.EnumMember(Value = @"GR")]
        GR = 73,

        [System.Runtime.Serialization.EnumMember(Value = @"GT")]
        GT = 74,

        [System.Runtime.Serialization.EnumMember(Value = @"GW")]
        GW = 75,

        [System.Runtime.Serialization.EnumMember(Value = @"GX")]
        GX = 76,

        [System.Runtime.Serialization.EnumMember(Value = @"GY")]
        GY = 77,

        [System.Runtime.Serialization.EnumMember(Value = @"HA")]
        HA = 78,

        [System.Runtime.Serialization.EnumMember(Value = @"HK")]
        HK = 79,

        [System.Runtime.Serialization.EnumMember(Value = @"HN")]
        HN = 80,

        [System.Runtime.Serialization.EnumMember(Value = @"HR")]
        HR = 81,

        [System.Runtime.Serialization.EnumMember(Value = @"HU")]
        HU = 82,

        [System.Runtime.Serialization.EnumMember(Value = @"HX")]
        HX = 83,

        [System.Runtime.Serialization.EnumMember(Value = @"IB")]
        IB = 84,

        [System.Runtime.Serialization.EnumMember(Value = @"IC")]
        IC = 85,

        [System.Runtime.Serialization.EnumMember(Value = @"IE")]
        IE = 86,

        [System.Runtime.Serialization.EnumMember(Value = @"IF")]
        IF = 87,

        [System.Runtime.Serialization.EnumMember(Value = @"IG")]
        IG = 88,

        [System.Runtime.Serialization.EnumMember(Value = @"IQ")]
        IQ = 89,

        [System.Runtime.Serialization.EnumMember(Value = @"IR")]
        IR = 90,

        [System.Runtime.Serialization.EnumMember(Value = @"IS")]
        IS = 91,

        [System.Runtime.Serialization.EnumMember(Value = @"IT")]
        IT = 92,

        [System.Runtime.Serialization.EnumMember(Value = @"JM")]
        JM = 93,

        [System.Runtime.Serialization.EnumMember(Value = @"JO")]
        JO = 94,

        [System.Runtime.Serialization.EnumMember(Value = @"JP")]
        JP = 95,

        [System.Runtime.Serialization.EnumMember(Value = @"KA")]
        KA = 96,

        [System.Runtime.Serialization.EnumMember(Value = @"KE")]
        KE = 97,

        [System.Runtime.Serialization.EnumMember(Value = @"KI")]
        KI = 98,

        [System.Runtime.Serialization.EnumMember(Value = @"KN")]
        KN = 99,

        [System.Runtime.Serialization.EnumMember(Value = @"KR")]
        KR = 100,

        [System.Runtime.Serialization.EnumMember(Value = @"KW")]
        KW = 101,

        [System.Runtime.Serialization.EnumMember(Value = @"KX")]
        KX = 102,

        [System.Runtime.Serialization.EnumMember(Value = @"LB")]
        LB = 103,

        [System.Runtime.Serialization.EnumMember(Value = @"LC")]
        LC = 104,

        [System.Runtime.Serialization.EnumMember(Value = @"LE")]
        LE = 105,

        [System.Runtime.Serialization.EnumMember(Value = @"LK")]
        LK = 106,

        [System.Runtime.Serialization.EnumMember(Value = @"LO")]
        LO = 107,

        [System.Runtime.Serialization.EnumMember(Value = @"LR")]
        LR = 108,

        [System.Runtime.Serialization.EnumMember(Value = @"LS")]
        LS = 109,

        [System.Runtime.Serialization.EnumMember(Value = @"LT")]
        LT = 110,

        [System.Runtime.Serialization.EnumMember(Value = @"LU")]
        LU = 111,

        [System.Runtime.Serialization.EnumMember(Value = @"LV")]
        LV = 112,

        [System.Runtime.Serialization.EnumMember(Value = @"LX")]
        LX = 113,

        [System.Runtime.Serialization.EnumMember(Value = @"MC")]
        MC = 114,

        [System.Runtime.Serialization.EnumMember(Value = @"MD")]
        MD = 115,

        [System.Runtime.Serialization.EnumMember(Value = @"MG")]
        MG = 116,

        [System.Runtime.Serialization.EnumMember(Value = @"MH")]
        MH = 117,

        [System.Runtime.Serialization.EnumMember(Value = @"MJ")]
        MJ = 118,

        [System.Runtime.Serialization.EnumMember(Value = @"MK")]
        MK = 119,

        [System.Runtime.Serialization.EnumMember(Value = @"ML")]
        ML = 120,

        [System.Runtime.Serialization.EnumMember(Value = @"MM")]
        MM = 121,

        [System.Runtime.Serialization.EnumMember(Value = @"MP")]
        MP = 122,

        [System.Runtime.Serialization.EnumMember(Value = @"MQ")]
        MQ = 123,

        [System.Runtime.Serialization.EnumMember(Value = @"MR")]
        MR = 124,

        [System.Runtime.Serialization.EnumMember(Value = @"MT")]
        MT = 125,

        [System.Runtime.Serialization.EnumMember(Value = @"MU")]
        MU = 126,

        [System.Runtime.Serialization.EnumMember(Value = @"MV")]
        MV = 127,

        [System.Runtime.Serialization.EnumMember(Value = @"MW")]
        MW = 128,

        [System.Runtime.Serialization.EnumMember(Value = @"MX")]
        MX = 129,

        [System.Runtime.Serialization.EnumMember(Value = @"MY")]
        MY = 130,

        [System.Runtime.Serialization.EnumMember(Value = @"MZ")]
        MZ = 131,

        [System.Runtime.Serialization.EnumMember(Value = @"NA")]
        NA = 132,

        [System.Runtime.Serialization.EnumMember(Value = @"ND")]
        ND = 133,

        [System.Runtime.Serialization.EnumMember(Value = @"NI")]
        NI = 134,

        [System.Runtime.Serialization.EnumMember(Value = @"NL")]
        NL = 135,

        [System.Runtime.Serialization.EnumMember(Value = @"NN")]
        NN = 136,

        [System.Runtime.Serialization.EnumMember(Value = @"NO")]
        NO = 137,

        [System.Runtime.Serialization.EnumMember(Value = @"NP")]
        NP = 138,

        [System.Runtime.Serialization.EnumMember(Value = @"NR")]
        NR = 139,

        [System.Runtime.Serialization.EnumMember(Value = @"NW")]
        NW = 140,

        [System.Runtime.Serialization.EnumMember(Value = @"NZ")]
        NZ = 141,

        [System.Runtime.Serialization.EnumMember(Value = @"OA")]
        OA = 142,

        [System.Runtime.Serialization.EnumMember(Value = @"OM")]
        OM = 143,

        [System.Runtime.Serialization.EnumMember(Value = @"PG")]
        PG = 144,

        [System.Runtime.Serialization.EnumMember(Value = @"PH")]
        PH = 145,

        [System.Runtime.Serialization.EnumMember(Value = @"PK")]
        PK = 146,

        [System.Runtime.Serialization.EnumMember(Value = @"PL")]
        PL = 147,

        [System.Runtime.Serialization.EnumMember(Value = @"PM")]
        PM = 148,

        [System.Runtime.Serialization.EnumMember(Value = @"PS")]
        PS = 149,

        [System.Runtime.Serialization.EnumMember(Value = @"PT")]
        PT = 150,

        [System.Runtime.Serialization.EnumMember(Value = @"PU")]
        PU = 151,

        [System.Runtime.Serialization.EnumMember(Value = @"PY")]
        PY = 152,

        [System.Runtime.Serialization.EnumMember(Value = @"RC")]
        RC = 153,

        [System.Runtime.Serialization.EnumMember(Value = @"RE")]
        RE = 154,

        [System.Runtime.Serialization.EnumMember(Value = @"RO")]
        RO = 155,

        [System.Runtime.Serialization.EnumMember(Value = @"RU")]
        RU = 156,

        [System.Runtime.Serialization.EnumMember(Value = @"RW")]
        RW = 157,

        [System.Runtime.Serialization.EnumMember(Value = @"SA")]
        SA = 158,

        [System.Runtime.Serialization.EnumMember(Value = @"SB")]
        SB = 159,

        [System.Runtime.Serialization.EnumMember(Value = @"SE")]
        SE = 160,

        [System.Runtime.Serialization.EnumMember(Value = @"SF")]
        SF = 161,

        [System.Runtime.Serialization.EnumMember(Value = @"SH")]
        SH = 162,

        [System.Runtime.Serialization.EnumMember(Value = @"SI")]
        SI = 163,

        [System.Runtime.Serialization.EnumMember(Value = @"SN")]
        SN = 164,

        [System.Runtime.Serialization.EnumMember(Value = @"SO")]
        SO = 165,

        [System.Runtime.Serialization.EnumMember(Value = @"SP")]
        SP = 166,

        [System.Runtime.Serialization.EnumMember(Value = @"SR")]
        SR = 167,

        [System.Runtime.Serialization.EnumMember(Value = @"SS")]
        SS = 168,

        [System.Runtime.Serialization.EnumMember(Value = @"ST")]
        ST = 169,

        [System.Runtime.Serialization.EnumMember(Value = @"SU")]
        SU = 170,

        [System.Runtime.Serialization.EnumMember(Value = @"SV")]
        SV = 171,

        [System.Runtime.Serialization.EnumMember(Value = @"SW")]
        SW = 172,

        [System.Runtime.Serialization.EnumMember(Value = @"SX")]
        SX = 173,

        [System.Runtime.Serialization.EnumMember(Value = @"SY")]
        SY = 174,

        [System.Runtime.Serialization.EnumMember(Value = @"SZ")]
        SZ = 175,

        [System.Runtime.Serialization.EnumMember(Value = @"TA")]
        TA = 176,

        [System.Runtime.Serialization.EnumMember(Value = @"TC")]
        TC = 177,

        [System.Runtime.Serialization.EnumMember(Value = @"TD")]
        TD = 178,

        [System.Runtime.Serialization.EnumMember(Value = @"TG")]
        TG = 179,

        [System.Runtime.Serialization.EnumMember(Value = @"TH")]
        TH = 180,

        [System.Runtime.Serialization.EnumMember(Value = @"TR")]
        TR = 181,

        [System.Runtime.Serialization.EnumMember(Value = @"TT")]
        TT = 182,

        [System.Runtime.Serialization.EnumMember(Value = @"TU")]
        TU = 183,

        [System.Runtime.Serialization.EnumMember(Value = @"TV")]
        TV = 184,

        [System.Runtime.Serialization.EnumMember(Value = @"TW")]
        TW = 185,

        [System.Runtime.Serialization.EnumMember(Value = @"TZ")]
        TZ = 186,

        [System.Runtime.Serialization.EnumMember(Value = @"UA")]
        UA = 187,

        [System.Runtime.Serialization.EnumMember(Value = @"UG")]
        UG = 188,

        [System.Runtime.Serialization.EnumMember(Value = @"UK")]
        UK = 189,

        [System.Runtime.Serialization.EnumMember(Value = @"UM")]
        UM = 190,

        [System.Runtime.Serialization.EnumMember(Value = @"US")]
        US = 191,

        [System.Runtime.Serialization.EnumMember(Value = @"UY")]
        UY = 192,

        [System.Runtime.Serialization.EnumMember(Value = @"VC")]
        VC = 193,

        [System.Runtime.Serialization.EnumMember(Value = @"VE")]
        VE = 194,

        [System.Runtime.Serialization.EnumMember(Value = @"VG")]
        VG = 195,

        [System.Runtime.Serialization.EnumMember(Value = @"VN")]
        VN = 196,

        [System.Runtime.Serialization.EnumMember(Value = @"VU")]
        VU = 197,

        [System.Runtime.Serialization.EnumMember(Value = @"WS")]
        WS = 198,

        [System.Runtime.Serialization.EnumMember(Value = @"WT")]
        WT = 199,

        [System.Runtime.Serialization.EnumMember(Value = @"XN")]
        XN = 200,

        [System.Runtime.Serialization.EnumMember(Value = @"YE")]
        YE = 201,

        [System.Runtime.Serialization.EnumMember(Value = @"YS")]
        YS = 202,

        [System.Runtime.Serialization.EnumMember(Value = @"ZA")]
        ZA = 203,

        [System.Runtime.Serialization.EnumMember(Value = @"ZM")]
        ZM = 204,

        [System.Runtime.Serialization.EnumMember(Value = @"ZR")]
        ZR = 205,

        [System.Runtime.Serialization.EnumMember(Value = @"ZW")]
        ZW = 206,

    }

    /// <summary>Estado en que se ubica el domicilio &lt;table&gt;&lt;thead&gt;&lt;tr&gt;&lt;th&gt;Clave&lt;/th&gt;&lt;th&gt;Estado&lt;/th&gt;&lt;/tr&gt;&lt;/thead&gt;&lt;tbody&gt;&lt;tr&gt;&lt;td&gt;Aguascalientes&lt;/td&gt;&lt;td&gt;AGS&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Baja California Norte&lt;/td&gt;&lt;td&gt;BCN&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Baja California Sur&lt;/td&gt;&lt;td&gt;BCS&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Campeche&lt;/td&gt;&lt;td&gt;CAM&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Chiapas&lt;/td&gt;&lt;td&gt;CHS&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Chihuahua&lt;/td&gt;&lt;td&gt;CHI&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Coahuila&lt;/td&gt;&lt;td&gt;COA&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Colima&lt;/td&gt;&lt;td&gt;COL&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Ciudad de México o Distrito Federal&amp;nbsp;&lt;/td&gt;&lt;td&gt;CDMX&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Durango&lt;/td&gt;&lt;td&gt;DGO&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Estado de México&lt;/td&gt;&lt;td&gt;EM&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Guanajuato&lt;/td&gt;&lt;td&gt;GTO&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Guerrero&lt;/td&gt;&lt;td&gt;GRO&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Hidalgo&lt;/td&gt;&lt;td&gt;HGO&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Jalisco&lt;/td&gt;&lt;td&gt;JAL&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Michoacán&lt;/td&gt;&lt;td&gt;MICH&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Morelos&lt;/td&gt;&lt;td&gt;MOR&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Nayarit&lt;/td&gt;&lt;td&gt;NAY&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Nuevo León&lt;/td&gt;&lt;td&gt;NL&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Oaxaca&lt;/td&gt;&lt;td&gt;OAX&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Puebla&lt;/td&gt;&lt;td&gt;PUE&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Querétaro&lt;/td&gt;&lt;td&gt;QRO&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Quintana Roo&lt;/td&gt;&lt;td&gt;QR&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;San Luis Potosí&lt;/td&gt;&lt;td&gt;SLP&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Sinaloa&lt;/td&gt;&lt;td&gt;SIN&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Sonora&lt;/td&gt;&lt;td&gt;SON&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Tabasco&lt;/td&gt;&lt;td&gt;TAB&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Tamaulipas&lt;/td&gt;&lt;td&gt;TAM&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Tlaxcala&lt;/td&gt;&lt;td&gt;TLA&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Veracruz&lt;/td&gt;&lt;td&gt;VER&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Yucatán&lt;/td&gt;&lt;td&gt;YUC&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Zacatecas&lt;/td&gt;&lt;td&gt;ZAC&lt;/td&gt;&lt;/tr&gt;&lt;/tbody&gt;&lt;/table&gt;</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum CatalogoEstados
    {
        [System.Runtime.Serialization.EnumMember(Value = @"AGS")]
        AGS = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"BCN")]
        BCN = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"BCS")]
        BCS = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"CAM")]
        CAM = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"CHS")]
        CHS = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"CHI")]
        CHI = 5,

        [System.Runtime.Serialization.EnumMember(Value = @"COA")]
        COA = 6,

        [System.Runtime.Serialization.EnumMember(Value = @"COL")]
        COL = 7,

        [System.Runtime.Serialization.EnumMember(Value = @"CDMX")]
        CDMX = 8,

        [System.Runtime.Serialization.EnumMember(Value = @"DGO")]
        DGO = 9,

        [System.Runtime.Serialization.EnumMember(Value = @"EM")]
        EM = 10,

        [System.Runtime.Serialization.EnumMember(Value = @"GTO")]
        GTO = 11,

        [System.Runtime.Serialization.EnumMember(Value = @"GRO")]
        GRO = 12,

        [System.Runtime.Serialization.EnumMember(Value = @"HGO")]
        HGO = 13,

        [System.Runtime.Serialization.EnumMember(Value = @"JAL")]
        JAL = 14,

        [System.Runtime.Serialization.EnumMember(Value = @"MICH")]
        MICH = 15,

        [System.Runtime.Serialization.EnumMember(Value = @"MOR")]
        MOR = 16,

        [System.Runtime.Serialization.EnumMember(Value = @"NAY")]
        NAY = 17,

        [System.Runtime.Serialization.EnumMember(Value = @"NL")]
        NL = 18,

        [System.Runtime.Serialization.EnumMember(Value = @"OAX")]
        OAX = 19,

        [System.Runtime.Serialization.EnumMember(Value = @"PUE")]
        PUE = 20,

        [System.Runtime.Serialization.EnumMember(Value = @"QRO")]
        QRO = 21,

        [System.Runtime.Serialization.EnumMember(Value = @"QR")]
        QR = 22,

        [System.Runtime.Serialization.EnumMember(Value = @"SLP")]
        SLP = 23,

        [System.Runtime.Serialization.EnumMember(Value = @"SIN")]
        SIN = 24,

        [System.Runtime.Serialization.EnumMember(Value = @"SON")]
        SON = 25,

        [System.Runtime.Serialization.EnumMember(Value = @"TAB")]
        TAB = 26,

        [System.Runtime.Serialization.EnumMember(Value = @"TAM")]
        TAM = 27,

        [System.Runtime.Serialization.EnumMember(Value = @"TLA")]
        TLA = 28,

        [System.Runtime.Serialization.EnumMember(Value = @"VER")]
        VER = 29,

        [System.Runtime.Serialization.EnumMember(Value = @"YUC")]
        YUC = 30,

        [System.Runtime.Serialization.EnumMember(Value = @"ZAC")]
        ZAC = 31,


        [System.Runtime.Serialization.EnumMember(Value = @"DF")]
        DF = 32,

    }

    /// <summary>&lt;table&gt; &lt;thead&gt; &lt;tr&gt; &lt;th&gt;Clave&lt;/th&gt; &lt;th&gt;Descripción&lt;/th&gt; &lt;/tr&gt; &lt;/thead&gt; &lt;tr&gt; &lt;td&gt;0&lt;/td&gt; &lt;td&gt;No encontrado&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;1&lt;/td&gt; &lt;td&gt;Encontrado&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;2&lt;/td&gt; &lt;td&gt;Sistema no disponible&lt;/td&gt; &lt;/tr&gt; &lt;tr&gt; &lt;td&gt;3&lt;/td&gt; &lt;td&gt;Ambiguo&lt;/td&gt; &lt;/tr&gt; &lt;/table&gt;</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum CatalogoClaveRetorno
    {
        [System.Runtime.Serialization.EnumMember(Value = @"0")]
        _0 = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"1")]
        _1 = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"2")]
        _2 = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"3")]
        _3 = 3,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class CuentasFinancierasRespuesta
    {
        /// <summary>RFC de la compañía. El dato es opcional cuando se reporta un acreditado con domicilio en el extranjero.</summary>
        [Newtonsoft.Json.JsonProperty("RFC", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(13, MinimumLength = 10)]
        public string RFC { get; set; }

        /// <summary>Nombre de la entidad que otorga el crédito.</summary>
        [Newtonsoft.Json.JsonProperty("nombreOtorgante", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(99, MinimumLength = 2)]
        public string NombreOtorgante { get; set; }

        /// <summary>Número de contrato.</summary>
        [Newtonsoft.Json.JsonProperty("contrato", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(25, MinimumLength = 2)]
        public string Contrato { get; set; }

        /// <summary>Saldo inicial del crédito.</summary>
        [Newtonsoft.Json.JsonProperty("saldoInicial", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public float? SaldoInicial { get; set; }

        /// <summary>Saldo total del crédito.</summary>
        [Newtonsoft.Json.JsonProperty("saldoTotal", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public float? SaldoTotal { get; set; }

        [Newtonsoft.Json.JsonProperty("moneda", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(3, MinimumLength = 3)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public CatalogoTipoMoneda? Moneda { get; set; }

        /// <summary>Fecha de apertura del crédito, en el formato especificado (por defecto yyyy-MM-dd).</summary>
        [Newtonsoft.Json.JsonProperty("fechaApertura", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(10)]
        public string FechaApertura { get; set; }

        /// <summary>Término en el que se pactó el crédito. Deberá reportarse en días.</summary>
        [Newtonsoft.Json.JsonProperty("plazo", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Plazo { get; set; }

        [Newtonsoft.Json.JsonProperty("clavesObservacion", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(2, MinimumLength = 2)]
        public string ClavesObservacion { get; set; }

        [Newtonsoft.Json.JsonProperty("tipoCredito", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(4, MinimumLength = 4)]
        public string TipoCredito { get; set; }

        /// <summary>Monto Vigente. Sólo con créditos abiertos.</summary>
        [Newtonsoft.Json.JsonProperty("vigente", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public float? Vigente { get; set; }

        /// <summary>Vencido de 1 a 29 días. Sólo con créditos abiertos.</summary>
        [Newtonsoft.Json.JsonProperty("29dias", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? _29dias { get; set; }

        /// <summary>Vencido de 30 a 59 días. Sólo con créditos abiertos.</summary>
        [Newtonsoft.Json.JsonProperty("59dias", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? _59dias { get; set; }

        /// <summary>Vencido de 60 a 89 días. Sólo con créditos abiertos.</summary>
        [Newtonsoft.Json.JsonProperty("89dias", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? _89dias { get; set; }

        /// <summary>Vencido de 90 a 119 días. Sólo con créditos abiertos.</summary>
        [Newtonsoft.Json.JsonProperty("119dias", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? _119dias { get; set; }

        /// <summary>Vencido de 120 a 179 días. Sólo con créditos abiertos.</summary>
        [Newtonsoft.Json.JsonProperty("179dias", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? _179dias { get; set; }

        /// <summary>Vencido 180 días a más. Sólo con créditos abiertos.</summary>
        [Newtonsoft.Json.JsonProperty("180MasDias", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? _180MasDias { get; set; }

        /// <summary>Último periodo de actualización (sólo con créditos abiertos), en el formato especificado (por defecto yyyy-MM).</summary>
        [Newtonsoft.Json.JsonProperty("actualizacion", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(10)]
        public string Actualizacion { get; set; }

        /// <summary>Fecha de cierre del crédito (sólo con créditos cerrados), en el formato especificado (por defecto yyyy-MM-dd).</summary>
        [Newtonsoft.Json.JsonProperty("fechaCierre", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(10)]
        public string FechaCierre { get; set; }

        /// <summary>Pago efectuado al cierre del crédito. Sólo con créditos cerrados.</summary>
        [Newtonsoft.Json.JsonProperty("pagoEfectivo", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public float? PagoEfectivo { get; set; }

        /// <summary>Monto de la quita. Solo con créditos cerrados.</summary>
        [Newtonsoft.Json.JsonProperty("quita", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public float? Quita { get; set; }

        /// <summary>Monto de la dación. Solo con créditos cerrados.</summary>
        [Newtonsoft.Json.JsonProperty("dacionPago", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public float? DacionPago { get; set; }

        /// <summary>Monto del quebranto efectuado. Solo con créditos cerrados.</summary>
        [Newtonsoft.Json.JsonProperty("quebrantoCastigo", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public float? QuebrantoCastigo { get; set; }

        /// <summary>Patrón histórico de pagos</summary>
        [Newtonsoft.Json.JsonProperty("historia", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Historia { get; set; }

        /// <summary>Muestra la cantidad exacta de días de atraso cuando se reportan montos con vencimiento.</summary>
        [Newtonsoft.Json.JsonProperty("atrasoMayor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? AtrasoMayor { get; set; }

        /// <summary>Si contiene RI, el registro está impugnado.</summary>
        [Newtonsoft.Json.JsonProperty("registroImpugnado", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(2, MinimumLength = 2)]
        public string RegistroImpugnado { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class CuentasComercialesRespuesta
    {
        /// <summary>RFC de la compañía. El dato es opcional cuando se reporta un acreditado con domicilio en el extranjero.</summary>
        [Newtonsoft.Json.JsonProperty("RFC", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(13, MinimumLength = 10)]
        public string RFC { get; set; }

        /// <summary>Nombre de la entidad que otorga el crédito.</summary>
        [Newtonsoft.Json.JsonProperty("nombreOtorgante", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(99, MinimumLength = 2)]
        public string NombreOtorgante { get; set; }

        [Newtonsoft.Json.JsonProperty("moneda", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(3, MinimumLength = 3)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public CatalogoTipoMoneda? Moneda { get; set; }

        /// <summary>Monto Vigente. Sólo con créditos abiertos.</summary>
        [Newtonsoft.Json.JsonProperty("vigente", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public float? Vigente { get; set; }

        /// <summary>Saldo total del crédito.</summary>
        [Newtonsoft.Json.JsonProperty("saldoTotal", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public float? SaldoTotal { get; set; }

        /// <summary>Vencido de 1 a 29 días. Sólo con créditos abiertos.</summary>
        [Newtonsoft.Json.JsonProperty("29dias", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? _29dias { get; set; }

        /// <summary>Vencido de 30 a 59 días. Sólo con créditos abiertos.</summary>
        [Newtonsoft.Json.JsonProperty("59dias", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? _59dias { get; set; }

        /// <summary>Vencido de 60 a 89 días. Sólo con créditos abiertos.</summary>
        [Newtonsoft.Json.JsonProperty("89dias", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? _89dias { get; set; }

        /// <summary>Vencido de 90 a 119 días. Sólo con créditos abiertos.</summary>
        [Newtonsoft.Json.JsonProperty("119dias", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? _119dias { get; set; }

        /// <summary>Vencido de 120 a 179 días. Sólo con créditos abiertos.</summary>
        [Newtonsoft.Json.JsonProperty("179dias", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? _179dias { get; set; }

        /// <summary>Vencido 180 días a más. Sólo con créditos abiertos.</summary>
        [Newtonsoft.Json.JsonProperty("180MasDias", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? _180MasDias { get; set; }

        /// <summary>Último periodo de actualización. Sólo con créditos abiertos), en el formato especificado (por defecto yyyy-MM).</summary>
        [Newtonsoft.Json.JsonProperty("actualizacion", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(10)]
        public string Actualizacion { get; set; }

        /// <summary>Patrón histórico de pagos.</summary>
        [Newtonsoft.Json.JsonProperty("historia", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Historia { get; set; }

        /// <summary>Muestra la cantidad exacta de días de atraso cuando se reportan montos con vencimiento.</summary>
        [Newtonsoft.Json.JsonProperty("atrasoMayor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? AtrasoMayor { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class DeclarativasRespuesta
    {
        /// <summary>Declarativa del acreditado en razón de su desacuerdo con el resultado del proceso de reclamación a una institución otorgante.</summary>
        [Newtonsoft.Json.JsonProperty("declarativa", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(99, MinimumLength = 1)]
        public string Declarativa { get; set; }

        /// <summary>Fecha de nacimiento de la persona, en el formato especificado (por defecto yyyy-MM-dd).</summary>
        [Newtonsoft.Json.JsonProperty("fechaDeclarativa", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(10)]
        public string FechaDeclarativa { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class CalificacionCarteraRespuesta
    {
        [Newtonsoft.Json.JsonProperty("calificacion", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(2, MinimumLength = 2)]
        public string Calificacion { get; set; }

        /// <summary>Nombre del otorgante que envían la calificacio.́n</summary>
        [Newtonsoft.Json.JsonProperty("nombreOtorgante", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(99, MinimumLength = 2)]
        public string NombreOtorgante { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ClavePrevencionesRespuesta
    {
        /// <summary>Nombre del otorgante.</summary>
        [Newtonsoft.Json.JsonProperty("nombreOtorgante", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(99, MinimumLength = 2)]
        public string NombreOtorgante { get; set; }

        /// <summary>Fecha reporte, en el formato especificado (por defecto yyyy-MM-dd).</summary>
        [Newtonsoft.Json.JsonProperty("fechaReporte", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(10)]
        public string FechaReporte { get; set; }

        /// <summary>Número de contrato.</summary>
        [Newtonsoft.Json.JsonProperty("numeroContrato", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NumeroContrato { get; set; }

        [Newtonsoft.Json.JsonProperty("clavePrevencion", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(2, MinimumLength = 2)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public CatalogoClavesPrevencion? ClavePrevencion { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ClavesBanxico
    {
        [Newtonsoft.Json.JsonProperty("claveBanxico1", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(7, MinimumLength = 1)]
        public string ClaveBanxico1 { get; set; }

        [Newtonsoft.Json.JsonProperty("claveBanxico2", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(7, MinimumLength = 1)]
        public string ClaveBanxico2 { get; set; }

        [Newtonsoft.Json.JsonProperty("claveBanxico3", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(7, MinimumLength = 1)]
        public string ClaveBanxico3 { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Consultas : System.Collections.ObjectModel.Collection<Anonymous>
    {

    }

    /// <summary>Consultas realizadas por entidades comerciales.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ConsultasComerciales
    {
        /// <summary>Consultas en los últimos 13 meses.</summary>
        [Newtonsoft.Json.JsonProperty("ultimos3meses", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Ultimos3meses { get; set; }

        /// <summary>Consultas en los últimos 12 meses.</summary>
        [Newtonsoft.Json.JsonProperty("ultimos12meses", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Ultimos12meses { get; set; }

        /// <summary>Consultas en los últimos 24 meses.</summary>
        [Newtonsoft.Json.JsonProperty("ultimos24meses", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Ultimos24meses { get; set; }

        /// <summary>Consultas en más de 24 meses.</summary>
        [Newtonsoft.Json.JsonProperty("mas24meses", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? Mas24meses { get; set; }


    }

    /// <summary>Consultas realizadas por entidades financieras.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ConsultasFinancieras
    {
        /// <summary>Consultas en los últimos 13 meses.</summary>
        [Newtonsoft.Json.JsonProperty("ultimos3meses", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Ultimos3meses { get; set; }

        /// <summary>Consultas en los últimos 12 meses.</summary>
        [Newtonsoft.Json.JsonProperty("ultimos12meses", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Ultimos12meses { get; set; }

        /// <summary>Consultas en los últimos 24 meses</summary>
        [Newtonsoft.Json.JsonProperty("ultimos24meses", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Ultimos24meses { get; set; }

        /// <summary>Consultas en más de 24 meses</summary>
        [Newtonsoft.Json.JsonProperty("mas24meses", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? Mas24meses { get; set; }


    }

    /// <summary>Datos generales de la persona a consultar.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PersonaPeticion
    {
        /// <summary>Identificador de la consulta, dato ingresado por el usuario.</summary>
        [Newtonsoft.Json.JsonProperty("folioOtorgante", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(25, MinimumLength = 1)]
        public string FolioOtorgante { get; set; }

        [Newtonsoft.Json.JsonProperty("persona", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public Persona Persona { get; set; } = new Persona();


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Persona
    {
        /// <summary>RFC de la compañía. El dato es opcional cuando se reporta un acreditado con domicilio en el extranjero. Cuando se cuenta con el dato debe ser capturado, pues aplica para el proceso de búsqueda e integración de expedientes.</summary>
        [Newtonsoft.Json.JsonProperty("RFC", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(13, MinimumLength = 10)]
        public string RFC { get; set; }

        /// <summary>Nombre de la compañía (Persona Moral) o primer nombre de la Persona Física con Actividad Empresarial.</summary>
        [Newtonsoft.Json.JsonProperty("nombre", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(75, MinimumLength = 2)]
        public string Nombre { get; set; }

        [Newtonsoft.Json.JsonProperty("domicilio", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public Domicilio Domicilio { get; set; } = new Domicilio();


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PersonaRespuesta
    {
        /// <summary>RFC de la compañía. El dato es opcional cuando se reporta un acreditado con domicilio en el extranjero. Cuando se cuenta con el dato debe ser capturado, pues aplica para el proceso de búsqueda e integración de expedientes.</summary>
        [Newtonsoft.Json.JsonProperty("RFC", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(13, MinimumLength = 10)]
        public string RFC { get; set; }

        /// <summary>Nombre de la compañía (Persona Moral) o primer nombre de la Persona Física con Actividad Empresarial.</summary>
        [Newtonsoft.Json.JsonProperty("nombre", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(75, MinimumLength = 2)]
        public string Nombre { get; set; }

        [Newtonsoft.Json.JsonProperty("nacionalidad", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(2, MinimumLength = 2)]
        public string Nacionalidad { get; set; }

        [Newtonsoft.Json.JsonProperty("domicilio", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Domicilio2 Domicilio { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PersonaAvales
    {
        /// <summary>En caso de Accionista o Aval con domicilio en el Extranjero podría no presentarse el dato.</summary>
        [Newtonsoft.Json.JsonProperty("RFC", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(13, MinimumLength = 10)]
        public string RFC { get; set; }

        /// <summary>Código Único de Registro de Población</summary>
        [Newtonsoft.Json.JsonProperty("CURP", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(18, MinimumLength = 18)]
        public string CURP { get; set; }

        /// <summary>Nombre de la persona.</summary>
        [Newtonsoft.Json.JsonProperty("nombre", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(75, MinimumLength = 2)]
        public string Nombre { get; set; }

        /// <summary>Segundo nombre de la persona</summary>
        [Newtonsoft.Json.JsonProperty("segundoNombre", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(75, MinimumLength = 2)]
        public string SegundoNombre { get; set; }

        /// <summary>Apellido paterno de la persona.</summary>
        [Newtonsoft.Json.JsonProperty("apellidoPaterno", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(25, MinimumLength = 2)]
        public string ApellidoPaterno { get; set; }

        /// <summary>Apellido materno de la persona.</summary>
        [Newtonsoft.Json.JsonProperty("apellidoMaterno", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(25, MinimumLength = 2)]
        public string ApellidoMaterno { get; set; }

        [Newtonsoft.Json.JsonProperty("domicilio", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Domicilio3 Domicilio { get; set; }

        /// <summary>Cantidad por la cual fue avalado, sólo para Avales.</summary>
        [Newtonsoft.Json.JsonProperty("cantidad", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public float? Cantidad { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class PersonaAccionistas
    {
        /// <summary>En caso de Accionista o Aval con domicilio en el Extranjero podría no presentarse el dato.</summary>
        [Newtonsoft.Json.JsonProperty("RFC", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(13, MinimumLength = 10)]
        public string RFC { get; set; }

        /// <summary>Código Único de Registro de Población.</summary>
        [Newtonsoft.Json.JsonProperty("CURP", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(18, MinimumLength = 18)]
        public string CURP { get; set; }

        /// <summary>Nombre de la persona.</summary>
        [Newtonsoft.Json.JsonProperty("nombre", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(75, MinimumLength = 2)]
        public string Nombre { get; set; }

        /// <summary>Segundo nombre de la persona.</summary>
        [Newtonsoft.Json.JsonProperty("segundoNombre", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(75, MinimumLength = 2)]
        public string SegundoNombre { get; set; }

        /// <summary>Apellido paterno de la persona.</summary>
        [Newtonsoft.Json.JsonProperty("apellidoPaterno", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(25, MinimumLength = 2)]
        public string ApellidoPaterno { get; set; }

        /// <summary>Apellido materno de la persona.</summary>
        [Newtonsoft.Json.JsonProperty("apellidoMaterno", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(25, MinimumLength = 2)]
        public string ApellidoMaterno { get; set; }

        [Newtonsoft.Json.JsonProperty("domicilio", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Domicilio4 Domicilio { get; set; }

        /// <summary>Porcentaje de Acciones, sólo para Accionistas.</summary>
        [Newtonsoft.Json.JsonProperty("porcentaje", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Porcentaje { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ReporteRespuesta
    {
        /// <summary>Número de folio de transacción asignado por Círculo de Crédito</summary>
        [Newtonsoft.Json.JsonProperty("folioConsulta", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(15, MinimumLength = 1)]
        public string FolioConsulta { get; set; }

        /// <summary>Identificador de la consulta para verificaciones adicionales</summary>
        [Newtonsoft.Json.JsonProperty("folioOtorgante", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(25, MinimumLength = 1)]
        public string FolioOtorgante { get; set; }

        [Newtonsoft.Json.JsonProperty("claveRetorno", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(1, MinimumLength = 1)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public CatalogoClaveRetorno? ClaveRetorno { get; set; }

        /// <summary>Fecha de la consulta</summary>
        [Newtonsoft.Json.JsonProperty("fechaConsulta", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(10)]
        public string FechaConsulta { get; set; }

        [Newtonsoft.Json.JsonProperty("persona", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PersonaRespuesta Persona { get; set; }

        [Newtonsoft.Json.JsonProperty("clavesBanxico", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ClavesBanxico ClavesBanxico { get; set; }

        [Newtonsoft.Json.JsonProperty("calificacionCartera", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CalificacionCarteraRespuesta> CalificacionCartera { get; set; }

        [Newtonsoft.Json.JsonProperty("clavePrevenciones", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ClavePrevencionesRespuesta ClavePrevenciones { get; set; }

        [Newtonsoft.Json.JsonProperty("consultasInstitucionales", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ConsultasInstitucionales ConsultasInstitucionales { get; set; }

        [Newtonsoft.Json.JsonProperty("declarativas", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<DeclarativasRespuesta> Declarativas { get; set; }

        [Newtonsoft.Json.JsonProperty("accionistas", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PersonaAccionistas> Accionistas { get; set; }

        [Newtonsoft.Json.JsonProperty("avales", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PersonaAvales> Avales { get; set; }

        [Newtonsoft.Json.JsonProperty("credito", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Credito Credito { get; set; }


    }

    /// <summary>error</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Error
    {
        /// <summary>Código de error.</summary>
        [Newtonsoft.Json.JsonProperty("codigo", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Codigo { get; set; }

        /// <summary>Mensaje de error.</summary>
        [Newtonsoft.Json.JsonProperty("mensaje", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Mensaje { get; set; }


    }

    /// <summary>Si existen errores, se listarán.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Errores
    {
        [Newtonsoft.Json.JsonProperty("errores", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Error> Errores1 { get; set; }


    }

    /// <summary>Consultas realizadas a la Persona Moral o Física.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Anonymous
    {
        /// <summary>Fecha de Consulta, en el formato especificado (por defecto yyyy-MM-dd).</summary>
        [Newtonsoft.Json.JsonProperty("fechaConsulta", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(10)]
        public string FechaConsulta { get; set; }

        /// <summary>Indica de dónde proviene la información de cliente.</summary>
        [Newtonsoft.Json.JsonProperty("nombreOtorgante", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(99, MinimumLength = 2)]
        public string NombreOtorgante { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Domicilio
    {
        /// <summary>Campo de dirección en que se ubica el domicilio.</summary>
        [Newtonsoft.Json.JsonProperty("direccion", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(85, MinimumLength = 2)]
        public string Direccion { get; set; }

        /// <summary>Para domicilios en México se validará la correcta correspondencia del código postal contra el estado ingresado. En el caso de domicilios en el extranjero debe reportarse un dato válido. No rellenar espacio.</summary>
        [Newtonsoft.Json.JsonProperty("CP", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(10, MinimumLength = 5)]
        public string CP { get; set; }

        /// <summary>Delegación o municipio en que se ubica el domicilio.</summary>
        [Newtonsoft.Json.JsonProperty("delegacionMunicipio", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(60, MinimumLength = 2)]
        public string DelegacionMunicipio { get; set; }

        /// <summary>Colonia o población en que se ubica el domicilio.</summary>
        [Newtonsoft.Json.JsonProperty("coloniaPoblacion", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(60, MinimumLength = 2)]
        public string ColoniaPoblacion { get; set; }

        /// <summary>Ciudad en que se ubica el domicilio.</summary>
        [Newtonsoft.Json.JsonProperty("ciudad", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(40, MinimumLength = 2)]
        public string Ciudad { get; set; }

        [Newtonsoft.Json.JsonProperty("estado", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(4, MinimumLength = 1)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public CatalogoEstados Estado { get; set; }

        /// <summary>Cuando se solicita el Reporte de Crédito de un Acreditado con domicilio en el extranjero debe ingresarse el nombre completo del estado, provincia, distrito o población donde está el domicilio.</summary>
        [Newtonsoft.Json.JsonProperty("estadoExtranjero", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(40, MinimumLength = 2)]
        public string EstadoExtranjero { get; set; }

        [Newtonsoft.Json.JsonProperty("pais", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(2, MinimumLength = 2)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public CatalogoPais Pais { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Domicilio2
    {
        /// <summary>Campo de dirección en que se ubica el domicilio.</summary>
        [Newtonsoft.Json.JsonProperty("direccion", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(40, MinimumLength = 2)]
        public string Direccion { get; set; }

        /// <summary>Colonia en que se ubica el domicilio.</summary>
        [Newtonsoft.Json.JsonProperty("coloniaPoblacion", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(60, MinimumLength = 2)]
        public string ColoniaPoblacion { get; set; }

        /// <summary>Colonia o municipio en que se ubica el domicilio.</summary>
        [Newtonsoft.Json.JsonProperty("delegacionMunicipio", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(60, MinimumLength = 2)]
        public string DelegacionMunicipio { get; set; }

        /// <summary>Ciudad en que se ubica el domicilio.</summary>
        [Newtonsoft.Json.JsonProperty("ciudad", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(40, MinimumLength = 2)]
        public string Ciudad { get; set; }

        [Newtonsoft.Json.JsonProperty("estado", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(4, MinimumLength = 1)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public CatalogoEstados? Estado { get; set; }

        /// <summary>Para domicilios en México se validará la correcta correspondencia del código postal contra el estado ingresado. En el caso de domicilios en el extranjero debe reportarse un dato válido. No rellenar espacio.</summary>
        [Newtonsoft.Json.JsonProperty("CP", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(10, MinimumLength = 5)]
        public string CP { get; set; }

        [Newtonsoft.Json.JsonProperty("pais", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(2, MinimumLength = 2)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public CatalogoPais? Pais { get; set; }

        /// <summary>Número de Teléfono.</summary>
        [Newtonsoft.Json.JsonProperty("telefono", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(11, MinimumLength = 2)]
        public string Telefono { get; set; }

        /// <summary>Número de Extensión.</summary>
        [Newtonsoft.Json.JsonProperty("extension", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(8, MinimumLength = 2)]
        public string Extension { get; set; }

        /// <summary>Número de Fax.</summary>
        [Newtonsoft.Json.JsonProperty("fax", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(11, MinimumLength = 2)]
        public string Fax { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Domicilio3
    {
        /// <summary>Campo de dirección en que se ubica el domicilio.</summary>
        [Newtonsoft.Json.JsonProperty("direccion", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(40, MinimumLength = 2)]
        public string Direccion { get; set; }

        /// <summary>Colonia o población en que se ubica el domicilio.</summary>
        [Newtonsoft.Json.JsonProperty("coloniaPoblacion", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(60, MinimumLength = 2)]
        public string ColoniaPoblacion { get; set; }

        /// <summary>Delegacion o municipio en que se ubica el domicilio.</summary>
        [Newtonsoft.Json.JsonProperty("delegacionMunicipio", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(40, MinimumLength = 2)]
        public string DelegacionMunicipio { get; set; }

        /// <summary>Ciudad en que se ubica el domicilio.</summary>
        [Newtonsoft.Json.JsonProperty("ciudad", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(40, MinimumLength = 2)]
        public string Ciudad { get; set; }

        [Newtonsoft.Json.JsonProperty("estado", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(4, MinimumLength = 1)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public CatalogoEstados? Estado { get; set; }

        /// <summary>Para domicilios en México se validará la correcta correspondencia del código postal contra el estado ingresado. En el caso de domicilios en el extranjero debe reportarse un dato válido. No rellenar espacio.</summary>
        [Newtonsoft.Json.JsonProperty("CP", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(10, MinimumLength = 5)]
        public string CP { get; set; }

        [Newtonsoft.Json.JsonProperty("pais", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(2, MinimumLength = 2)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public CatalogoPais? Pais { get; set; }

        /// <summary>Número de Teléfono.</summary>
        [Newtonsoft.Json.JsonProperty("telefono", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(11, MinimumLength = 2)]
        public string Telefono { get; set; }

        /// <summary>Número de Extensión.</summary>
        [Newtonsoft.Json.JsonProperty("extension", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(8, MinimumLength = 2)]
        public string Extension { get; set; }

        /// <summary>Número de Fax</summary>
        [Newtonsoft.Json.JsonProperty("fax", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(11, MinimumLength = 2)]
        public string Fax { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Domicilio4
    {
        /// <summary>Campo de dirección en que se ubica el domicilio.</summary>
        [Newtonsoft.Json.JsonProperty("direccion", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(40, MinimumLength = 2)]
        public string Direccion { get; set; }

        /// <summary>Colonia o población en que se ubica el domicilio.</summary>
        [Newtonsoft.Json.JsonProperty("coloniaPoblacion", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(60, MinimumLength = 2)]
        public string ColoniaPoblacion { get; set; }

        /// <summary>Delegacion o municipio en que se ubica el domicilio.</summary>
        [Newtonsoft.Json.JsonProperty("delegacionMunicipio", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(40, MinimumLength = 2)]
        public string DelegacionMunicipio { get; set; }

        /// <summary>Ciudad en que se ubica el domicilio.</summary>
        [Newtonsoft.Json.JsonProperty("ciudad", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(40, MinimumLength = 2)]
        public string Ciudad { get; set; }

        /// <summary>Estado en que se ubica el domicilio.</summary>
        [Newtonsoft.Json.JsonProperty("estado", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(40, MinimumLength = 2)]
        public string Estado { get; set; }

        /// <summary>Para domicilios en México se validará la correcta correspondencia del código postal contra el estado ingresado. En el caso de domicilios en el extranjero debe reportarse un dato válido. No rellenar espacio.</summary>
        [Newtonsoft.Json.JsonProperty("CP", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(10, MinimumLength = 5)]
        public string CP { get; set; }

        [Newtonsoft.Json.JsonProperty("pais", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(2, MinimumLength = 2)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public CatalogoPais? Pais { get; set; }

        /// <summary>Número de Teléfono.</summary>
        [Newtonsoft.Json.JsonProperty("telefono", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(11, MinimumLength = 2)]
        public string Telefono { get; set; }

        /// <summary>Número de Extensión.</summary>
        [Newtonsoft.Json.JsonProperty("extension", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(8, MinimumLength = 2)]
        public string Extension { get; set; }

        /// <summary>Número de Fax.</summary>
        [Newtonsoft.Json.JsonProperty("fax", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(11, MinimumLength = 2)]
        public string Fax { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ConsultasInstitucionales
    {
        [Newtonsoft.Json.JsonProperty("comerciales", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ConsultasComerciales Comerciales { get; set; }

        [Newtonsoft.Json.JsonProperty("financieras", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ConsultasFinancieras Financieras { get; set; }

        [Newtonsoft.Json.JsonProperty("consultas", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Consultas Consultas { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Credito
    {
        [Newtonsoft.Json.JsonProperty("cuentasFinancieras", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CuentasFinancierasRespuesta> CuentasFinancieras { get; set; }

        [Newtonsoft.Json.JsonProperty("cuentasComerciales", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CuentasComercialesRespuesta> CuentasComerciales { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.14.1.0 (NJsonSchema v10.5.2.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class ApiException : System.Exception
    {
        public int StatusCode { get; private set; }

        public string Response { get; private set; }

        public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

        public ApiException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Exception innerException)
            : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + ((response == null) ? "(null)" : response.Substring(0, response.Length >= 512 ? 512 : response.Length)), innerException)
        {
            StatusCode = statusCode;
            Response = response;
            Headers = headers;
        }

        public override string ToString()
        {
            return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.14.1.0 (NJsonSchema v10.5.2.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class ApiException<TResult> : ApiException
    {
        public TResult Result { get; private set; }

        public ApiException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, TResult result, System.Exception innerException)
            : base(message, statusCode, response, headers, innerException)
        {
            Result = result;
        }
    }

}
