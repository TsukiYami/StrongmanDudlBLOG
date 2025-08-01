using Entity.DTOs.Post;

namespace StrongmanDudlBLOG.APIConnection;

internal class APIService
{
    private static APIService _instance;
    private static readonly Lock _lock = new();
    private PostToAPI m_oPostToAPI;

    private APIService()
    {
        m_oPostToAPI = new PostToAPI();
    }

    public static APIService Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new APIService();
                    }
                }
            }
            return _instance;
        }
    }
    
    public PostToAPI PostUser()
    {
        return m_oPostToAPI;
    }
}