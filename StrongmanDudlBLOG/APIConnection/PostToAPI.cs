using System.Text;
using Entity;
using Entity.DTOs.Post;
using Newtonsoft.Json;
using StrongmanDudlBLOG.APIConnection.Interfaces;

namespace StrongmanDudlBLOG.APIConnection;

internal class PostToAPI : IPost
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
    
    ~PostToAPI()
    {
        oHandler.Dispose();
    }
    
    private HttpRequestMessage PrepareRequest(string sURL)
    {
        try
        {
            HttpRequestMessage oRequest = new HttpRequestMessage(HttpMethod.Post, new Uri(sURL));
            oClient.DefaultRequestHeaders.Add(RequestValues.HEADER_TOKEN, oSessionToken.ToString());
            return oRequest;
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }
    
    public bool User(PostLoginDTO oPostLoginDTO)
    {
        string sURL = csAPILink + "register/";
        using (HttpRequestMessage oRequest = PrepareRequest(sURL))
        {
            StringContent oContent = new(JsonConvert.SerializeObject(oPostLoginDTO), Encoding.UTF8, "application/json");
            using (HttpResponseMessage oResponse = oClient.PostAsync(oRequest.RequestUri, oContent).Result)
            {
                if (oResponse.IsSuccessStatusCode)
                    return true;
            }
        }
        return false;
    }
}