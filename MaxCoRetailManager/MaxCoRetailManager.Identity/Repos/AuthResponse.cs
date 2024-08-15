using MaxCoRetailManager.Core.Common;

namespace MaxCoRetailManager.Core.Response
{
    public class AuthResponse : BaseResponse
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;

    }
}