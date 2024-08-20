namespace MaxCoRetailManager.Application.DTOs.Common
{
    public class BaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;
    }
}
