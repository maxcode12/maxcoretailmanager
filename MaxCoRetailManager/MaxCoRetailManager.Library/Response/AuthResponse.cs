using MaxCoRetailManager.Core.Common;

namespace MaxCoRetailManager.Identity.Repos
{
    public class AuthResponse : BaseResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

    }
}