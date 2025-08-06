using Entity.DTOs.Post;

namespace StrongmanDudlBLOG.APIConnection.Interfaces;

internal interface IPost
{
    public Task<bool> UserAsync(PostLoginDTO oPostUserDTO);
}