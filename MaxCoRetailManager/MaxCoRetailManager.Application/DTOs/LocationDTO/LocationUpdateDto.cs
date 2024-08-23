using MaxCoRetailManager.Application.DTOs.Common;

namespace MaxCoRetailManager.Application.DTOs.LocationDTO;

public class LocationUpdateDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ParentLocationId { get; set; } = 0;

    public string UserId { get; set; } = Guid.NewGuid().ToString();

}

