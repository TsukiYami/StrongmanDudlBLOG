using Entity.Entities;

namespace BackendStrongmanDudlBLOG.Caches;

public class LogedInUserCache
{
    private static Dictionary<Guid, LoginEntity> mooLogin = new();

    public static bool Add(Guid oGUID, LoginEntity oEntity)
    {
        if (mooLogin[oGUID] != null)
            return false;
        
        mooLogin.Add(oGUID, oEntity);
        return true;
    }

    public static void Remove(Guid oGUID) => mooLogin.Remove(oGUID);
}