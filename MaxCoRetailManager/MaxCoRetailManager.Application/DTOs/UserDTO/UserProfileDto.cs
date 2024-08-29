namespace MaxCoRetailManager.Application.DTOs.UserDTO
{
    public class UserProfileDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string PhotoUrl { get; set; }
        public string RoleName { get; set; }
        public string UserId { get; set; }
        public string Permission { get; set; }
    }
}
