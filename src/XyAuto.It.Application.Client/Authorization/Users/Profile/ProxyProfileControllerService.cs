using System.IO;
using System.Threading.Tasks;
using XyAuto.It.Authorization.Users.Profile.Dto;

namespace XyAuto.It.Authorization.Users.Profile
{
    public class ProxyProfileControllerService : ProxyControllerBase
    {
        public async Task<UploadProfilePictureOutput> UploadProfilePicture(Stream stream, string fileName)
        {
            return await ApiClient
                .PostMultipartAsync<UploadProfilePictureOutput>(GetEndpoint(nameof(UploadProfilePicture)), stream, fileName);
        }
    }
}
