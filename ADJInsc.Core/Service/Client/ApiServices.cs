/*
para realizar el llamado me base en este codigo
https://johnthiriet.com/efficient-api-calls/
por John Thiriet

 */

namespace xa.App.Services
{
    using ADJInsc.Core.Service.Interface;
    using ADJInsc.Models.Basic;
    using ADJInsc.Models.ViewModels;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    public class ApiServices : IApiService
    {
        private readonly UrlBase _urlBase;
        public ApiServices(IOptions<UrlBase> urlBase)
        {
            _urlBase = urlBase.Value;
        }

        public async Task<Response> GetAsync<T>(string prefix, string controller, CancellationToken cancellationToken)
        {
            try
            {
                var url = string.Empty;
                var answer = string.Empty;
                
                url = $"{_urlBase.UrlServer}{prefix}{controller}";

                using var client = new HttpClient();
                using var request = new HttpRequestMessage(HttpMethod.Get, url);

                //ResponseHeaderRead permite leer aunque no haya llegado todo el json
                using var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

                var stream = await response.Content.ReadAsStreamAsync();

                //var content = await StreamToStringAsync(stream);  //deserializa para obtener el error

                if (response.IsSuccessStatusCode == false)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Result = StreamToStringAsync(stream)
                    };
                    /*throw new ApiException
                    {
                        StatusCode = (int)response.StatusCode,
                        Content = await StreamToStringAsync(stream)  //deserializa para obtener el error
                };*/
                }

                return new Response
                {
                    IsSuccess = true,
                    Result = DeserializeJsonFromStream<T>(stream),
                    Message = "Ok"
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response> PostAsync<T>(string prefix, string controller, ModeloCarga titularModel, InscViewModel inscViewModel, CancellationToken cancellationToken)
        {            
           
            string url = $"{_urlBase.UrlServer}{prefix}{controller}";
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using var request = new HttpRequestMessage(HttpMethod.Post, url);

                var json = string.Empty;
                //no mandar en formato json
                if (titularModel == null)
                {
                    json = JsonConvert.SerializeObject(inscViewModel);
                }
                else
                {
                    json = JsonConvert.SerializeObject(titularModel);
                }

                request.Content = new StringContent(json);
                request.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                using var response = await client
                     .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                     .ConfigureAwait(false);

                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync();

                if (response.IsSuccessStatusCode)
                {
                    
                    //if (titularModel.dni == "0")
                    if(titularModel == null)
                    {
                        return new Response
                        {
                            IsSuccess = true,
                            Result = DeserializeJsonFromStream<ResponseViewModel>(stream),
                            Message = "Ok"
                        };
                    }
                    else
                    {
                        if (titularModel.dni == "0")
                        {
                            return new Response
                            {
                                IsSuccess = true,
                                Result = DeserializeJsonFromStream<InscViewModel>(stream),
                                Message = "Ok"
                            };
                        }
                        else
                        {
                            return new Response
                            {
                                IsSuccess = true,
                                Result = DeserializeJsonFromStream<ResponseViewModel>(stream),
                                Message = "Ok"
                            };
                        }
                       
                    }

                }

                return new Response
                {
                    IsSuccess = false,
                    Message = response.ReasonPhrase
                };
                
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Excepcion  --> " + ex.Message

                };
            }
    

        }

    


        private static T DeserializeJsonFromStream<T>(Stream stream)
        {
            if (stream == null || stream.CanRead == false)
                return default(T);

            using (var sr = new StreamReader(stream))
            using (var jtr = new JsonTextReader(sr))
            {
                var js = new JsonSerializer();
                var searchResult = js.Deserialize<T>(jtr);
                return searchResult;
            }
        }

        private static async Task<string> StreamToStringAsync(Stream stream)
        {
            string content = null;

            if (stream != null)
                using (var sr = new StreamReader(stream))
                    content = await sr.ReadToEndAsync();

            return content;
        }

       
    }
}




#region Metodos muertos




/*
var request = (HttpWebRequest)WebRequest.Create(url);
string json = $"{{\"titularModel\":\"{titularModel}\"}}";
request.Method = "POST";
request.ContentType = "application/json";

using (var streamWriter = new StreamWriter(request.GetRequestStream()))
{
   streamWriter.Write(json);
   streamWriter.Flush();
   streamWriter.Close();
}

try
{
   using (WebResponse response = request.GetResponse())
   {
       using (Stream strReader = response.GetResponseStream())
       {
           if (strReader == null) return new Response
           {
               IsSuccess = false
           };

           return new Response
           {
               IsSuccess = true,
               Result = DeserializeJsonFromStream<T>(strReader)
           };
           /*
           using (StreamReader objReader = new StreamReader(strReader))
           {
               //string responseBody = objReader.ReadToEnd();

               return new Response
               {
                   IsSuccess = true,
                   Result = DeserializeJsonFromStream<T>(strReader)
               };
           }

       }
   }
}catch (Exception ex) {

   return new Response
   {
       IsSuccess = false,
       Result = ex.Message
   };
}
*/
#endregion