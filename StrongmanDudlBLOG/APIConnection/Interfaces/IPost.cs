using Entity.DTOs.Post;

namespace StrongmanDudlBLOG.APIConnection.Interfaces;

internal interface IPost
{
    public bool User(PostLoginDTO oPostUserDTO);
}