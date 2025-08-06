using System.Text;
using Entity;
using Entity.DTOs.Post;
using Newtonsoft.Json;
using StrongmanDudlBLOG.APIConnection.Interfaces;

namespace StrongmanDudlBLOG.APIConnection;

internal class PostToAPI : IPost, IDisposable
{
    private HttpClientHandler oHandler;
    private HttpClient oClient;
    private Guid oSessionToken;
    
    private const string csAPILink = "http://localhost:5050/api/";


    public PostToAPI()
    {
        oHandler = new HttpClientHandler();
        oHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
        oHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
        oClient = new HttpClient(oHandler);
    }
    public void Dispose()
    {
        oClient.Dispose();
        oHandler.Dispose();
    }
    
    
    public async Task<bool> UserAsync(PostLoginDTO oPostLoginDTO)
    {
        try
        {
            if (oPostLoginDTO == null)
            {
                Console.WriteLine("PostLoginDTO is null");
                return false;
            }

            string sURL = csAPILink + "register/";
            
            using HttpRequestMessage oRequest = new(HttpMethod.Post, sURL);
            
            string sJson = JsonConvert.SerializeObject(oPostLoginDTO);
            oRequest.Content = new StringContent(sJson, Encoding.UTF8, "application/json");
            
            if(oSessionToken == Guid.Empty)
            {
                oRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", oSessionToken.ToString());
            }
            else
            {
                oRequest.Headers.Add(RequestValues.HEADER_TOKEN, oSessionToken.ToString());
            }
            
            HttpResponseMessage oResponse = await oClient.SendAsync(oRequest);
            
            Console.WriteLine(oResponse.StatusCode);
            Console.WriteLine(await oResponse.Content.ReadAsStringAsync());
            
            return oResponse.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public void SetSessionToken(Guid oSessionToken)
    {
        this.oSessionToken = oSessionToken;
    }
}
/*private HttpRequestMessage PrepareRequest(string sURL)
     {
         try
         {
             HttpRequestMessage oRequest = new HttpRequestMessage(HttpMethod.Post, sURL);
             oRequest.Content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
             //oRequest.Headers.Add(RequestValues.HEADER_TOKEN, oSessionToken.ToString());
             //oClient.DefaultRequestHeaders.Add(RequestValues.HEADER_TOKEN, oSessionToken.ToString());
             if (RequestValues.HEADER_TOKEN == "Authorization")
             {
                 oRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", oSessionToken.ToString());
             }
             else
             {
                 oRequest.Headers.Add(RequestValues.HEADER_TOKEN, oSessionToken.ToString());
             }
                 
             return oRequest;
         }
         catch (HttpRequestException)
         {
             return null;
         }
     }*/
/*public bool User(PostLoginDTO oPostLoginDTO)
            {
                string sURL = csAPILink + "register/";
                using (HttpRequestMessage oRequest = PrepareRequest(sURL))
                {
                    //StringContent oContent = new(JsonConvert.SerializeObject(oPostLoginDTO), Encoding.UTF8, "application/json");
                    using (HttpResponseMessage oResponse = oClient.PostAsync(oRequest.RequestUri, oContent).Result)
                    {
                        if (oResponse.IsSuccessStatusCode)
                            return true;
                    }
                }
                return false;
            }*/