﻿namespace MaxCoRetailManager.Application.Responses
{
    public class AuthResponse : BaseResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

    }
}